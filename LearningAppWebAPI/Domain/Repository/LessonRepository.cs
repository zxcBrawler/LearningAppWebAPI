using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    public class LessonRepository(AppDbContext context) : AbstractBaseRepository<Lesson>(context)
    {
        public override async Task<Lesson> CreateAsync(Lesson entity)
        {
            await Context.Lesson.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            Context.Lesson.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        public override async Task<List<Lesson>> GetAllAsync()
        {
            return await Context.Lesson.Include(e => e.Exercises).ToListAsync();
        }

        public override async Task<Lesson?> GetByIdAsync(int id)
        {
            return await Context.Lesson.FindAsync(id);
        }

        public override Task<bool> UpdateAsync(int id, Lesson entity)
        {
            throw new NotImplementedException();
        }
    }
}
