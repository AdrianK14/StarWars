using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using StarWars.Contracts.Factory;
using StarWars.Contracts.SwApiClient;
using StarWars.Entities;
using StarWars.Factories;
using StarWars.SwApiClient;
using static TddXt.AnyRoot.Root;

namespace StarWars.Specification
{
    public class StartupSpecification
    {
        [Test]
        public void ConfigureServices_should_registers_dependencies_correctly()
        {
            //Arrange
            IServiceCollection services = new ServiceCollection();
            var configuration = Any.Instance<IConfiguration>();
            var logger = Any.Instance<ILogger<PersonInfoDtoFactory>>();
            var target = new Startup(configuration);
     
            //Act
            target.ConfigureServices(services);
            services.AddSingleton(logger);
            services.AddSingleton(configuration);
            services.AddSingleton(Any.Instance<ILogger<Person>>());
            services.AddSingleton(Any.Instance<ILogger<Starship>>());
            services.AddSingleton(Any.Instance<ILogger<Vehicle>>());
            services.AddSingleton(Any.Instance<ILogger<Film>>());
            services.AddTransient<IStarWarsApiClient, StarWarsApiClient>();
            services.AddTransient<IPersonInfoDtoFactory, PersonInfoDtoFactory>();
            services.AddTransient<IWebClient, WebClient>();
            services.AddTransient<IRetrievePersonInfoCommandFactory, RetrievePersonInfoCommandFactory>();

            //Assert
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<IStarWarsApiClient>().Should().NotBeNull().And.BeOfType(typeof(StarWarsApiClient));
            serviceProvider.GetService<IPersonInfoDtoFactory>().Should().NotBeNull().And.BeOfType(typeof(PersonInfoDtoFactory));
            serviceProvider.GetService<IWebClient>().Should().NotBeNull().And.BeOfType(typeof(WebClient));
            serviceProvider.GetService<IRetrievePersonInfoCommandFactory>().Should().NotBeNull().And.BeOfType(typeof(RetrievePersonInfoCommandFactory));
        }
    }
}
