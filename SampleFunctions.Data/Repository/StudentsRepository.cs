using SampleFunctions.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleFunctions.Data.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken ct)
        {
            return await Task.FromResult(new List<Student>()
            {
                new Student(Guid.NewGuid(), "Bobby"),
                new Student(Guid.NewGuid(), "Amit"),
            });
        }

        public async Task<Student> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await Task.FromResult(new Student(id, "Jyothi"));
        }
    }
}
