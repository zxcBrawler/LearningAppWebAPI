using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    public class TextAnswerExerciseRepository(AppDbContext context) : AbstractBaseRepository<TextAnswerExercise>(context)
    {
        public override async Task<TextAnswerExercise> CreateAsync(TextAnswerExercise entity)
        {
            await Context.Text_Answer_Exercises.AddAsync(entity);
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

            Context.Text_Answer_Exercises.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        public override async Task<List<TextAnswerExercise>> GetAllAsync()
        {
            return await Context.Text_Answer_Exercises.ToListAsync();
        }

        public override async Task<TextAnswerExercise?> GetByIdAsync(int id)
        {
            return await Context.Text_Answer_Exercises.FindAsync(id);
        }

        public override Task<bool> UpdateAsync(int id, TextAnswerExercise entity)
        {
            throw new NotImplementedException();
        }
    }
}
