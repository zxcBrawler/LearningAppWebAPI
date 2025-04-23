using System.Text;
using AutoMapper;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Response;
using LearningAppWebAPI.Models.DTO.Simple;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service.Impl;

/// <summary>
/// 
/// </summary>
/// <param name="wordRepository"></param>
public class WordServiceImpl(WordRepository wordRepository, IMapper mapper, DictionaryRepository dictionaryRepository) : IWordService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<DataState<List<WordSimpleDto>>> GetAllAsync()
    {
        try
        {
            var words = await wordRepository.GetAllAsync();
            return DataState<List<WordSimpleDto>>.Success(words.Select(mapper.Map<WordSimpleDto>).ToList(), StatusCodes.Status200OK);
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
            return word == null ? DataState<WordSimpleDto>.Failure($"No word found with id: {wordId}", StatusCodes.Status404NotFound) : DataState<WordSimpleDto>.Success(mapper.Map<WordSimpleDto>(word), StatusCodes.Status200OK);
        }
        catch (Exception e)
        {
            return DataState<WordSimpleDto>.Failure($"Error getting word: {e.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="word"></param>
    /// <param name="dictionaryId"></param>
    /// <returns></returns>
    public async Task<DataState<WordSimpleDto>> AddWord(MerriamWebsterResponseDto word, int dictionaryId, long userId)
    {
        try
        {
            var existedWord = await wordRepository.GetByValueAndPartOfSpeech(word.Headword, word.PartOfSpeech);
            if (existedWord != null)
            {
            }
            else
            {
                var newWord = new Word
                {
                    WordValue = word.Headword,
                    WordDefinition = word.ShortDefinitions.Aggregate((current, next) => $"{current}; {next}"),
                    LanguageLevel = GenerateRandomLanguageLevel(),
                    PartOfSpeech = word.PartOfSpeech,
                    
                };
                if (word.Pronunciation != null)
                {
                    newWord.WordPronunciation = word.Pronunciation.Pronunciation;
                    newWord.WordPronunciationAudio = word.Pronunciation.AudioLink.ToString();
                }
                
                existedWord = await wordRepository.CreateAsync(newWord);
            }
           
            
            var dictionary = await dictionaryRepository.GetByIdAndUserIdAsync(dictionaryId, userId);
            if (dictionary == null)
            {
                return DataState<WordSimpleDto>.Failure(
                    $"Dictionary with id = {dictionaryId} not found for user with id = {userId}",
                    StatusCodes.Status404NotFound);
            }
            
            if (dictionary.Words?.Any(w => w.Id == existedWord.Id) ?? false)
            {
                return DataState<WordSimpleDto>.Failure(
                    $"Word with id = {existedWord.Id} already exists in dictionary with id = {dictionaryId}",
                    StatusCodes.Status400BadRequest);
            }
            dictionary.Words ??= [];
            dictionary.Words?.Add(existedWord);
            await dictionaryRepository.UpdateAsync(dictionaryId ,dictionary);
            return DataState<WordSimpleDto>.Success(mapper.Map<WordSimpleDto>(existedWord), StatusCodes.Status201Created);

        }
        catch (Exception e)
        {
            return DataState<WordSimpleDto>.Failure($"Error adding word: {e.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="wordId"></param>
    /// <param name="dictionaryId"></param>
    /// <returns></returns>
    public async Task<DataState<bool>> DeleteWordFromDictionary(int wordId, int dictionaryId)
    {
        try
        {
            var dictionaryWord = await dictionaryRepository.DeleteWordFromDictionary(wordId, dictionaryId);
            return !dictionaryWord ? DataState<bool>.Failure("Word not found in dictionary", StatusCodes.Status404NotFound) : DataState<bool>.Success(true, StatusCodes.Status200OK);
        }
        catch (Exception e)
        {
            return DataState<bool>.Failure($"Error deleting word: {e.Message}", StatusCodes.Status500InternalServerError);
        }
    }

    private static string GenerateRandomLanguageLevel()
    {
        var languageLevels = new[] { "A1", "A2", "B1", "B2", "C1" };
        var random = new Random();
        var index = random.Next(languageLevels.Length);
        return languageLevels[index];
    }
}