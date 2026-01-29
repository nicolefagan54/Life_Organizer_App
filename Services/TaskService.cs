using LifeOrganizerApp.Data;
using LifeOrganizerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeOrganizerApp.Services
{
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppTask>> GetTasksAsync(int userId)
        {
             return await _context.Tasks
                .Where(t => t.UserId == userId)
                .OrderBy(t => t.DueDate)
                .ToListAsync();
        }

        public async Task<AppTask?> GetTaskByIdAsync(int taskId, int userId)
        {
            return await _context.Tasks
                .FirstOrDefaultAsync(t => t.TaskId == taskId && t.UserId == userId);
        }

        public async Task AddTaskAsync(AppTask task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(AppTask task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
