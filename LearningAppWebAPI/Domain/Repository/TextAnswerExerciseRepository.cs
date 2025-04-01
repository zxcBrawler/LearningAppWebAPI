using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    /// <summary>
    /// The text answer exercise repository class
    /// </summary>
    /// <seealso cref="AbstractBaseRepository{TextAnswerExercise}"/>
    [ScopedService]
    public class TextAnswerExerciseRepository(AppDbContext context) : AbstractBaseRepository<TextAnswerExercise, int>(context)
    {
        /// <summary>
        /// Creates the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The entity</returns>
        public override async Task<TextAnswerExercise> CreateAsync(TextAnswerExercise entity)
        {
            await Context.TextAnswerExercises.AddAsync(entity);
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

            Context.TextAnswerExercises.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing a list of text answer exercise</returns>
        public override async Task<List<TextAnswerExercise>> GetAllAsync()
        {
            return await Context.TextAnswerExercises.ToListAsync();
        }

        /// <summary>
        /// Gets the by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the text answer exercise</returns>
        public override async Task<TextAnswerExercise?> GetByIdAsync(int id)
        {
            return await Context.TextAnswerExercises.FindAsync(id);
        }

        /// <summary>
        /// Updates the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="entity">The entity</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A task containing the bool</returns>
        public override Task<bool> UpdateAsync(int id, TextAnswerExercise entity)
        {
            throw new NotImplementedException();
        }
    }
}
