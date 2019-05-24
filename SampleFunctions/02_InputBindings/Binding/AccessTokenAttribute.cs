using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SampleFunctions._02_InputBindings.Binding
{
    /// <summary>
    /// MUST have a HttpRequest type on the HttpTrigger.  And JWT Token must be in
    /// Authorization header
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class AccessTokenAttribute : Attribute
    {
    }

    public class AccessTokenBinding : IBinding
    {
        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            // Assumes only one parameter of type HttpRequest!
            var request = context.BindingData.Values.OfType<DefaultHttpRequest>().FirstOrDefault();
            return Task.FromResult<IValueProvider>(new AccessTokenValueProvider(request));
        }

        public bool FromAttribute => true;

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context) => null;

        public ParameterDescriptor ToParameterDescriptor() => new ParameterDescriptor();
    }
}
