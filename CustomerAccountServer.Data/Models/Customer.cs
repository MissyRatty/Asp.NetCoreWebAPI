using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAccountServer.Data.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(50, ErrorMessage = "Customer Name can't be longer than 50 characters")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Created Date is required")]
        public DateTime CustomerCreatedDateTime { get; set; }
    }
}
