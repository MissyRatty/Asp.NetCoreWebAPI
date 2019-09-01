﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAccountServer.Data.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Account Number is required")]
        [StringLength(50, ErrorMessage = "Account Number can't be longer than 50 characters")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Created Date is required")]
        public DateTime AccountCreatedDateTime { get; set; }

        [Required(ErrorMessage = "Customer Id is required")]
        public int CustomerId { get; set; }
    }
}
