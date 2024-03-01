using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
	public class Salesperson
	{
        [Key]
        public int SalespersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

