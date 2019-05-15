using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using SampleFunctions.Data.Models;
using System;

namespace SampleFunctions.OutputBindings
{
    public static class PushToCosmosDbFn
    {
        [FunctionName("H_AddStudent_C")]
        public static IActionResult AddStudent(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v2/students")] NewStudent newStudent
            , [CosmosDB("school", "students", ConnectionStringSetting = "CosmosDbConn")] out StudentCosmosModel student)
        {
            student = null;

            if (string.IsNullOrWhiteSpace(newStudent.Name))
            {
                return new BadRequestObjectResult("Student name required.");
            }

            var rand = new Random();
            student = new StudentCosmosModel
            {
                studentId = rand.Next(1000, 900000),
                name = newStudent.Name
            };

            return new CreatedResult($"api/students/{student.studentId}", student);
        }
    }

    public class StudentCosmosModel
    {
        public int studentId { get; set; }
        public string name { get; set; }
    }
}
