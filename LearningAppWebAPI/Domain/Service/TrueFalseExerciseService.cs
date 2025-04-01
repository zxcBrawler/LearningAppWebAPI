using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;

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
