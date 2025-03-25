using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    public class ExerciseRepository(AppDbContext context) : AbstractBaseRepository<Exercise>(context)
    {
        public override async Task<Exercise> CreateAsync(Exercise entity)
        {
            await Context.Exercises.AddAsync(entity);
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

            Context.Exercises.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        public override async Task<List<Exercise>> GetAllAsync()
        {
            return await Context.Exercises.ToListAsync();
        }

        public override async Task<Exercise?> GetByIdAsync(int id)
        {
            return await Context.Exercises.FindAsync(id);
        }

        public override Task<bool> UpdateAsync(int id, Exercise entity)
        {
            throw new NotImplementedException();
        }
    }
}
