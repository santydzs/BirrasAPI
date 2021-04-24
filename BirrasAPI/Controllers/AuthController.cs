﻿using BirrasAPI.Request;
using BirrasAPI.Response;
using Business.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BirrasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserBusiness _business { get; set; }
        private string _jwtSecret { get; set; }

        public AuthController(IConfiguration config,IUserBusiness business)
        {
            _business = business;
            _jwtSecret = config["jwtConfig:Secret"];
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDTO user)
        {
            var userDb = await _business.Add(user);
            
            var jwtToken = GenerateJwtToken(userDb.Email);

            return Ok(new LoginResponse()
            {
                authResult = new AutResult()
                {
                    Result = true,
                    Token = jwtToken,

                },
                User = userDb
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login user)
        {
            var dbUser = await _business.GetwithPassword(user.email);

            if(dbUser == null || dbUser.Password != user.password)
            {
                return BadRequest(new AutResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "incorrect password or user doesnt exist"
                    }
                });
            }

            var jwtToken = GenerateJwtToken(user.email);

            return Ok(new LoginResponse()
            {
                authResult = new AutResult()
                {
                    Result = true,
                    Token = jwtToken,

                },
                User = dbUser
            });
        }

        private string GenerateJwtToken(string email)
        {
            // Now its ime to define the jwt token which will be responsible of creating our tokens
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            // We get our secret from the appsettings
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            // we define our token descriptor
            // We need to utilise claims which are properties in our token which gives information about the token
            // which belong to the specific user who it belongs to
            // so it could contain their id, name, email the good part is that these information
            // are generated by our server and identity framework which is valid and trusted
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    // the JTI is used for our refresh token which we will be convering in the next video
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                // the life span of the token needs to be shorter and utilise refresh token to keep the user signedin
                // but since this is a demo app we can extend it to fit our current need
                Expires = DateTime.UtcNow.AddHours(6),
                // here we are adding the encryption alogorithim information which will be used to decrypt our token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
