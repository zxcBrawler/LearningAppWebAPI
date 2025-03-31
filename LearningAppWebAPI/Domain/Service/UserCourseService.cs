using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models.DTO.Simple;
using LearningAppWebAPI.Utils;

namespace LearningAppWebAPI.Domain.Service
{
    /// <summary>
    /// The user course service class
    /// </summary>
    [ScopedService]
    public class UserCourseService(UserCourseRepository userCourseRepository)
    {
        /// <summary>
        /// The configure mapper
        /// </summary>
        private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();

        /// <summary>
        /// Gets the all users with courses
        /// </summary>
        /// <returns>A task containing a list of user course simple dto</returns>
        public async Task<List<UserCourseSimpleDto>> GetAllUsersWithCourses()
        {
            var users = await userCourseRepository.GetAllAsync();
            return users.Select(_mapper.Map<UserCourseSimpleDto>).ToList();
        }

        /// <summary>
        /// Gets the by all by user id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing a list of user course simple dto</returns>
        public async Task<List<UserCourseSimpleDto>> GetByAllByUserId(int userId)
        {
            var users = await userCourseRepository.GetByAllByUserId(userId);
            return users.Select(_mapper.Map<UserCourseSimpleDto>).ToList();
        }
    }
}
