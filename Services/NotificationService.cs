using LifeOrganizerApp.Data;
using LifeOrganizerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeOrganizerApp.Services
{
    public class NotificationService
    {
        private readonly AppDbContext _context;

        public NotificationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetDailySummaryAsync(int userId)
        {
            var alerts = new List<string>();

            // Check tasks due today
            var tasksToday = await _context.Tasks.CountAsync(t => t.UserId == userId && !t.IsCompleted && t.DueDate == DateTime.Today);
            if (tasksToday > 0) alerts.Add($"You have {tasksToday} tasks due today.");

            // Check health goals (pseudo-check)
            var health = await _context.HealthRecords.FirstOrDefaultAsync(h => h.UserId == userId && h.Date == DateTime.Today);
            if (health != null && health.WaterIntake < 8) alerts.Add($"Drink more water! You have only had {health.WaterIntake} glasses.");

            return alerts;
        }
    }
}
