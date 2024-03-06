using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
	public class Transaction
	{
        [Key]
        public int TransactionID { get; set; }
        public int CustomerID { get; set; }
        public int CarID { get; set; }
        public int SalespersonID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalPrice { get; set; }
        public string Notes { get; set; }
    }
}

