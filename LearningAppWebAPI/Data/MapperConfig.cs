using AutoMapper;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Data
{
    /// <summary>
    /// The mapper config class
    /// </summary>
    public class MapperConfig
    {

        /// <summary>
        /// Configures the mapper
        /// </summary>
        /// <returns>The mapper</returns>
        public static Mapper ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<User, UserSimpleDto>();
                cfg.CreateMap<User, UserComplexDto>();
                cfg.CreateMap<Role, RoleSimpleDto>();
                cfg.CreateMap<Course, CourseSimpleDto>();
                cfg.CreateMap<Course, CourseComplexDto>();
                cfg.CreateMap<Lesson, LessonSimpleDto>();
                cfg.CreateMap<Lesson, LessonComplexDto>();
                cfg.CreateMap<Option, OptionSimpleDto>();
                cfg.CreateMap<Option, OptionComplexDto>();
                cfg.CreateMap<TypeExercise, TypeExerciseSimpleDto>();
                cfg.CreateMap<UserCourse, UserCourseSimpleDto>();
                cfg.CreateMap<UserCourse, UserCourseComplexDto>();
                cfg.CreateMap<MultipleChoiceExercise, MultipleChoiceExerciseSimpleDto>();
                cfg.CreateMap<MultipleChoiceExercise, MultipleChoiceExerciseComplexDto>();
                cfg.CreateMap<Exercise, ExerciseComplexDto>();
                cfg.CreateMap<Exercise, ExerciseSimpleDto>();
                cfg.CreateMap<TextAnswerExercise, TextAnswerExerciseSimpleDto>();
                cfg.CreateMap<TextAnswerExercise, TextAnswerExerciseComplexDto>();
                cfg.CreateMap<TrueFalseExercise, TrueFalseExerciseSimpleDto>();
                cfg.CreateMap<TrueFalseExercise, TrueFalseExerciseComplexDto>();
                cfg.CreateMap<Dictionary, DictionarySimpleDto>();
                cfg.CreateMap<Word, WordSimpleDto>();

            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
