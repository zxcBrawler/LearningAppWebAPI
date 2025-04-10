using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Interface;

public interface ICourseService
{
    Task<List<CourseComplexDto>> GetAllCoursesAsync();
    Task<CourseComplexDto?> GetCourseById(int id);
    Task<bool> UpdateCourse(int id, AddCourseRequestDto addCourseRequestDto);
    Task<CourseSimpleDto?> CreateCourse(AddCourseRequestDto addCourseRequestDto);
    Task<bool> DeleteCourse(int id);
}