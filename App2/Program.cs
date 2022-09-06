using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DataGap.Jellog;

namespace App2
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<App2Module>(options =>
            {
                options.UseAutofac();
            }))
            {
                application.Initialize();

                var messagingService = application
                    .ServiceProvider
                    .GetRequiredService<App2MessagingService>();

                await messagingService.RunAsync();

                application.Shutdown();
            }
        }
    }
}
