using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    public class RoleRepository(AppDbContext context) : AbstractBaseRepository<Role>(context)
    {

        public override async Task<List<Role>> GetAllAsync()
        {
            return await Context.Role.ToListAsync();
        }

        public override async Task<Role?> GetByIdAsync(int id)
        {
            return await Context.Role.FindAsync(id);
        }

        public override async Task<Role> CreateAsync(Role entity)
        {
            await Context.Role.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public override Task<bool> UpdateAsync(int id, Role entity)
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

            Context.Role.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
