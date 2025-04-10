
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Utils.CustomAttributes;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    /// <summary>
    /// The course repository class
    /// </summary>
    /// <seealso cref="AbstractBaseRepository{Course}"/>
    [ScopedService]
    public class CourseRepository(AppDbContext context) : AbstractBaseRepository<Course, long>(context)
    {
        /// <summary>
        /// Creates the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The entity</returns>
        public override async Task<Course> CreateAsync(Course entity)
        {
            await Context.Course.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Deletes the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the bool</returns>
        public override async Task<bool> DeleteAsync(long id)
        {
            var user = await GetByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            Context.Course.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing a list of course</returns>
        public override async Task<List<Course>> GetAllAsync()
        {
            return await Context.Course.Include(u => u.Lesson).ToListAsync();
        }

        /// <summary>
        /// Gets the by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the course</returns>
        public override async Task<Course?> GetByIdAsync(long id)
        {
            var course = await Context.Course
                .FirstOrDefaultAsync(u => u.Id == id);

            if (course == null) return null;
            
            course.Lesson = await Context.Lesson
                .Where(l => l.CourseId == id)
                .Include(l => l.Exercises)
                .ThenInclude(e => e.TypeExercise)
                .ToListAsync();
            
            foreach (var lesson in course.Lesson)
            {
                lesson.Exercises = await Context.Exercises
                    .Where(e => e.LessonId == lesson.Id)
                    .Include(e => e.MultipleChoiceExercise)
                    .ThenInclude(m => m.Options)
                    .Include(e => e.TextAnswerExercise)
                    .Include(e => e.TrueFalseExercise)
                    .ToListAsync();
            }
            return course;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override async Task<bool> UpdateAsync(long id, Course entity)
        {
            if (id != entity.Id)
            {
                return false;
            }
            try
            {
                var existing = await Context.Course
                    .AsTracking()
                    .FirstOrDefaultAsync(c => c.Id == id);

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
                var stillExists = await Context.Course
                    .AsNoTracking()
                    .AnyAsync(c => c.Id == id);
            
                return !stillExists;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public async Task<Course?> GetByCourseName(string courseName)
        {
            return await Context.Course.Where(n => n.CourseName == courseName).FirstAsync();
        }
    }
}
