using System;
using System.ComponentModel.DataAnnotations;

namespace LifeOrganizerApp.Models
{
    public class HealthRecord
    {
        [Key]
        public int HealthId { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;
        
        public int Steps { get; set; }
        
        public int WaterIntake { get; set; } // in glasses or ml
        
        public double SleepHours { get; set; }
        
        public string Mood { get; set; } = string.Empty; // Happy, Tired, Stressed, etc.
        
        public User? User { get; set; }
    }
}
