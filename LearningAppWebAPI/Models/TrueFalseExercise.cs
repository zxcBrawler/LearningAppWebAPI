
namespace LearningAppWebAPI.Models
{
    public class TrueFalseExercise
    {
        public bool IsTrue { get; set; }

        public int Exercise_Id { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
