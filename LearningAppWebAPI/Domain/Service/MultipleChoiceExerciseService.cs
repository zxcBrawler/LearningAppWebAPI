using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service
{
    /// <summary>
    /// The multiple choice exercise service class
    /// </summary>
    [ScopedService]
    public class MultipleChoiceExerciseService(MultipleChoiceExerciseRepository multipleChoiceExerciseRepository)
    {
    }
}
