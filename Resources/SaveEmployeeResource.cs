using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Users.API.Resources
{
    public class SaveEmployeeResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
