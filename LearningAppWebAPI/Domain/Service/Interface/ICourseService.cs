using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Interface;

public interface ICourseService
{
    Task<List<CourseComplexDto>> GetAllCoursesAsync();
    Task<DataState<CourseComplexDto>> GetCourseById(long id);
    Task<bool> UpdateCourse(long id, AddCourseRequestDto addCourseRequestDto);
    Task<CourseSimpleDto?> CreateCourse(AddCourseRequestDto addCourseRequestDto);
    Task<bool> DeleteCourse(long id);
}