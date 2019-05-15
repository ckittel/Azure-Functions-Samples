using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;
using SampleFunctions.Data.Repository;
using SampleFunctions.Data.Models;
using System;

namespace SampleFunctions.Triggers
{
    // Documentation Link: https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-http-webhook#trigger
    // Can be one of HttpRequest or POCO
    // The HTTP request is limited to 100 MB(104,857,600 bytes), and the URL length is limited to 4 KB(4,096 bytes).
    // If HTTP trigger doesn't complete within about 2.5 minutes, the gateway will time out and return an HTTP 502 error
    //      The function will continue running but will be unable to return an HTTP response.

    public static class HttpTriggerFns
    {
        [FunctionName("H_OnGetStudents")]
        public static async Task<IEnumerable<Student>> OnGetStudentsAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "students")] HttpRequest req
            , CancellationToken ct)
        {
            IStudentsRepository repository = new StudentsRepository();
            return await repository.GetAllAsync(ct);
        }

        [FunctionName("H_OnGetStudent")]
        public static async Task<IActionResult> OnGetStudentAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "students/{studentId:guid}")] HttpRequest req
            , string studentId
            , ILogger log
            , CancellationToken ct)
        {
            log.LogInformation($"Request for student with ID {studentId} is being handled.");

            IStudentsRepository repository = new StudentsRepository();
            var student = await repository.GetByIdAsync(Guid.Parse(studentId), ct);

            return (null == student) ?
                (IActionResult) new NotFoundObjectResult($"Student ({studentId}) not found.") :
                new OkObjectResult(student);
        }

        [FunctionName("H_OnAddStudent")]
        public static async Task<IActionResult> OnAddStudentAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "students")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            NewStudent newStudent = JsonConvert.DeserializeObject<NewStudent>(requestBody);

            if (string.IsNullOrWhiteSpace(newStudent.Name))
            {
                return new BadRequestObjectResult("Missing student name.");
            }

            var student = new Student(Guid.NewGuid(), newStudent.Name);

            // TODO: Save it

            return new CreatedResult($"api/students/{student.Id}", student);
        }

        // Same thing but using the body deserialization
        //[FunctionName("H_OnAddStudent")]
        //public static IActionResult OnAddStudent(
        //[HttpTrigger(AuthorizationLevel.Function, "post", Route = "students")] NewStudent newStudent)
        //{
        //    if (string.IsNullOrWhiteSpace(newStudent.Name))
        //    {
        //        return new BadRequestObjectResult("Missing student name.");
        //    }

        //    var student = new Student(Guid.NewGuid(), newStudent.Name);

        //    // TODO: Save it

        //    return new CreatedResult($"api/students/{student.Id}", student);
        //}
    }
}
