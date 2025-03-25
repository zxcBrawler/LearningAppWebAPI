using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service
{
    public class TypeExerciseService(TypeExerciseRepository typeExerciseRepository)
    {
        private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();

        public async Task<List<TypeExerciseSimpleDto>> GetAllTypesExerciseAsync()
        {
            var types = await typeExerciseRepository.GetAllAsync();
            return types.Select(_mapper.Map<TypeExerciseSimpleDto>).ToList();
        }
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
