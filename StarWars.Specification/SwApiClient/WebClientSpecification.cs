using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using StarWars.Contracts.SwApiClient;

namespace StarWars.Specification.SwApiClient
{
    public class WebClientSpecification
    {
        [Test]
        public void Should_return_response()
        {
            //Arrange
            var testApiUrl = "https://testapi.pl";
            var webClient = Substitute.For<IWebClient>();
            webClient.SendRequest(testApiUrl).Returns("test");

            //Act
            var response = webClient.SendRequest(testApiUrl);

            //Assert
            webClient.Received(1).SendRequest(testApiUrl);
            response.Should().Be("test");
        }
    }
}
