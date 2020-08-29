using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Employee
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNo { get; set; }

    }
}
