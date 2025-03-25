using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAppWebAPI.Models
{

    /// <summary>
    /// The exercise class
    /// </summary>
    [Table("exercise")]
    public class Exercise
    {

     
        /// <summary>
        /// Gets or inits the value of the id
        /// </summary>
        [Key]
        [Column("id_exercise")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
     
        /// <summary>
        /// Gets or inits the value of the question name
        /// </summary>
        [Required]
        [MaxLength(150)]
        [Column("question_name")]
        public string? QuestionName { get; init; }
        
        /// <summary>
        /// Gets or inits the value of the question description
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("question_description")]
        public string? QuestionDescription { get; init; }

        /// <summary>
        /// Gets or inits the value of the xp reward
        /// </summary>
        [Column("xp_reward")]
        public int XpReward { get; init; }

        /// <summary>
        /// Gets or inits the value of the created at
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

       
        /// <summary>
        /// Gets or inits the value of the updated at
        /// </summary>
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;

     
        /// <summary>
        /// Gets or inits the value of the type exercise id
        /// </summary>
        [Column("type_exercise_id")]
        public int TypeExerciseId { get; init; }
       
        /// <summary>
        /// Gets or inits the value of the lesson id
        /// </summary>
        [Column("lesson_id")]
        public int LessonId { get; init; }
      
        /// <summary>
        /// Gets or inits the value of the type exercise
        /// </summary>
        public TypeExercise? TypeExercise { get; init; }
    
        /// <summary>
        /// Gets or inits the value of the lesson
        /// </summary>
        public Lesson? Lesson { get; init; }
        
        /// <summary>
        /// Gets or inits the value of the multiple choice exercise
        /// </summary>
        public MultipleChoiceExercise? MultipleChoiceExercise { get; init; }
       
        /// <summary>
        /// Gets or inits the value of the text answer exercise
        /// </summary>
        public TextAnswerExercise? TextAnswerExercise { get; init; }
      
        /// <summary>
        /// Gets or inits the value of the true false exercise
        /// </summary>
        public TrueFalseExercise? TrueFalseExercise { get; init; }
    }
}
