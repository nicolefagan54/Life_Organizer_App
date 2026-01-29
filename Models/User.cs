using System;
using System.ComponentModel.DataAnnotations;

namespace LifeOrganizerApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        public string PasswordHash { get; set; } = string.Empty;
        
        // Navigation properties
        // public List<Task> Tasks { get; set; }
    }
}
