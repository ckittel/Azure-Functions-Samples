using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Threading.Tasks;

namespace SampleFunctions._02_InputBindings.Binding
{
    public class AccessTokenBindingProvider : IBindingProvider
    {
        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            return Task.FromResult<IBinding>(new AccessTokenBinding());
        }
    }
}
