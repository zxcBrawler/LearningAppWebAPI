
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{

    /// <summary>
    /// The multiple choice exercise class
    /// </summary>
    [Table("multiple_choice_exercise")]
    public class MultipleChoiceExercise
    {
   
        /// <summary>
        /// Gets or inits the value of the correct answer index
        /// </summary>
        [Column("correct_answer_index")]
        public int CorrectAnswerIndex { get; init; }

   
        /// <summary>
        /// Gets or inits the value of the exercise id
        /// </summary>
        [Column("exercise_id")]
        public int ExerciseId { get; init; }
   
        /// <summary>
        /// Gets or inits the value of the exercise
        /// </summary>
        public Exercise? Exercise { get; init; }
        
   
        /// <summary>
        /// Gets or inits the value of the options
        /// </summary>
        public List<Option>? Options { get; init; }
    }
}
