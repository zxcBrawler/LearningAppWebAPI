using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Interface;

public interface IOptionService
{
    Task<DataState<OptionComplexDto?>> GetOption(int id);
    Task<DataState<OptionSimpleDto>> CreateOption(AddOptionRequestDto addOptionRequestDto);
}