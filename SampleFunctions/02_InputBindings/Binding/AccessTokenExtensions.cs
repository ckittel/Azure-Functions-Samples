using Microsoft.Azure.WebJobs;
using System;

namespace SampleFunctions._02_InputBindings.Binding
{
    public static class AccessTokenExtensions
    {
        public static IWebJobsBuilder AddAccessTokenBinding(this IWebJobsBuilder builder)
        {
            builder.AddExtension<AccessTokenExtensionProvider>();
            return builder;
        }
    }
}
