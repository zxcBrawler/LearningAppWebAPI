
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Utils;
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
        public override async Task<Course?> GetByIdAsync(long id) => await Context.Course
            .Include(u => u.Lesson)
            .ThenInclude(l => l.Exercises)
            .ThenInclude(t => t.TypeExercise)
            .Include(u => u.Lesson)
            .ThenInclude(l => l.Exercises)
            .ThenInclude(s => s.MultipleChoiceExercise)
            .ThenInclude(w => w.Options)
            .Include(u => u.Lesson)
            .ThenInclude(l => l.Exercises)!
            .ThenInclude(s => s.TextAnswerExercise)
            .Include(u => u.Lesson)!
            .ThenInclude(l => l.Exercises)!
            .ThenInclude(s => s.TrueFalseExercise)
            .FirstOrDefaultAsync(u => u.Id == id);

        public override async Task<bool> UpdateAsync(long id, Course entity)
        {
            if (id != entity.Id)
            {
                return false;
            }

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!CourseExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }
        public async Task<Course?> GetByCourseName(string courseName)
        {
            return await Context.Course.Where(n => n.CourseName == courseName).FirstAsync();
        }
        private bool CourseExists(long id)
        {
            return Context.Course.Any(u => u.Id == id);
        }
    }
}
