using Microsoft.AspNetCore.Mvc;
using LifeOrganizerApp.Services;
using LifeOrganizerApp.Models;
using LifeOrganizerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeOrganizerApp.Controllers
{
    public class WorkController : Controller
    {
        private readonly TaskService _taskService;
        private readonly CalendarService _calendarService;
        private readonly AppDbContext _context;

        public WorkController(TaskService taskService, CalendarService calendarService, AppDbContext context)
        {
            _taskService = taskService;
            _calendarService = calendarService;
            _context = context;
        }

        private async Task<User> GetCurrentUserAsync()
        {
             return await _context.Users.FirstAsync();
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var allTasks = await _taskService.GetTasksAsync(user.UserId);
            
            // Filter for Work tasks
            var workTasks = allTasks.Where(t => t.Category == "Work" && !t.IsCompleted).ToList();
            var completedTasks = allTasks.Where(t => t.Category == "Work" && t.IsCompleted).OrderByDescending(t => t.DueDate).Take(5).ToList();

            ViewBag.CompletedTasks = completedTasks;

            // Get upcoming work meetings (Events with Category 'Work')
            var upcomingMeetings = await _calendarService.GetUpcomingEventsAsync(user.UserId, 7);
            ViewBag.Meetings = upcomingMeetings.Where(e => e.Category == "Work").ToList();

            return View(workTasks);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(string title, DateTime? dueDate, string priority)
        {
            var user = await GetCurrentUserAsync();
            var newTask = new AppTask
            {
                UserId = user.UserId,
                Title = title,
                Category = "Work",
                DueDate = dueDate,
                Priority = priority ?? "Medium",
                IsCompleted = false
            };

            await _taskService.AddTaskAsync(newTask);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var user = await GetCurrentUserAsync();
            var task = await _taskService.GetTaskByIdAsync(id, user.UserId);
            if (task != null)
            {
                task.IsCompleted = true;
                await _taskService.UpdateTaskAsync(task);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
