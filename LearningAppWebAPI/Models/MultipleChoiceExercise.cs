
namespace LearningAppWebAPI.Models
{
    public class MultipleChoiceExercise
    {
        public List<Option>? Options { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public int Exercise_Id { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
