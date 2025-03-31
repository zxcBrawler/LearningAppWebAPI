using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Utils;

namespace LearningAppWebAPI.Domain.Service
{
    /// <summary>
    /// The lesson service class
    /// </summary>
    [ScopedService]
    public class LessonService(LessonRepository lessonRepository)
    {
    }
}
