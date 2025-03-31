using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Utils;

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
