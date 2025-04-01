using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;

namespace LearningAppWebAPI.Domain.Service
{
    /// <summary>
    /// The exercise service class
    /// </summary>
    [ScopedService]
    public class ExerciseService(ExerciseRepository exerciseRepository)
    {
    }
}
