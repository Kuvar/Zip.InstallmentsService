using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;
using Zip.InstallmentsService.Interfaces;

namespace Zip.InstallmentsService.Test.Fixtures
{
    public class ContainerFixture
    {
        public ContainerFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddHttpContextAccessor()
                .AddHttpClient();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
