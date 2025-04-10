using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service.Impl
{
    /// <summary>
    /// The text answer exercise service class
    /// </summary>
    public class TextAnswerExerciseServiceImpl(TextAnswerExerciseRepository textAnswerExerciseRepository) : ITextAnswerExerciseService
    {
    }
}
