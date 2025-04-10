using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Interface;

public interface ITypeExerciseService
{
    Task<DataState<List<TypeExerciseSimpleDto>>> GetAllTypesExerciseAsync();
    Task<DataState<TypeExerciseSimpleDto>> GetTypeExerciseById(int id);
}