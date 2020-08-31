using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.API.Domain.Models;
using Users.API.Domain.Repositories;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using AutoMapper.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Users.API.Repositories
{
    public class EmployeeRepository :  IEmployeeRepository 

    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
        public EmployeeRepository(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _config = config;
        }

        internal IDbConnection DbConnection => new SqlConnection(_config.GetConnectionString("SQLDBConnectionString"));

        
        public async Task AddAsync(Employee employee)
        {
            using(IDbConnection con = DbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", employee.Id);
                parameters.Add("FirstName", employee.FirstName);
                parameters.Add("LastName", employee.LastName);
                parameters.Add("Email", employee.Email);
                parameters.Add("DateOfBirth", employee.DateOfBirth);
                parameters.Add("Description", employee.Description);    
                SqlMapper.Execute(con, "AddEmp", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Employee> FindByIdAsync(int id)
        {
            using (IDbConnection con = DbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", id);
                return  await SqlMapper.QueryAsync<Employee>(con, "GetById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        } 

        public IEnumerable<Employee> ListAsync()
        {
           
            using( IDbConnection con = DbConnection)
            { 
            return SqlMapper.Query<Employee>(con, "GetAge", commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Employee employee)
        {
            using (IDbConnection con = DbConnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", employee.Id);
                parameters.Add("FirstName", employee.FirstName);
                parameters.Add("LastName", employee.LastName);
                parameters.Add("Email", employee.Email);
                parameters.Add("DateOfBirth", employee.DateOfBirth);
                parameters.Add("Description", employee.Description);
                SqlMapper.Execute(con, "UpdateEmp", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }
       
    }
}
