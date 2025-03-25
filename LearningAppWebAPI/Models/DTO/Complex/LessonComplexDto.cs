using System.Text.Json.Serialization;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Models.DTO.Complex
{
    // TODO: Complete doc
    /// <summary>
    /// The lesson complex dto class
    /// </summary>
    /// <seealso cref="LessonSimpleDto"/>
    public class LessonComplexDto : LessonSimpleDto
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("exercises")]  public List<ExerciseComplexDto>? Exercises { get; set; }
    }
}
