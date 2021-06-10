using System.Net.Http;
using Postter.Presentation;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TestProject1
{
    public abstract class TestsBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<Startup> WebApplicationFactory;

        protected readonly HttpClient Client;
        
        protected TestsBase(WebApplicationFactory<Startup> webApplicationFactory)
        {
            WebApplicationFactory = webApplicationFactory;
            Client = webApplicationFactory.CreateClient();
        }
    }
}