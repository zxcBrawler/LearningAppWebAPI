using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    public class UserCourseRepository(AppDbContext context) : AbstractBaseRepository<UserCourse>(context)
    {
        public override async Task<UserCourse> CreateAsync(UserCourse entity)
        {
            await Context.User_Course.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public override Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<List<UserCourse>> GetAllAsync()
        {
            return await Context.User_Course
                .Include(u => u.Course)
                .Include(us => us.User)
                .Include(r => r.User!.Role)
                .ToListAsync();
        }

        public async Task<List<UserCourse>> GetByAllByUserId(int userId)
        {
            return await Context.User_Course
                .Include(u => u.Course)
                .Include(us => us.User)
                .Include(r => r.User!.Role)
                .Where(u => u.User!.Id == userId)
                .ToListAsync();
        }

        public override Task<UserCourse?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateAsync(int id, UserCourse entity)
        {
            throw new NotImplementedException();
        }
    }
}
