﻿using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Utils.CustomAttributes;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository;

/// <summary>
/// 
/// </summary>
/// <param name="context"></param>
[ScopedService]
public class DictionaryRepository(AppDbContext context) : AbstractBaseRepository<Dictionary, int>(context)
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override async Task<List<Dictionary>> GetAllAsync()
    {
        return await Context.Dictionary.ToListAsync();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<List<Dictionary>> GetAllByUserIdAsync(int userId)
    {
        return await Context.Dictionary.Where(d => d.UserId == userId).ToListAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public override async Task<Dictionary?> GetByIdAsync(int id)
    {
        return await Context.Dictionary.FirstOrDefaultAsync(d => d.Id == id);
    }
    public  async Task<Dictionary?> GetByIdAndUserIdAsync(int dictionaryId, int userId)
    {
        return await Context.Dictionary.Where(d => d.Id == dictionaryId && d.UserId == userId).FirstOrDefaultAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public override async Task<Dictionary> CreateAsync(Dictionary entity)
    {
        await Context.Dictionary.AddAsync(entity);
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
    public override Task<bool> UpdateAsync(int id, Dictionary entity)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public override async Task<bool> DeleteAsync(int id)
    {
        var dictionary = await GetByIdAsync(id);

        if (dictionary == null)
        {
            return false;
        }

        Context.Dictionary.Remove(dictionary);
        await Context.SaveChangesAsync();
        return true;
    }
}