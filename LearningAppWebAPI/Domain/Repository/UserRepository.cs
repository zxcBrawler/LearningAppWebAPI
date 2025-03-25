using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    public class UserRepository(AppDbContext context) : AbstractBaseRepository<User>(context)
    {

        public override async Task<List<User>> GetAllAsync()
        {
            return await Context.User
               .Include(u => u.Role)
               .Include(u => u.Courses)
               .ToListAsync();
        }

        public override async Task<User?> GetByIdAsync(int id)
        {
            return await Context.User.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
        }


        public override async Task<User> CreateAsync(User entity)
        {
            await Context.User.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public override async Task<bool> UpdateAsync(int id, User entity)
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
                else
                {
                    throw;
                }
            }

            return true;
        }

        public override async Task<bool> DeleteAsync(int id)
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

        private bool UserExists(int id)
        {
            return Context.User.Any(u => u.Id == id);
        }
    }
}
