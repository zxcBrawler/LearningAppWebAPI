using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    public class TypeExerciseRepository(AppDbContext context) : AbstractBaseRepository<TypeExercise>(context)
    {
        public override async Task<TypeExercise> CreateAsync(TypeExercise entity)
        {
            await Context.Type_Exercise.AddAsync(entity);
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

            Context.Type_Exercise.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        public override async Task<List<TypeExercise>> GetAllAsync()
        {
            return await Context.Type_Exercise.ToListAsync();
        }

        public override async Task<TypeExercise?> GetByIdAsync(int id)
        {
            return await Context.Type_Exercise.FindAsync(id);
        }

        public override Task<bool> UpdateAsync(int id, TypeExercise entity)
        {
            throw new NotImplementedException();
        }
    }
}
