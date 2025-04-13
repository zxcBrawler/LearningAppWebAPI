using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Interface;

public interface IUserCourseService
{
    Task<DataState<List<UserCourseSimpleDto>>> GetAllUsersWithCourses();
    Task<DataState<List<UserCourseSimpleDto>>> GetByAllByUserId(long userId);
    Task<DataState<UserCourseSimpleDto>> StartNewCourse(long userId, long courseId);
    Task<DataState<List<CourseComplexDto>>> GetOtherCourses(long userId);
}