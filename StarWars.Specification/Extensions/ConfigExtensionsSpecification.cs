using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using StarWars.Extensions;

namespace StarWars.Specification.Extensions
{
    public class ConfigExtensionsSpecification
    {
        private readonly Dictionary<string, string> _config = new Dictionary<string, string>
        {
            {"StarWarsApi:ApiUrl", "https://swapi.dev/api/"},
            {"StarWarsApi:ProxyUrl", "217.117.128.5"},
            {"StarWarsApi:ProxyPort", "80"},
            {"Paths:JsonOutput", "results" }
        };

        [Test]
        public void Should_return_valid_api_url()
        {
            //Arrange
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(_config)
                .Build();

            //Act
            var apiUrl = configuration.GetApiUrl();

            //Assert
            apiUrl.Should().Be(_config["StarWarsApi:ApiUrl"]);
        }

        [Test]
        public void Should_return_valid_proxy_url()
        {
            //Arrange
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(_config)
                .Build();

            //Act
            var proxyUrl = configuration.GetProxyUrl();

            //Assert
            proxyUrl.Should().Be(_config["StarWarsApi:ProxyUrl"]);
        }

        [Test]
        public void Should_return_valid_proxy_port()
        {
            //Arrange
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(_config)
                .Build();

            //Act
            var apiUrl = configuration.GetProxyPort();

            //Assert
            apiUrl.Should().Be(int.Parse(_config["StarWarsApi:ProxyPort"]));
        }

        [Test]
        public void Should_return_default_proxy_port()
        {
            //Arrange
            _config["StarWarsApi:ProxyPort"] = "asd";
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(_config)
                .Build();
            _config["StarWarsApi:ProxyPort"] = "80";

            //Act
            var proxyPort = configuration.GetProxyPort();

            //Assert
            proxyPort.Should().Be(80);
        }

        [Test]
        public void Should_return_valid_output_path()
        {
            //Arrange
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(_config)
                .Build();

            //Act
            var outputPath = configuration.GetOutputPath();

            //Assert
            outputPath.Should().Be(_config["Paths:JsonOutput"]);
        }
    }
}
