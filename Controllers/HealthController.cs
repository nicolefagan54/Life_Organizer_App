using Microsoft.AspNetCore.Mvc;
using LifeOrganizerApp.Models;
using LifeOrganizerApp.Services;
using LifeOrganizerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeOrganizerApp.Controllers
{
    public class HealthController : Controller
    {
        private readonly HealthService _healthService;
        private readonly AppDbContext _context;

        public HealthController(HealthService healthService, AppDbContext context)
        {
            _healthService = healthService;
            _context = context;
        }

        private async Task<User> GetCurrentUserAsync()
        {
            // simplified user retrieval
            return await _context.Users.FirstAsync();
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var todayRecord = await _healthService.GetTodayRecordAsync(user.UserId);
            
            // Get last 7 days history
            var history = await _context.HealthRecords
                .Where(h => h.UserId == user.UserId)
                .OrderByDescending(h => h.Date)
                .Take(7)
                .ToListAsync();

            ViewBag.History = history;

            return View(todayRecord);
        }

        [HttpPost]
        public async Task<IActionResult> LogWater()
        {
            var user = await GetCurrentUserAsync();
            await _healthService.AddWaterAsync(user.UserId, 1);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSteps(int steps)
        {
            var user = await GetCurrentUserAsync();
            // This adds to existing, maybe we want to set total? The service adds.
            // Let's assume input is total for day for simplicity in this specific action, 
            // OR input is "added steps". Service implements "Add". 
            // check service: record.Steps += steps;
            // The UI might send "total steps from device" vs "added steps".
            // For manual entry, "add" makes sense.
            await _healthService.AddStepsAsync(user.UserId, steps);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SetMood(string mood)
        {
            var user = await GetCurrentUserAsync();
            await _healthService.UpdateMoodAsync(user.UserId, mood);
            return RedirectToAction(nameof(Index));
        }
    }
}
