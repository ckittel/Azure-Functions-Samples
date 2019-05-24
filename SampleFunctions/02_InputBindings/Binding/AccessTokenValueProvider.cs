using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SampleFunctions._02_InputBindings.Binding
{
    public class AccessTokenValueProvider : IValueProvider
    {
        private const string AUTH_HEADER_NAME = "Authorization";
        private const string BEARER_PREFIX = "Bearer ";
        private HttpRequest _request;

        public AccessTokenValueProvider(HttpRequest request)
        {
            _request = request;
        }

        public Task<object> GetValueAsync()
        {
            _request.Headers.TryGetValue(AUTH_HEADER_NAME, out var authHeaders);
            if (1 == authHeaders.Count)
            {
                var authHeader = authHeaders.Single();

                if ((!string.IsNullOrWhiteSpace(authHeader)) && authHeader.StartsWith(BEARER_PREFIX))
                {
                    var handler = new JwtSecurityTokenHandler();

                    return Task.FromResult<object>(handler.ReadJwtToken(authHeader.Substring(BEARER_PREFIX.Length)));
                }
            }

            throw new SecurityTokenException("Access token issue.");
        }

        public Type Type => typeof(JwtSecurityToken);

        public string ToInvokeString() => string.Empty;
    }
}
