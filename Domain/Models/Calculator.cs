using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Users.API.Domain.Models
{
    public class Calculator 
    {


       

        public static int GetAge(DateTime year)
        {
            var CurrentTime = DateTime.Today;

            var Time = year.Year;
            var Age = CurrentTime.Year - Time;
            return Age;
        }
    }
}
