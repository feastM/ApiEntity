using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.API.Domain.Models;

namespace Users.API.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> ListAsync();
       Task AddAsync(Employee employee);
      Task<Employee> FindByIdAsync(int  id);
      void Update(Employee employee);
        
    }
}
