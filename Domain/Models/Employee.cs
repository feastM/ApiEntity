using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Users.API.Domain.Models
{
    public class Employee 
    {
        

        private int _age;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Description { get; set; }

        public int Age { 
            get
            {

                _age  = Calculator.GetAge(DateOfBirth);
                return _age;
            }
            set
            {
                
                _age = value; 
            }
        }
      

    }
}
