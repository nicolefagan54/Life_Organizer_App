using LifeOrganizerApp.Data;
using LifeOrganizerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeOrganizerApp.Services
{
    public class CalendarService
    {
        private readonly AppDbContext _context;

        public CalendarService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetUpcomingEventsAsync(int userId, int days = 7)
        {
            var events = await _context.Events
                .Where(e => e.UserId == userId && e.Date >= DateTime.Today && e.Date <= DateTime.Today.AddDays(days))
                .OrderBy(e => e.Date)
                .ToListAsync();
            
            // Perform time sorting in memory since SQLite EF Core provider struggles with TimeSpan ordering
            return events.OrderBy(e => e.Date).ThenBy(e => e.Time).ToList();
        }

        public async Task<List<AppTask>> GetDueTasksAsync(int userId, int days = 7)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId && !t.IsCompleted && t.DueDate.HasValue && t.DueDate.Value >= DateTime.Today && t.DueDate.Value <= DateTime.Today.AddDays(days))
                .OrderBy(t => t.DueDate)
                .ToListAsync();
        }
    }
}
