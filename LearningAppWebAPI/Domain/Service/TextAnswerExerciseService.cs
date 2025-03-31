using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Utils;

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
