using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Interface;

public interface IWordService
{
    Task<DataState<List<WordSimpleDto>>> GetAllAsync();
    Task<DataState<WordSimpleDto>> GetWordByIdAsync(int wordId);
}