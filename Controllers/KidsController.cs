using Microsoft.AspNetCore.Mvc;
using LifeOrganizerApp.Models;
using LifeOrganizerApp.Data;
using Microsoft.EntityFrameworkCore;
using LifeOrganizerApp.Services;

namespace LifeOrganizerApp.Controllers
{
    public class KidsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly CalendarService _calendarService;

        public KidsController(AppDbContext context, CalendarService calendarService)
        {
            _context = context;
            _calendarService = calendarService;
        }

        private async Task<User> GetCurrentUserAsync()
        {
             return await _context.Users.FirstAsync();
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            
            // Get Kids
            var kids = await _context.Kids.Where(k => k.UserId == user.UserId).ToListAsync();
            
            // Get Kids' Events (Category = School or Kids)
            var allEvents = await _calendarService.GetUpcomingEventsAsync(user.UserId, 14); // 2 weeks
            var kidEvents = allEvents.Where(e => e.Category == "School" || e.Category == "Kids").ToList();

            // Get Chores assigned to kids
            var kidChores = await _context.Chores
                .Include(c => c.AssignedKid)
                .Where(c => c.UserId == user.UserId && c.AssignedToKidId != null)
                .ToListAsync();

            ViewBag.KidEvents = kidEvents;
            ViewBag.KidChores = kidChores;

            return View(kids);
        }

        [HttpPost]
        public async Task<IActionResult> AddKid(string name, int age, string schoolInfo)
        {
            var user = await GetCurrentUserAsync();
            var newKid = new Kid
            {
                UserId = user.UserId,
                Name = name,
                Age = age,
                SchoolInfo = schoolInfo
            };
            _context.Kids.Add(newKid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddChore(string title, int assignedKidId)
        {
            var user = await GetCurrentUserAsync();
            var newChore = new Chore
            {
                UserId = user.UserId,
                Title = title,
                AssignedToKidId = assignedKidId,
                Status = "Pending", 
                Frequency = "Weekly"
            };
            _context.Chores.Add(newChore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        public async Task<IActionResult> CompleteChore(int id)
        {
             var chore = await _context.Chores.FindAsync(id);
             if (chore != null)
             {
                 chore.Status = "Completed";
                 await _context.SaveChangesAsync();
             }
             return RedirectToAction(nameof(Index));
        }
    }
}
