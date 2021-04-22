using BirrasAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using Xunit;

namespace BirrasApiTest.IntegrationTest
{
    public class RolProfileTest
    {
        public HttpClient Client { get; set; }
        public RolProfileTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = server.CreateClient();
        }

        [Fact]
        public async void Test1()
        {
            var response = await Client.GetAsync("/api/Rol");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
