using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public class UserCourseRepository(AppDbContext context) : AbstractBaseRepository<UserCourse>(context)
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override async Task<UserCourse> CreateAsync(UserCourse entity)
        {
            await Context.UserCourse.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override async Task<List<UserCourse>> GetAllAsync()
        {
            return await Context.UserCourse
                .Include(u => u.Course)
                .Include(us => us.User)
                .Include(r => r.User!.Role)
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<UserCourse>> GetByAllByUserId(int userId)
        {
            return await Context.UserCourse
                .Include(u => u.Course)
                .Include(us => us.User)
                .Include(r => r.User!.Role)
                .Where(u => u.User!.Id == userId)
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<UserCourse?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<bool> UpdateAsync(int id, UserCourse entity)
        {
            throw new NotImplementedException();
        }
    }
}
