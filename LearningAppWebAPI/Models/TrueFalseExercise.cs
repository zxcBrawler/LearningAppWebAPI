
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{
    // TODO: Complete docs
    /// <summary>
    /// The true false exercise class
    /// </summary>
    [Table("true_false_exercise")]
    [Serializable]
    public class TrueFalseExercise
    {
   
        /// <summary>
        /// 
        /// </summary>
        [Column("answer_value")]
        public bool AnswerValue { get; init; }

   
        /// <summary>
        /// 
        /// </summary>
        [Column("exercise_id")]
        public int ExerciseId { get; init; }
   
        /// <summary>
        ///
        /// </summary>
        public Exercise? Exercise { get; init; }
    }
}
