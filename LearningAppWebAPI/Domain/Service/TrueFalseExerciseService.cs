using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Utils;

namespace LearningAppWebAPI.Domain.Service
{
    /// <summary>
    /// The true false exercise service class
    /// </summary>
    [ScopedService]
    public class TrueFalseExerciseService(TrueFalseExerciseRepository trueFalseExerciseRepository)
    {
    }
}
