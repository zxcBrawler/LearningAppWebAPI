using AutoMapper;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Response;
using LearningAppWebAPI.Models.DTO.Simple;
using MerriamWebster.NET.Results;

namespace LearningAppWebAPI.Domain.Profiles;

/// <summary>
/// 
/// </summary>
public class MainMappingProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public MainMappingProfile()
    {
        CreateMap<User, UserSimpleDto>();
        CreateMap<User, UserComplexDto>();
        CreateMap<Course, CourseSimpleDto>();
        CreateMap<Course, CourseComplexDto>();
        CreateMap<Dictionary, DictionarySimpleDto>();
        CreateMap<Exercise, ExerciseComplexDto>();
        CreateMap<Exercise, ExerciseSimpleDto>();
        CreateMap<Lesson, LessonSimpleDto>();
        CreateMap<Lesson, LessonComplexDto>();
        CreateMap<MultipleChoiceExercise, MultipleChoiceExerciseComplexDto>();
        CreateMap<MultipleChoiceExercise, MultipleChoiceExerciseSimpleDto>();
        CreateMap<Option, OptionSimpleDto>();
        CreateMap<Option, OptionComplexDto>();
        CreateMap<Role, RoleSimpleDto>();
        CreateMap<TextAnswerExercise, TextAnswerExerciseComplexDto>();
        CreateMap<TextAnswerExercise, TextAnswerExerciseSimpleDto>();
        CreateMap<TrueFalseExercise, TrueFalseExerciseSimpleDto>();
        CreateMap<TrueFalseExercise, TrueFalseExerciseComplexDto>();
        CreateMap<TypeExercise, TypeExerciseSimpleDto>();
        CreateMap<TypeExercise, TypeExerciseComplexDto>();
        CreateMap<UserCourse, UserCourseSimpleDto>();
        CreateMap<UserCourse, UserCourseComplexDto>();
        CreateMap<Word, WordSimpleDto>();
    }
}