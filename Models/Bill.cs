using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeOrganizerApp.Models
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime DueDate { get; set; }

        public string Category { get; set; } = "General"; // Utility, Rent, etc.

        public string Status { get; set; } = "Unpaid"; // Unpaid, Paid

        public User? User { get; set; }
    }
}
