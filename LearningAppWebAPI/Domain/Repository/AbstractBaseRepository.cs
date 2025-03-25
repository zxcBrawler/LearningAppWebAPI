using LearningAppWebAPI.Data;

namespace LearningAppWebAPI.Domain.Repository
{
    public abstract class AbstractBaseRepository<TE>(AppDbContext context)
    {

        protected readonly AppDbContext Context = context;

        public abstract Task<List<TE>> GetAllAsync();
        public abstract Task<TE?> GetByIdAsync(int id);
        public abstract Task<TE> CreateAsync(TE entity);
        public abstract Task<bool> UpdateAsync(int id, TE entity);
        public abstract Task<bool> DeleteAsync(int id);
    }
}
