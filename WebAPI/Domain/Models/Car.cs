using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
	public class Car
	{
        [Key]
        public int CarID { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string VIN { get; set; }
    }
}

