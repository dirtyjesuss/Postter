using System;
using System.Net;
using System.Threading.Tasks;
using Postter.Presentation;
using Postter.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TestProject1
{
    public class ControllerTests:TestsBase
    {
        public ControllerTests(WebApplicationFactory<Startup> webApplicationFactory) : base(webApplicationFactory)
        {
        }

        [Theory]
        [InlineData(nameof(HomeController.Index), HttpStatusCode.OK)]
        public async Task HomeControllerTests(
            string url,
            HttpStatusCode httpStatusCode)
        {
            var response = await Client.GetAsync($"Home/{url}");
            Assert.Equal(httpStatusCode, response.StatusCode);
        }
        [Theory]
        [InlineData(nameof(AccountController.Register), HttpStatusCode.OK)] 
        public async Task AccountControllerTests(
            string url,
            HttpStatusCode httpStatusCode)
        {
            var response = await Client.GetAsync($"Account/{url}");
            Assert.Equal(httpStatusCode, response.StatusCode);
        }
    }
}