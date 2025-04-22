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
    public override async Task<Word> CreateAsync(Word entity)
    {
        await Context.Word.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="partOfSpeech"></param>
    /// <returns></returns>
    public async Task<Word?> GetByValueAndPartOfSpeech(string value, string partOfSpeech)
    {
        return await Context.Word.Where(v => v.WordValue == value && v.PartOfSpeech == partOfSpeech).FirstOrDefaultAsync();
    }
}