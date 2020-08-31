using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Users.API.Domain.Models;
using Users.API.Domain.Repositories;
using Users.API.Domain.Services;
using Users.API.Domain.Services.Communication;
using Users.API.Resources;

namespace Users.API.Servicies
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            
        }
        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return  _employeeRepository.ListAsync();
        }
      
        public async Task<SaveEmployeeResponse> SaveAsync(Employee employee)
        {
            try
            {
                await _employeeRepository.AddAsync(employee);
                //await _unitOfWork.CompleteAsync();

                return new SaveEmployeeResponse(employee);

            }
            catch (Exception ex)
            {
                // log  
                return new SaveEmployeeResponse($"Ërror ocurred when saving category: {ex.Message}");
            }
        }

        public  async Task<SaveEmployeeResponse> UpdateAsync(int id, Employee employee)
        {
            var existingEmployee = await  _employeeRepository.FindByIdAsync(id);

            if (existingEmployee == null)
                return new SaveEmployeeResponse("Employee not found.");
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Email = employee.Email;
            existingEmployee.DateOfBirth = employee.DateOfBirth;
            existingEmployee.Description = employee.Description;

            try
            {
                _employeeRepository.Update(existingEmployee);
                
                return new SaveEmployeeResponse(existingEmployee);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveEmployeeResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }
      
    }
}
