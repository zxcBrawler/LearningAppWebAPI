using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Interface;

public interface IDictionaryService
{
    Task<DataState<List<DictionarySimpleDto>>> GetAllByUserIdAsync(long userId);
    Task<DataState<DictionarySimpleDto>> GetUserDictionaryById(int dictionaryId, long userId);
    Task<DataState<DictionarySimpleDto>> AddNewDictionary(long userId, AddDictionaryRequestDto addDictionaryRequestDto);
    Task<DataState<bool>> UpdateDictionary(long userId, int dictionaryId, UpdateDictionaryRequestDto updateDictionaryRequestDto);
    Task<DataState<bool>> DeleteDictionaryAsync(int id);
    Task<DataState<DictionarySimpleDto>> AddWordToDictionary(long userId, int dictionaryId, int wordId);
}