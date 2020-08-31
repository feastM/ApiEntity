using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.API.Domain.Models;

namespace Users.API.Domain.Services.Communication
{
    public class SaveEmployeeResponse : BaseResponse
    {
        public Employee Employee { get; private set; }
        private SaveEmployeeResponse(bool success, string message, Employee employee) : base(success, message)
        {
            Employee = employee;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param employee="FirstName">Saved employee.</param>
        /// <returns>Response.</returns>
        public SaveEmployeeResponse(Employee employee) : this(true, string.Empty, employee)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param employee="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveEmployeeResponse(string message) : this(false, message, null)
        { }
    }
}
