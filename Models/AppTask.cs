using System;
using System.ComponentModel.DataAnnotations;

namespace LifeOrganizerApp.Models
{
    public class AppTask
    {
        [Key]
        public int TaskId { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        public string Category { get; set; } = "General"; // Work, Home, etc.
        
        public DateTime? DueDate { get; set; }
        
        public string Priority { get; set; } = "Medium"; // Low, Medium, High
        
        public bool IsCompleted { get; set; } = false;
        
        public User? User { get; set; }
    }
}
