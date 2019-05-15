using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleFunctions.Data.Models;
using SampleFunctions.InputBindings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleFunctions.Tests
{
    [TestClass]
    public class GetFromCosmosDbFnTests
    {
        [TestMethod]
        public void When_StudentNotFound_Then_404()
        {
            // Arrange
            var students = new List<Student>(); // Represents no results

            // Act
            var httpResult = GetFromCosmosDbFn.GetStudentById(null, 0, students);

            // Assert
            httpResult.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void When_StudentNotFound_Then_200WithStudent()
        {
            // Arrange
            var students = new List<Student>
            {
                new Student(Guid.NewGuid(), "Unit Test Student")
            };

            // Act
            var httpResult = GetFromCosmosDbFn.GetStudentById(null, 0, students);

            // Assert
            var objectResult = httpResult.Should().BeOfType<OkObjectResult>().Subject;
            objectResult.Value.Should().Be(students.Single());
        }
    }
}
