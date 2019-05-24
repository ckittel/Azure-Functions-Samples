using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using SampleFunctions._02_InputBindings.Binding;

namespace SampleFunctions.InputBindings
{
    public static class GetAccessTokenFn
    {
        [FunctionName("H_AT_SayHi")]
        public static IActionResult GetStudentById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "hello")] HttpRequest req
            , [AccessToken]JwtSecurityToken token)
        {
            return new OkResult();
        }
    }

}
