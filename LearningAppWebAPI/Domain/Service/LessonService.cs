using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;

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
