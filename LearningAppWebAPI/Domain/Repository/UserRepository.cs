using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    [ScopedService]
    public class UserRepository(AppDbContext context) : AbstractBaseRepository<User, long>(context)
    {

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing a list of user</returns>
        public override async Task<List<User>> GetAllAsync()
        {
            return await Context.User
               .Include(u => u.Role)
               .Include(u => u.Courses)
               .ToListAsync();
        }

        /// <summary>
        /// Gets the by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the user</returns>
        public override async Task<User?> GetByIdAsync(long id)
        {
            return await Context.User.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
        }


        /// <summary>
        /// Creates the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The entity</returns>
        public override async Task<User> CreateAsync(User entity)
        {
            await Context.User.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="entity">The entity</param>
        /// <returns>A task containing the bool</returns>
        public override async Task<bool> UpdateAsync(long id, User entity)
        {
            if (id != entity.Id)
            {
                return false;
            }
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!UserExists(id))
                {
                    return false;
                }
                throw;
            }

            return true;
        }

        /// <summary>
        /// Deletes the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the bool</returns>
        public override async Task<bool> DeleteAsync(long id)
        {
            var user = await GetByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            Context.User.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Users the exists using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The bool</returns>
        private bool UserExists(long id)
        {
            return Context.User.Any(u => u.Id == id);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await Context.User.Include(r => r.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public  async Task<Role?> GetByRoleIdAsync(int id)
        {
            return await Context.Role.FindAsync(id);
        }
    }
}
