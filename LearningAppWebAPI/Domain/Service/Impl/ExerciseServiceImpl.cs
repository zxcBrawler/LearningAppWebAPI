using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;

namespace LearningAppWebAPI.Domain.Service.Impl
{
    /// <summary>
    /// The exercise service class
    /// </summary>
    public class ExerciseServiceImpl(ExerciseRepository exerciseRepository) : IExerciseService
    {
    }
}
