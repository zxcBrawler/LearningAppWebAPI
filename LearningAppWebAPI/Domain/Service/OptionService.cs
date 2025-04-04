using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service
{
    /// <summary>
    /// The option service class
    /// </summary>
    [ScopedService]
    public class OptionService(OptionRepository optionRepository, MultipleChoiceExerciseRepository multipleChoiceExerciseRepository)
    {
        /// <summary>
        /// The configure mapper
        /// </summary>
        private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();


        // CreateOption request model 
        /*{
            Text: "dsds",
            MultipleChoiceExercise_Id: 1 
          }
         */


        /// <summary>
        /// Gets the option using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the option complex dto</returns>
        public async Task<OptionComplexDto?> GetOption(int id)
        {
            var option = await optionRepository.GetByIdAsync(id);
            return option == null ? null : _mapper.Map<OptionComplexDto>(option);
        }

        /// <summary>
        /// Creates the option using the specified add option dto
        /// </summary>
        /// <param name="addOptionRequestDto">The add option dto</param>
        /// <returns>A task containing the option simple dto</returns>
        public async Task<OptionSimpleDto> CreateOption(AddOptionRequestDto addOptionRequestDto)
        {
            var option = new Option
            {
                Text = addOptionRequestDto.Text,
                MultipleChoiceExercise = await multipleChoiceExerciseRepository.GetByIdAsync(addOptionRequestDto.MultipleChoiceExerciseId)
            };
            await optionRepository.CreateAsync(option);
            return _mapper.Map<OptionSimpleDto>(option);

        }
    }
}
