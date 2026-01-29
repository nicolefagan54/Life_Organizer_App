using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LifeOrganizerApp.Models;
using LifeOrganizerApp.Services;
using LifeOrganizerApp.Models.ViewModels;
using LifeOrganizerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeOrganizerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HealthService _healthService;
        private readonly CalendarService _calendarService;
        private readonly NotificationService _notificationService;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, 
            HealthService healthService, 
            CalendarService calendarService, 
            NotificationService notificationService,
            AppDbContext context)
        {
            _logger = logger;
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
                TodayTasks = await _calendarService.GetDueTasksAsync(user.UserId, 1), // Tasks due today or overdue
                UpcomingEvents = await _calendarService.GetUpcomingEventsAsync(user.UserId, 3), // Next 3 days events
                Notifications = await _notificationService.GetDailySummaryAsync(user.UserId)
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
