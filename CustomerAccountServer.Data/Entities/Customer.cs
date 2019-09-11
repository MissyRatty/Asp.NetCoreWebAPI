using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAccountServer.Data.Entities
{
    [Table("Customer")]
    public class Customer : IEntity
    {
        [Key]
        [Column("CustomerId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(50, ErrorMessage = "Customer Name can't be longer than 50 characters")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Created Date is required")]
        public DateTime CustomerCreatedDateTime { get; set; }
    }
}
