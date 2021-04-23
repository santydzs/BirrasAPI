using AutoMapper;
using Business;
using Business.Interfaces;
using Database.Entity;
using Database.UnitsOfWorks.Implementations;
using Database.UnitsOfWorks.Interfaces;
using Business.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using Services.Logic;

namespace BirrasAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<BirrasContext>(options => options.UseSqlServer("name=ConnectionStrings:local"));

            //Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MeetProfiles());
                mc.AddProfile(new RolProfile());
                mc.AddProfile(new UserProfile());
            });

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }) .AddJwtBearer(jwt => {
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true, // this will validate the 3rd part of the jwt token using the secret that we added in the appsettings and verify we have generated the jwt token
                    IssuerSigningKey = new SymmetricSecurityKey(key), // Add the secret key to our Jwt encryption
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Service Layer
            services.AddTransient<IWeatherLogic, WeatherLogic>();

            //DataBase layer
            services.AddTransient<IMeetUnitOfWork, MeetUnitOfWork>();
            services.AddTransient<IUserUnitOfWork, UserUnitOfWork>();

            //Business layer
            services.AddTransient<IMeetBusiness, MeetBusiness>();
            services.AddTransient<IDataBusiness, DataBusiness>();
            services.AddTransient<IUserBusiness, UserBusiness>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BirrasAPI", Version = "v1" });
            });

            services.AddCors(c =>
            {
                c.AddDefaultPolicy(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BirrasAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
