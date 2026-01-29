using LifeOrganizerApp.Models;

namespace LifeOrganizerApp.Models.ViewModels
{
    public class DashboardViewModel
    {
        public User? User { get; set; }
        public HealthRecord? TodayHealth { get; set; }
        public List<AppTask> TodayTasks { get; set; } = new();
        public List<Event> UpcomingEvents { get; set; } = new();
        public List<string> Notifications { get; set; } = new();
    }
}
