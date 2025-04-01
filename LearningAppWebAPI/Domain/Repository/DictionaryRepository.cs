using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Repository;

[ScopedService]
public class DictionaryRepository(AppDbContext context) : AbstractBaseRepository<Dictionary, int>(context)
{
    public override Task<List<Dictionary>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public override Task<Dictionary?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public override Task<Dictionary> CreateAsync(Dictionary entity)
    {
        throw new NotImplementedException();
    }

    public override Task<bool> UpdateAsync(int id, Dictionary entity)
    {
        throw new NotImplementedException();
    }

    public override Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}