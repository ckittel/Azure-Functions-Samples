using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SampleFunctions.Data.Models;

namespace SampleFunctions.Data.Repository
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Student>> GetAllAsync(CancellationToken ct);
        Task<Student> GetByIdAsync(Guid id, CancellationToken ct);
    }
}