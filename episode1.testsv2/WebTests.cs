using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using episode1.Models;
using Moq;
using FluentAssertions;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace episode1.testsv2
{
    [TestFixture]
    public class WebTests
    {
        public HttpClient HttpClient;

        [SetUp]
        public void Setup()
        {
            HttpClient = new HttpClient();
        }
        [Test]
        public async Task Http_response_should_have_204_status_code()
        {
            //Arrange

            //Act
            var response = await HttpClient.GetAsync("http://httpstat.us/204");
            //Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().BeEquivalentTo<HttpStatusCode>(HttpStatusCode.NoContent);
        }
    }
}
