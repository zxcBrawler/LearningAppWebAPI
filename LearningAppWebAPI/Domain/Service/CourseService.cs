using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service
{
    public class CourseService(CourseRepository courseRepository)
    {
        private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();

        public async Task<List<CourseComplexDto>> GetAllCoursesAsync()
        {
            var roles = await courseRepository.GetAllAsync();
            return roles.Select(_mapper.Map<CourseComplexDto>).ToList();
        }

        public async Task<CourseComplexDto?> GetCourseById(int id)
        {
            var course = await courseRepository.GetByIdAsync(id);
            return course == null ? null : _mapper.Map<CourseComplexDto>(course);
        }


        public async Task<bool> UpdateCourse(int id, AddCourseRequestDto addCourseRequestDto)
        {


            var currentCourse = await courseRepository.GetByIdAsync(id);
            if (currentCourse == null)
            {
                return false;
            }
            currentCourse.Course_Description = addCourseRequestDto.Course_Description;
            currentCourse.Course_Language_Level = addCourseRequestDto.Course_Language_Level;
            currentCourse.Course_Name = addCourseRequestDto.Course_Name;


            return await courseRepository.UpdateAsync(id, currentCourse);

        }


        public async Task<CourseSimpleDto?> CreateCourse(AddCourseRequestDto addCourseRequestDto)
        {

            var courseOpt = courseRepository.GetByCourseName(addCourseRequestDto.Course_Name ?? "");

            if (courseOpt != null)
            {
                return null;
            }

            Course course = new()
            {
                Course_Description = addCourseRequestDto.Course_Description,
                Course_Language_Level = addCourseRequestDto.Course_Language_Level,
                Course_Name = addCourseRequestDto.Course_Name
            };

            await courseRepository.CreateAsync(course);
            return _mapper.Map<CourseSimpleDto>(course);

        }

        public async Task<bool> DeleteCourse(int id)
        {
            return await courseRepository.DeleteAsync(id);
        }
    }
}
