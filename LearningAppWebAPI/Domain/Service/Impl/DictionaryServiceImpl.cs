using AutoMapper;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Impl;

/// <summary>
/// 
/// </summary>
/// <param name="dictionaryRepository"></param>
public class DictionaryServiceImpl(DictionaryRepository dictionaryRepository, WordRepository wordRepository, IMapper mapper) : IDictionaryService
{
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<DataState<List<DictionarySimpleDto>>> GetAllByUserIdAsync(long userId)
    {
        try
        {
            var dictionaries = await dictionaryRepository.GetAllByUserIdAsync(userId);
            return DataState<List<DictionarySimpleDto>>.Success(dictionaries.Select(mapper.Map<DictionarySimpleDto>).ToList(), StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return DataState<List<DictionarySimpleDto>>.Failure($"Error getting dictionary: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dictionaryId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<DataState<DictionarySimpleDto>> GetUserDictionaryById(int dictionaryId, long userId)
    {
        try
        {
            var userDictionary = await dictionaryRepository.GetByIdAndUserIdAsync(dictionaryId, userId);
            return userDictionary == null ? DataState<DictionarySimpleDto>.Failure($"Dictionary with id = {dictionaryId} not found for user with id = {userId}", StatusCodes.Status404NotFound) : DataState<DictionarySimpleDto>.Success(mapper.Map<DictionarySimpleDto>(userDictionary), StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return DataState<DictionarySimpleDto>.Failure($"Error getting dictionary with id = {dictionaryId}: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
       
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="addDictionaryRequestDto"></param>
    /// <returns></returns>
    public async Task<DataState<DictionarySimpleDto>> AddNewDictionary(long userId, AddDictionaryRequestDto addDictionaryRequestDto)
    {
        try
        {
            Dictionary dictionary = new()
            {
                DictionaryName = addDictionaryRequestDto.DictionaryName,
                ImageUrl = addDictionaryRequestDto.ImageUrl,
                UserId = userId,
            };

            await dictionaryRepository.CreateAsync(dictionary);
            return DataState<DictionarySimpleDto>.Success(mapper.Map<DictionarySimpleDto>(dictionary), StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            return DataState<DictionarySimpleDto>.Failure($"Error adding dictionary: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="dictionaryId"></param>
    /// <param name="updateDictionaryRequestDto"></param>
    /// <returns></returns>
    public async Task<DataState<bool>> UpdateDictionary(long userId, int dictionaryId, UpdateDictionaryRequestDto updateDictionaryRequestDto)
    {
        try
        {   
            var dictionary = await dictionaryRepository.GetByIdAndUserIdAsync(dictionaryId, userId);
            if (dictionary == null)
            {
                return DataState<bool>.Failure($"Dictionary with id = {dictionaryId} not found for user with id = {userId}", StatusCodes.Status404NotFound);
            }
            dictionary.DictionaryName = updateDictionaryRequestDto.DictionaryName;
            dictionary.ImageUrl = updateDictionaryRequestDto.ImageUrl;
            await dictionaryRepository.UpdateAsync(dictionaryId ,dictionary);
            return DataState<bool>.Success(true, StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return DataState<bool>.Failure($"Error updating dictionary: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<DataState<bool>> DeleteDictionaryAsync(int id)
    {
        try
        {
            var deleteResult = await dictionaryRepository.DeleteAsync(id);
            return !deleteResult ? DataState<bool>.Failure("Dictionary deletion failed.", StatusCodes.Status400BadRequest) : DataState<bool>.Success(true, StatusCodes.Status204NoContent);
        }
        catch (Exception ex)
        {
            return DataState<bool>.Failure($"Error deleting dictionary with ID {id}: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="dictionaryId"></param>
    /// <param name="wordId"></param>
    /// <returns></returns>
    public async Task<DataState<DictionarySimpleDto>> AddWordToDictionary(long userId, int dictionaryId, int wordId)
    {
        try
        {
            var dictionary = await dictionaryRepository.GetByIdAndUserIdAsync(dictionaryId, userId);
            if (dictionary == null)
            {
                return DataState<DictionarySimpleDto>.Failure(
                    $"Dictionary with id = {dictionaryId} not found for user with id = {userId}",
                    StatusCodes.Status404NotFound);
            }
            
            var word = await wordRepository.GetByIdAsync(wordId);
            if (word == null)
            {
                return DataState<DictionarySimpleDto>.Failure(
                    $"Word with id = {wordId} not found",
                    StatusCodes.Status404NotFound);
            }
            if (dictionary.Words?.Any(w => w.Id == wordId) ?? false)
            {
                return DataState<DictionarySimpleDto>.Failure(
                    $"Word with id = {wordId} already exists in dictionary with id = {dictionaryId}",
                    StatusCodes.Status400BadRequest);
            }
            dictionary.Words ??= [];
            dictionary.Words?.Add(word);
            await dictionaryRepository.UpdateAsync(dictionaryId ,dictionary);
            return DataState<DictionarySimpleDto>.Success(mapper.Map<DictionarySimpleDto>(dictionary), StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            return DataState<DictionarySimpleDto>.Failure($"An error occured: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }
}