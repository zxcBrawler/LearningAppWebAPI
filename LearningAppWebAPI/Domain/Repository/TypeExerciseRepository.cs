using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    /// <summary>
    /// The type exercise repository class
    /// </summary>
    /// <seealso cref="AbstractBaseRepository{TypeExercise}"/>
    public class TypeExerciseRepository(AppDbContext context) : AbstractBaseRepository<TypeExercise>(context)
    {
        /// <summary>
        /// Creates the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The entity</returns>
        public override async Task<TypeExercise> CreateAsync(TypeExercise entity)
        {
            await Context.TypeExercise.AddAsync(entity);
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

            Context.TypeExercise.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing a list of type exercise</returns>
        public override async Task<List<TypeExercise>> GetAllAsync()
        {
            return await Context.TypeExercise.ToListAsync();
        }

        /// <summary>
        /// Gets the by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the type exercise</returns>
        public override async Task<TypeExercise?> GetByIdAsync(int id)
        {
            return await Context.TypeExercise.FindAsync(id);
        }

        /// <summary>
        /// Updates the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="entity">The entity</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A task containing the bool</returns>
        public override Task<bool> UpdateAsync(int id, TypeExercise entity)
        {
            throw new NotImplementedException();
        }
    }
}
