using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LifeOrganizerApp.Models;
using LifeOrganizerApp.Services;
using LifeOrganizerApp.Models.ViewModels;
using LifeOrganizerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeOrganizerApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HealthService _healthService;
        private readonly CalendarService _calendarService;
        private readonly NotificationService _notificationService;
        private readonly AppDbContext _context;

        public DashboardController(
            HealthService healthService, 
            CalendarService calendarService, 
            NotificationService notificationService,
            AppDbContext context)
        {
            _healthService = healthService;
            _calendarService = calendarService;
            _notificationService = notificationService;
            _context = context;
        }

        private async Task<User> GetOrCreateDefaultUserAsync()
        {
            var user = await _context.Users.FirstOrDefaultAsync();
            if (user == null)
            {
                user = new User
                {
                    Name = "Demo User",
                    Email = "demo@example.com",
                    PasswordHash = "hashed_pw" // simplified
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetOrCreateDefaultUserAsync();
            
            var viewModel = new DashboardViewModel
            {
                User = user,
                TodayHealth = await _healthService.GetTodayRecordAsync(user.UserId),
                TodayTasks = await _calendarService.GetDueTasksAsync(user.UserId, 1), 
                UpcomingEvents = await _calendarService.GetUpcomingEventsAsync(user.UserId, 3), 
                Notifications = await _notificationService.GetDailySummaryAsync(user.UserId)
            };

            return View(viewModel);
        }
    }
}
