using System;
using System.ComponentModel.DataAnnotations;

namespace LifeOrganizerApp.Models
{
    public class Chore
    {
        [Key]
        public int ChoreId { get; set; }
        
        [Required]
        public int UserId { get; set; } // Owner/Parent
        
        public int? AssignedToKidId { get; set; } // Optional assignment to kid
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        public string Frequency { get; set; } = "Daily"; // Daily, Weekly
        
        public string Status { get; set; } = "Pending";
        
        public User? User { get; set; }
        public Kid? AssignedKid { get; set; }
    }
}
