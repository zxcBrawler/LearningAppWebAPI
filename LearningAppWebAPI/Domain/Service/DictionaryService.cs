using Google.Protobuf.WellKnownTypes;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service;

/// <summary>
/// 
/// </summary>
/// <param name="dictionaryRepository"></param>
[ScopedService]
public class DictionaryService(DictionaryRepository dictionaryRepository)
{
    private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<DataState<List<DictionarySimpleDto>>> GetAllByUserIdAsync(int userId)
    {
        try
        {
            var dictionaries = await dictionaryRepository.GetAllByUserIdAsync(userId);
            return DataState<List<DictionarySimpleDto>>.Success(dictionaries.Select(_mapper.Map<DictionarySimpleDto>).ToList(), StatusCodes.Status200OK);
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
    public async Task<DataState<DictionarySimpleDto>> GetUserDictionaryById(int dictionaryId, int userId)
    {
        try
        {
            var userDictionary = await dictionaryRepository.GetByIdAndUserIdAsync(dictionaryId, userId);
            return userDictionary == null ? DataState<DictionarySimpleDto>.Failure($"Dictionary with id = {dictionaryId} not found for user with id = {userId}", StatusCodes.Status404NotFound) : DataState<DictionarySimpleDto>.Success(_mapper.Map<DictionarySimpleDto>(userDictionary), StatusCodes.Status200OK);
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
    public async Task<DataState<DictionarySimpleDto>> AddNewDictionary(int userId, AddDictionaryRequestDto addDictionaryRequestDto)
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
            return DataState<DictionarySimpleDto>.Success(_mapper.Map<DictionarySimpleDto>(dictionary), StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            return DataState<DictionarySimpleDto>.Failure($"Error adding dictionary: {ex.Message}", StatusCodes.Status500InternalServerError);
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
}