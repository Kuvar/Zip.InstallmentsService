using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;
using Zip.InstallmentsService.Interfaces;
using Zip.InstallmentsService.Test.Fixtures;

namespace Zip.InstallmentsService.Test
{
    public class PaymentPlanFactoryTest : IClassFixture<ContainerFixture>
    {

        private ServiceProvider _serviceProvider;

        public PaymentPlanFactoryTest(ContainerFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void FailingTest()
        {
            var dependency = _serviceProvider.GetService<PaymentPlanFactory>();

            //Assert.Equal("4", dependency.test().ToString());
            
        }

    }
}