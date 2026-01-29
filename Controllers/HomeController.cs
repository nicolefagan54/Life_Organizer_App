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
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        private async Task<User> GetCurrentUserAsync()
        {
             return await _context.Users.FirstAsync();
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            
            // Get Bills
            var bills = await _context.Bills
                .Where(b => b.UserId == user.UserId)
                .OrderBy(b => b.DueDate)
                .ToListAsync();

            // Get Household Chores (Not assigned to specific kid)
            var houseChores = await _context.Chores
                .Where(c => c.UserId == user.UserId && c.AssignedToKidId == null)
                .OrderByDescending(c => c.ChoreId)
                .ToListAsync();

            ViewBag.Bills = bills;
            ViewBag.Chores = houseChores;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBill(string title, decimal amount, DateTime dueDate, string category)
        {
            var user = await GetCurrentUserAsync();
            var bill = new Bill
            {
                UserId = user.UserId,
                Title = title,
                Amount = amount,
                DueDate = dueDate,
                Category = category,
                Status = "Unpaid"
            };
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> PayBill(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            if (bill != null)
            {
                bill.Status = "Paid";
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddChore(string title)
        {
            var user = await GetCurrentUserAsync();
            var chore = new Chore
            {
                UserId = user.UserId,
                Title = title,
                AssignedToKidId = null, // Household chore
                Status = "Pending",
                Frequency = "Weekly"
            };
            _context.Chores.Add(chore);
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
