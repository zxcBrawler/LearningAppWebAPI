using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    public class OptionRepository(AppDbContext context) : AbstractBaseRepository<Option>(context)
    {
        public override async Task<Option> CreateAsync(Option entity)
        {
            await Context.Options.AddAsync(entity);
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

            Context.Options.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        public override async Task<List<Option>> GetAllAsync()
        {
            return await Context.Options.ToListAsync();
        }

        public override async Task<Option?> GetByIdAsync(int id)
        {
            return await Context.Options.FindAsync(id);
        }

        public override Task<bool> UpdateAsync(int id, Option entity)
        {
            throw new NotImplementedException();
        }
    }
}
