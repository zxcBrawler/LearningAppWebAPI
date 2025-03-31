using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    /// <summary>
    /// The option repository class
    /// </summary>
    /// <seealso cref="AbstractBaseRepository{Option}"/>
    [ScopedService]
    public class OptionRepository(AppDbContext context) : AbstractBaseRepository<Option>(context)
    {
        /// <summary>
        /// Creates the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The entity</returns>
        public override async Task<Option> CreateAsync(Option entity)
        {
            await Context.Options.AddAsync(entity);
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

            Context.Options.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing a list of option</returns>
        public override async Task<List<Option>> GetAllAsync()
        {
            return await Context.Options.ToListAsync();
        }

        /// <summary>
        /// Gets the by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the option</returns>
        public override async Task<Option?> GetByIdAsync(int id)
        {
            return await Context.Options.FindAsync(id);
        }

        /// <summary>
        /// Updates the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="entity">The entity</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A task containing the bool</returns>
        public override Task<bool> UpdateAsync(int id, Option entity)
        {
            throw new NotImplementedException();
        }
    }
}
