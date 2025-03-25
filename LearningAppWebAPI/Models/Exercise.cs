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
        /// The id of the exercise
        /// </summary>
        [Key]
        [Column("id_exercise")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
     
        /// <summary>
        /// The name of exercise question
        /// </summary>
        [Required]
        [MaxLength(150)]
        [Column("question_name")]
        public string? QuestionName { get; init; }
        
        /// <summary>
        /// The description of exercise question
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("question_description")]
        public string? QuestionDescription { get; init; }

        /// <summary>
        /// Xp reward granted for exercise completion
        /// </summary>
        [Column("xp_reward")]
        public int XpReward { get; init; }

        /// <summary>
        /// The time of exercise creation
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

       
        /// <summary>
        /// Last time the exercise was updated
        /// </summary>
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; init; } = DateTime.UtcNow;

     
        /// <summary>
        /// The id of exercise type
        /// </summary>
        [Column("type_exercise_id")]
        public int TypeExerciseId { get; init; }
       
        /// <summary>
        /// The id of lesson that is corresponded with exercise
        /// </summary>
        [Column("lesson_id")]
        public int LessonId { get; init; }
      
        /// <summary>
        /// The exercise type value
        /// </summary>
        public TypeExercise? TypeExercise { get; init; }
    
        /// <summary>
        /// The lesson that is corresponded with exercise
        /// </summary>
        public Lesson? Lesson { get; init; }
        
        /// <summary>
        /// 
        /// </summary>
        public MultipleChoiceExercise? MultipleChoiceExercise { get; init; }
       
        /// <summary>
        ///
        /// </summary>
        public TextAnswerExercise? TextAnswerExercise { get; init; }
      
        /// <summary>
        /// 
        /// </summary>
        public TrueFalseExercise? TrueFalseExercise { get; init; }
    }
}
