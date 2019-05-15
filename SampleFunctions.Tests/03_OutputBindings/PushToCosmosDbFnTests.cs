using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleFunctions.Data.Models;
using SampleFunctions.OutputBindings;
using System;

namespace SampleFunctions.Tests
{
    [TestClass]
    public class PushToCosmosDbFnTests
    {
        [TestMethod]
        public void When_TriggerFires_Then_CorrectObjectReturned()
        {
            // Arrange
            var inputStudent = new NewStudent { Name = "UnitTest Student" };

            // Act
            var httpResponse = PushToCosmosDbFn.AddStudent(inputStudent, out StudentCosmosModel student);

            // Assert (HTTP Response)
            var createdResult = httpResponse.Should().BeOfType<CreatedResult>().Subject;
            createdResult.Location.Should().Be($"api/students/{student.studentId}");
            student.Should().Be(createdResult.Value);
            student.name.Should().Be("UnitTest Student");
        }
    }


}
