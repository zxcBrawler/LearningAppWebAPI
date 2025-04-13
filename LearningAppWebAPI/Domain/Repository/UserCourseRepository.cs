using Alachisoft.NCache.Common.Threading;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    [ScopedService]
    public class UserCourseRepository(AppDbContext context) : AbstractBaseRepository<UserCourse, int>(context)
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
        public async Task<List<UserCourse>> GetByAllByUserId(long userId)
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
        /// <param name="userId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public async Task<UserCourse?> GetByUserIdAndCourseId(long userId, long courseId)
        {
            return await Context.UserCourse.Where(u => u.User!.Id == userId && u.Course!.Id == courseId).FirstOrDefaultAsync();
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="courseId"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateCourseAsync(long userId, long courseId, UserCourse entity)
        {
            if (userId != entity.UserId || courseId != entity.CourseId)
            {
                return false;
            }
            try
            {
                var existing = await Context.UserCourse
                    .AsTracking()
                    .FirstOrDefaultAsync(c => c.UserId == userId && c.CourseId == courseId);

                if (existing == null)
                {
                    return false;
                }
                Context.Entry(existing).CurrentValues.SetValues(entity);
                
                var affectedRows = await Context.SaveChangesAsync();
                return affectedRows > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var stillExists = await Context.UserCourse
                    .AsNoTracking()
                    .AnyAsync(c => c.UserId == userId && c.CourseId == courseId);
            
                return !stillExists;
            }
        }
    }
}
