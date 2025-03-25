using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service
{
    /// <summary>
    /// The type exercise service class
    /// </summary>
    public class TypeExerciseService(TypeExerciseRepository typeExerciseRepository)
    {
        /// <summary>
        /// The configure mapper
        /// </summary>
        private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();

        /// <summary>
        /// Gets the all types exercise
        /// </summary>
        /// <returns>A task containing a list of type exercise simple dto</returns>
        public async Task<List<TypeExerciseSimpleDto>> GetAllTypesExerciseAsync()
        {
            var types = await typeExerciseRepository.GetAllAsync();
            return types.Select(_mapper.Map<TypeExerciseSimpleDto>).ToList();
        }
        /// <summary>
        /// Gets the role by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the type exercise simple dto</returns>
        public async Task<TypeExerciseSimpleDto?> GetRoleById(int id)
        {
            var type = await typeExerciseRepository.GetByIdAsync(id);
            if (type == null)
            {
                return null;
            }
            return _mapper.Map<TypeExerciseSimpleDto>(type);
        }
    }

}
