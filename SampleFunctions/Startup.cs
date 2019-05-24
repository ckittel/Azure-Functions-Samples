using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SampleFunctions._02_InputBindings.Binding;
using SampleFunctions.Di;

[assembly: FunctionsStartup(typeof(SampleFunctions.Startup))]
[assembly: WebJobsStartup(typeof(SampleFunctions.WebJobStartup))]

namespace SampleFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IMyClass>((s) => {
                return new MyClass();
            });
        }
    }

    public class WebJobStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddAccessTokenBinding();
        }
    }
}
