using AutoMapper;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models.DTO.Simple;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service.Impl
{
    /// <summary>
    /// The type exercise service class
    /// </summary>
    [ScopedService]
    public class TypeExerciseServiceImpl(TypeExerciseRepository typeExerciseRepository, IMapper mapper) : ITypeExerciseService
    {
        
        /// <summary>
        /// Gets the all types exercise
        /// </summary>
        /// <returns>A task containing a list of type exercise simple dto</returns>
        public async Task<DataState<List<TypeExerciseSimpleDto>>> GetAllTypesExerciseAsync()
        {
            try
            {
                var types = await typeExerciseRepository.GetAllAsync();
                return DataState<List<TypeExerciseSimpleDto>>.Success(types.Select(mapper.Map<TypeExerciseSimpleDto>).ToList(), StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return DataState<List<TypeExerciseSimpleDto>>.Failure("Error getting all types exercise", StatusCodes.Status500InternalServerError);
            }
            
        }
        /// <summary>
        /// Gets the role by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the type exercise simple dto</returns>
        public async Task<DataState<TypeExerciseSimpleDto>> GetTypeExerciseById(int id)
        {
            try
            {
                var type = await typeExerciseRepository.GetByIdAsync(id);
                return DataState<TypeExerciseSimpleDto>.Success(mapper.Map<TypeExerciseSimpleDto>(type), StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return DataState<TypeExerciseSimpleDto>.Failure($"Error getting exercise type with id {id}", StatusCodes.Status500InternalServerError);
            }
            
        }
    }

}
