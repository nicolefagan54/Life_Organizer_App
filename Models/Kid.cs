using System;
using System.ComponentModel.DataAnnotations;

namespace LifeOrganizerApp.Models
{
    public class Kid
    {
        [Key]
        public int KidId { get; set; }
        
        [Required]
        public int UserId { get; set; } // Parent
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public int Age { get; set; }
        
        public string SchoolInfo { get; set; } = string.Empty;
        
        public User? Parent { get; set; }
    }
}
