using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    public class TrueFalseExerciseRepository(AppDbContext context) : AbstractBaseRepository<TrueFalseExercise>(context)
    {
        public override async Task<TrueFalseExercise> CreateAsync(TrueFalseExercise entity)
        {
            await Context.True_False_Exercises.AddAsync(entity);
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

            Context.True_False_Exercises.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        public override async Task<List<TrueFalseExercise>> GetAllAsync()
        {
            return await Context.True_False_Exercises.ToListAsync();
        }

        public override async Task<TrueFalseExercise?> GetByIdAsync(int id)
        {
            return await Context.True_False_Exercises.FindAsync(id);
        }

        public override Task<bool> UpdateAsync(int id, TrueFalseExercise entity)
        {
            throw new NotImplementedException();
        }
    }
}
