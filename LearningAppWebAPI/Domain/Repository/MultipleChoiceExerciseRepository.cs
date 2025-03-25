using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    public class MultipleChoiceExerciseRepository(AppDbContext context) : AbstractBaseRepository<MultipleChoiceExercise>(context)
    {
        public override Task<MultipleChoiceExercise> CreateAsync(MultipleChoiceExercise entity)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            Context.Multiple_Choice_Exercises.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        public override async Task<List<MultipleChoiceExercise>> GetAllAsync()
        {
            return await Context.Multiple_Choice_Exercises.Include(o => o.Options).ToListAsync();
        }

        public override async Task<MultipleChoiceExercise?> GetByIdAsync(int id)
        {
            return await Context.Multiple_Choice_Exercises.FindAsync(id);
        }

        public override Task<bool> UpdateAsync(int id, MultipleChoiceExercise entity)
        {
            throw new NotImplementedException();
        }
    }
}
