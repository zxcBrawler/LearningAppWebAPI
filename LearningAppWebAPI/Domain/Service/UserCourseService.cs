using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Models.DTO.Simple;

namespace LearningAppWebAPI.Domain.Service
{
    public class UserCourseService(UserCourseRepository userCourseRepository)
    {
        private readonly AutoMapper.Mapper _mapper = MapperConfig.ConfigureMapper();

        public async Task<List<UserCourseSimpleDto>> GetAllUsersWithCourses()
        {
            var users = await userCourseRepository.GetAllAsync();
            return users.Select(_mapper.Map<UserCourseSimpleDto>).ToList();
        }

        public async Task<List<UserCourseSimpleDto>> GetByAllByUserId(int userId)
        {
            var users = await userCourseRepository.GetByAllByUserId(userId);
            return users.Select(_mapper.Map<UserCourseSimpleDto>).ToList();
        }
    }
}
