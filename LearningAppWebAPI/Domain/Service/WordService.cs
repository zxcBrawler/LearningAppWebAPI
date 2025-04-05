using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models.DTO.Simple;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service;

/// <summary>
/// 
/// </summary>
/// <param name="wordRepository"></param>
[ScopedService]
public class WordService(WordRepository wordRepository)
{
    private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<DataState<List<WordSimpleDto>>> GetAllAsync()
    {
        try
        {
            var words = await wordRepository.GetAllAsync();
            return DataState<List<WordSimpleDto>>.Success(words.Select(_mapper.Map<WordSimpleDto>).ToList(), StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            return DataState<List<WordSimpleDto>>.Failure($"Error getting all words: {ex.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="wordId"></param>
    /// <returns></returns>
    public async Task<DataState<WordSimpleDto>> GetWordByIdAsync(int wordId)
    {
        try
        {
            var word = await wordRepository.GetByIdAsync(wordId);
            return word == null ? DataState<WordSimpleDto>.Failure($"No word found with id: {wordId}", StatusCodes.Status404NotFound) : DataState<WordSimpleDto>.Success(_mapper.Map<WordSimpleDto>(word), StatusCodes.Status200OK);
        }
        catch (Exception e)
        {
            return DataState<WordSimpleDto>.Failure($"Error getting word: {e.Message}", StatusCodes.Status500InternalServerError);
        }
    }
}