
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{
    /// <summary>
    /// The true false exercise class
    /// </summary>
    [Table(name: "true_false_exercise")]
    public class TrueFalseExercise
    {
   
        /// <summary>
        /// Gets or inits the value of the answer value
        /// </summary>
        [Column("answer_value")]
        public bool AnswerValue { get; init; }

   
        /// <summary>
        /// Gets or inits the value of the exercise id
        /// </summary>
        [Column("exercise_id")]
        public int ExerciseId { get; init; }
   
        /// <summary>
        /// Gets or inits the value of the exercise
        /// </summary>
        public Exercise? Exercise { get; init; }
    }
}
