using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using SampleFunctions.Data.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SampleFunctions.InputBindings
{
    public static class GetFromCosmosDbFn
    {
        // This also shows route constraints guid vs int

        [FunctionName("H_C_GetStudent")]
        public static IActionResult GetStudentById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "students/{studentId:int}")] HttpRequest req
            , int studentId
            , [CosmosDB("school", "students", ConnectionStringSetting = "CosmosDbConn"
                    , SqlQuery = "SELECT * FROM c where c.studentId = {studentId}")]IEnumerable<Student> students)
        {
            var student = students.SingleOrDefault();

            return (null == student) ?
                (IActionResult)new NotFoundResult()
                : new OkObjectResult(student);
        }
    }
}
