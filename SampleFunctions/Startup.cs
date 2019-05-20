using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SampleFunctions.Di;

[assembly: FunctionsStartup(typeof(SampleFunctions.Startup))]

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
}
