
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{
    // TODO: Complete docs
    /// <summary>
    /// The multiple choice exercise class
    /// </summary>
    [Table("multiple_choice_exercise")]
    [Serializable]
    public class MultipleChoiceExercise
    {
   
        /// <summary>
        /// 
        /// </summary>
        [Column("correct_answer_index")]
        public int CorrectAnswerIndex { get; init; }

   
        /// <summary>
        /// 
        /// </summary>
        [Column("exercise_id")]
        public int ExerciseId { get; init; }
   
        /// <summary>
        /// 
        /// </summary>
        public Exercise? Exercise { get; init; }
        
   
        /// <summary>
        /// 
        /// </summary>
        public List<Option>? Options { get; init; }
    }
}
