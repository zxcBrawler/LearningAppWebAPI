using AutoMapper;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Impl
{
    /// <summary>
    /// The course service class
    /// </summary>
    public class CourseServiceImpl(CourseRepository courseRepository,  IMapper mapper) : ICourseService
    {
        /// <summary>
        /// The configure mapper
        /// </summary>

        /// <summary>
        /// Gets the all courses
        /// </summary>
        /// <returns>A task containing a list of course complex dto</returns>
        public async Task<List<CourseComplexDto>> GetAllCoursesAsync()
        {
            var roles = await courseRepository.GetAllAsync();
            return roles.Select(mapper.Map<CourseComplexDto>).ToList();
        }

        /// <summary>
        /// Gets the course by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the course complex dto</returns>
        public async Task<DataState<CourseComplexDto>> GetCourseById(long id)
        {
            try
            {
                var course = await courseRepository.GetByIdAsync(id);
                return course == null ? DataState<CourseComplexDto>.Failure($"Course with id {id} not found", StatusCodes.Status404NotFound) : DataState<CourseComplexDto>.Success(mapper.Map<CourseComplexDto>(course), StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return DataState<CourseComplexDto>.Failure(e.Message, StatusCodes.Status500InternalServerError);
            }
            
        }


        /// <summary>
        /// Updates the course using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="addCourseRequestDto">The add course request dto</param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> UpdateCourse(long id, AddCourseRequestDto addCourseRequestDto)
        {


            var currentCourse = await courseRepository.GetByIdAsync(id);
            if (currentCourse == null)
            {
                return false;
            }
            currentCourse.CourseDescription = addCourseRequestDto.CourseDescription;
            currentCourse.CourseLanguageLevel = addCourseRequestDto.CourseLanguageLevel;
            currentCourse.CourseName = addCourseRequestDto.CourseName;


            return await courseRepository.UpdateAsync(id, currentCourse);

        }


        /// <summary>
        /// Creates the course using the specified add course request dto
        /// </summary>
        /// <param name="addCourseRequestDto">The add course request dto</param>
        /// <returns>A task containing the course simple dto</returns>
        public async Task<CourseSimpleDto?> CreateCourse(AddCourseRequestDto addCourseRequestDto)
        {

            var courseOpt = courseRepository.GetByCourseName(addCourseRequestDto.CourseName ?? "");

            if (courseOpt != null)
            {
                return null;
            }

            Course course = new()
            {
                CourseDescription = addCourseRequestDto.CourseDescription,
                CourseLanguageLevel = addCourseRequestDto.CourseLanguageLevel,
                CourseName = addCourseRequestDto.CourseName
            };

            await courseRepository.CreateAsync(course);
            return mapper.Map<CourseSimpleDto>(course);

        }

        /// <summary>
        /// Deletes the course using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> DeleteCourse(long id)
        {
            return await courseRepository.DeleteAsync(id);
        }
    }
}
