using Microsoft.Azure.WebJobs.Host.Config;

namespace SampleFunctions._02_InputBindings.Binding
{
    public class AccessTokenExtensionProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            // Creates a rule that links the attr to the binding
            context.AddBindingRule<AccessTokenAttribute>()
                   .Bind(new AccessTokenBindingProvider());
        }
    }
}
