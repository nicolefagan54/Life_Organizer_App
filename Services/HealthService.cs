using LifeOrganizerApp.Data;
using LifeOrganizerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeOrganizerApp.Services
{
    public class HealthService
    {
        private readonly AppDbContext _context;

        public HealthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HealthRecord> GetTodayRecordAsync(int userId)
        {
            var record = await _context.HealthRecords
                .FirstOrDefaultAsync(h => h.UserId == userId && h.Date == DateTime.Today);

            if (record == null)
            {
                record = new HealthRecord { UserId = userId, Date = DateTime.Today };
                _context.HealthRecords.Add(record);
                await _context.SaveChangesAsync();
            }

            return record;
        }

        public async Task AddWaterAsync(int userId, int amount)
        {
            var record = await GetTodayRecordAsync(userId);
            record.WaterIntake += amount;
            await _context.SaveChangesAsync();
        }

        public async Task AddStepsAsync(int userId, int steps)
        {
            var record = await GetTodayRecordAsync(userId);
            record.Steps += steps;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMoodAsync(int userId, string mood)
        {
             var record = await GetTodayRecordAsync(userId);
             record.Mood = mood;
             await _context.SaveChangesAsync();
        }
    }
}
