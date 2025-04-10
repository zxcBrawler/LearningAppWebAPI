using AutoMapper;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Impl
{
    /// <summary>
    /// The option service class
    /// </summary>
    public class OptionServiceImpl(OptionRepository optionRepository, MultipleChoiceExerciseRepository multipleChoiceExerciseRepository, IMapper mapper) : IOptionService
    {

        /// <summary>
        /// Gets the option using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the option complex dto</returns>
        public async Task<DataState<OptionComplexDto?>> GetOption(int id)
        {
            try
            {
                var option = await optionRepository.GetByIdAsync(id);
                return DataState<OptionComplexDto?>.Success(mapper.Map<OptionComplexDto?>(option), StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return DataState<OptionComplexDto?>.Failure($"Error getting an option with id {id}", StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Creates the option using the specified add option dto
        /// </summary>
        /// <param name="addOptionRequestDto">The add option dto</param>
        /// <returns>A task containing the option simple dto</returns>
        public async Task<DataState<OptionSimpleDto>> CreateOption(AddOptionRequestDto addOptionRequestDto)
        {
            try
            {
                var option = new Option
                {
                    Text = addOptionRequestDto.Text,
                    MultipleChoiceExercise = await multipleChoiceExerciseRepository.GetByIdAsync(addOptionRequestDto.MultipleChoiceExerciseId)
                };
                await optionRepository.CreateAsync(option);
                return DataState<OptionSimpleDto>.Success(mapper.Map<OptionSimpleDto>(option), StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return DataState<OptionSimpleDto>.Failure($"Error adding an option {addOptionRequestDto.Text}", StatusCodes.Status500InternalServerError);
            }
        }
    }
}
