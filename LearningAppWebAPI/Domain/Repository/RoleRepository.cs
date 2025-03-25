using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    /// <summary>
    /// The role repository class
    /// </summary>
    /// <seealso cref="AbstractBaseRepository{Role}"/>
    public class RoleRepository(AppDbContext context) : AbstractBaseRepository<Role>(context)
    {

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing a list of role</returns>
        public override async Task<List<Role>> GetAllAsync()
        {
            return await Context.Role.ToListAsync();
        }

        /// <summary>
        /// Gets the by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the role</returns>
        public override async Task<Role?> GetByIdAsync(int id)
        {
            return await Context.Role.FindAsync(id);
        }

        /// <summary>
        /// Creates the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The entity</returns>
        public override async Task<Role> CreateAsync(Role entity)
        {
            await Context.Role.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="entity">The entity</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A task containing the bool</returns>
        public override Task<bool> UpdateAsync(int id, Role entity)
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

            Context.Role.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
