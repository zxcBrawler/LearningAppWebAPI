using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service.Impl
{
    /// <summary>
    /// The true false exercise service class
    /// </summary>
    [ScopedService]
    public class TrueFalseExerciseServiceImpl(TrueFalseExerciseRepository trueFalseExerciseRepository) : ITrueFalseExerciseService
    {
    }
}
