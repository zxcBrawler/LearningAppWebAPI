using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    /// <summary>
    /// The true false exercise repository class
    /// </summary>
    /// <seealso cref="AbstractBaseRepository{TrueFalseExercise}"/>
    [ScopedService]
    public class TrueFalseExerciseRepository(AppDbContext context) : AbstractBaseRepository<TrueFalseExercise>(context)
    {
        /// <summary>
        /// Creates the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The entity</returns>
        public override async Task<TrueFalseExercise> CreateAsync(TrueFalseExercise entity)
        {
            await Context.TrueFalseExercises.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Deletes the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the bool</returns>
        public override async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            Context.TrueFalseExercises.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing a list of true false exercise</returns>
        public override async Task<List<TrueFalseExercise>> GetAllAsync()
        {
            return await Context.TrueFalseExercises.ToListAsync();
        }

        /// <summary>
        /// Gets the by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the true false exercise</returns>
        public override async Task<TrueFalseExercise?> GetByIdAsync(int id)
        {
            return await Context.TrueFalseExercises.FindAsync(id);
        }

        /// <summary>
        /// Updates the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="entity">The entity</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A task containing the bool</returns>
        public override Task<bool> UpdateAsync(int id, TrueFalseExercise entity)
        {
            throw new NotImplementedException();
        }
    }
}
