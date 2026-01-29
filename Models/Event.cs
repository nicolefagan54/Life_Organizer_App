using System;
using System.ComponentModel.DataAnnotations;

namespace LifeOrganizerApp.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        public string Category { get; set; } = "General";
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public TimeSpan Time { get; set; }
        
        public User? User { get; set; }
    }
}
