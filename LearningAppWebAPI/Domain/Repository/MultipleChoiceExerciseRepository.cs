using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    /// <summary>
    /// The multiple choice exercise repository class
    /// </summary>
    /// <seealso cref="AbstractBaseRepository{MultipleChoiceExercise}"/>
    [ScopedService]
    public class MultipleChoiceExerciseRepository(AppDbContext context) : AbstractBaseRepository<MultipleChoiceExercise>(context)
    {
        /// <summary>
        /// Creates the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A task containing the multiple choice exercise</returns>
        public override Task<MultipleChoiceExercise> CreateAsync(MultipleChoiceExercise entity)
        {
            throw new NotImplementedException();
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

            Context.MultipleChoiceExercises.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing a list of multiple choice exercise</returns>
        public override async Task<List<MultipleChoiceExercise>> GetAllAsync()
        {
            return await Context.MultipleChoiceExercises.Include(o => o.Options).ToListAsync();
        }

        /// <summary>
        /// Gets the by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the multiple choice exercise</returns>
        public override async Task<MultipleChoiceExercise?> GetByIdAsync(int id)
        {
            return await Context.MultipleChoiceExercises.FindAsync(id);
        }

        /// <summary>
        /// Updates the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="entity">The entity</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A task containing the bool</returns>
        public override Task<bool> UpdateAsync(int id, MultipleChoiceExercise entity)
        {
            throw new NotImplementedException();
        }
    }
}
