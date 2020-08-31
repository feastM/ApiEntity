using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.API.Domain.Models;
using Users.API.Domain.Repositories;
using Users.API.Persistance.Context;

namespace Users.API.Persistance.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return (IEnumerable<Employee>)await _context.Employees.ToListAsync();
        }
        public async Task<Employee> FindByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }

       
    }
}
