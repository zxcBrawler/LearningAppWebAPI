using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service
{
    /// <summary>
    /// The text answer exercise service class
    /// </summary>
    [ScopedService]
    public class TextAnswerExerciseService(TextAnswerExerciseRepository textAnswerExerciseRepository)
    {
    }
}
