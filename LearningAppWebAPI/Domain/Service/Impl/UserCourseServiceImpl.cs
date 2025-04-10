using AutoMapper;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service.Impl
{
    /// <summary>
    /// The user course service class
    /// </summary>
    public class UserCourseServiceImpl(UserCourseRepository userCourseRepository, UserRepository userRepository, CourseRepository courseRepository, IMapper mapper) : IUserCourseService
    {

        /// <summary>
        /// Gets the all users with courses
        /// </summary>
        /// <returns>A task containing a list of user course simple dto</returns>
        public async Task<DataState<List<UserCourseSimpleDto>>> GetAllUsersWithCourses()
        {
            try
            {
                var users = await userCourseRepository.GetAllAsync();
                return DataState<List<UserCourseSimpleDto>>.Success(users.Select(mapper.Map<UserCourseSimpleDto>).ToList(), StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return DataState<List<UserCourseSimpleDto>>.Failure($"Error getting user courses: {ex.Message}", StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Gets the by all by user id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing a list of user course simple dto</returns>
        public async Task<DataState<List<UserCourseSimpleDto>>> GetByAllByUserId(long userId)
        {
            try
            {
                var users = await userCourseRepository.GetByAllByUserId(userId);
                return DataState<List<UserCourseSimpleDto>>.Success(users.Select(mapper.Map<UserCourseSimpleDto>).ToList(), StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return DataState<List<UserCourseSimpleDto>>.Failure($"Error getting user courses: {ex.Message}", StatusCodes.Status500InternalServerError);
            }
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public async Task<DataState<UserCourseSimpleDto>> StartNewCourse(long userId, long courseId)
        {
            try
            {
                var currentUser = await userRepository.GetByIdAsync(userId);
                var currentCourse = await courseRepository.GetByIdAsync(courseId);
                var newUserCourse = new UserCourse
                {
                    UserId = userId,
                    CourseId = courseId,
                    User = currentUser,
                    Course = currentCourse
                    
                };
                var result = await userCourseRepository.CreateAsync(newUserCourse);
                return DataState<UserCourseSimpleDto>.Success(mapper.Map<UserCourseSimpleDto>(result), StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return DataState<UserCourseSimpleDto>.Failure("You have already applied to this course", StatusCodes.Status500InternalServerError);
            }
        }
    }
}
