using AutoMapper;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Data
{
    public class MapperConfig
    {

        public static Mapper ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<User, UserSimpleDto>();
                cfg.CreateMap<User, UserComplexDTO>();
                cfg.CreateMap<Role, RoleSimpleDto>();
                cfg.CreateMap<Course, CourseSimpleDto>();
                cfg.CreateMap<Course, CourseComplexDto>();
                cfg.CreateMap<Lesson, LessonSimpleDto>();
                cfg.CreateMap<Lesson, LessonComplexDTO>();
                cfg.CreateMap<Option, OptionSimpleDto>();
                cfg.CreateMap<Option, OptionComplexDTO>();
                cfg.CreateMap<TypeExercise, TypeExerciseSimpleDto>();
                cfg.CreateMap<UserCourse, UserCourseSimpleDto>();
                cfg.CreateMap<UserCourse, UserCourseComplexDTO>();
                cfg.CreateMap<MultipleChoiceExercise, MultipleChoiceExerciseSimpleDto>();
                cfg.CreateMap<MultipleChoiceExercise, MultipleChoiceExerciseComplexDTO>();
                cfg.CreateMap<Exercise, ExerciseComplexDTO>();
                cfg.CreateMap<Exercise, ExerciseSimpleDto>();
                cfg.CreateMap<TextAnswerExercise, TextAnswerExerciseSimpleDto>();
                cfg.CreateMap<TextAnswerExercise, TextAnswerExerciseComplexDTO>();
                cfg.CreateMap<TrueFalseExercise, TrueFalseExerciseSimpleDto>();
                cfg.CreateMap<TrueFalseExercise, TrueFalseExerciseComplexDTO>();

            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
