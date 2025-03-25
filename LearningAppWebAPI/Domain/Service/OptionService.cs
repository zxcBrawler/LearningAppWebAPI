using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service
{
    public class OptionService(OptionRepository optionRepository, MultipleChoiceExerciseRepository multipleChoiceExerciseRepository)
    {
        private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();


        // CreateOption request model 
        /*{
            Text: "dsds",
            MultipleChoiceExercise_Id: 1 
          }
         */


        public async Task<OptionComplexDTO?> GetOption(int id)
        {
            var option = await optionRepository.GetByIdAsync(id);
            return option == null ? null : _mapper.Map<OptionComplexDTO>(option);
        }

        public async Task<OptionSimpleDto> CreateOption(AddOptionDTO addOptionDto)
        {
            Option option = new Option
            {
                Text = addOptionDto.Text,
                MultipleChoiceExercise = await multipleChoiceExerciseRepository.GetByIdAsync(addOptionDto.MultipleChoiceExerciseId)
            };
            await optionRepository.CreateAsync(option);
            return _mapper.Map<OptionSimpleDto>(option);

        }
    }
}
