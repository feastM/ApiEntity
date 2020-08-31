using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.API.Domain.Models;
using Users.API.Domain.Services;
using Users.API.Domain.Services.Communication;

namespace Users.API.Domain.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> ListAsync();
        Task<SaveEmployeeResponse> SaveAsync(Employee employee);
       Task<SaveEmployeeResponse> UpdateAsync(int id, Employee employee);

    }
}
