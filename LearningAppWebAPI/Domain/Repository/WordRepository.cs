using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Utils.CustomAttributes;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository;

/// <summary>
/// 
/// </summary>
/// <param name="context"></param>
[ScopedService]
public class WordRepository(AppDbContext context) : AbstractBaseRepository<Word, int>(context)
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override async Task<List<Word>> GetAllAsync()
    {
        return await Context.Word.ToListAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public override async Task<Word?> GetByIdAsync(int id)
    {
        return await Context.Word.FirstOrDefaultAsync(w => w.Id == id);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override Task<Word> CreateAsync(Word entity)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override Task<bool> UpdateAsync(int id, Word entity)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}