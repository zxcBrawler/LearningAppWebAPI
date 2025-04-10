using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;

namespace LearningAppWebAPI.Domain.Service.Impl
{
    /// <summary>
    /// The lesson service class
    /// </summary>
    public class LessonServiceImpl(LessonRepository lessonRepository) : ILessonService
    {
    }
}
