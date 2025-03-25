using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    /// <summary>
    /// The lesson repository class
    /// </summary>
    /// <seealso cref="AbstractBaseRepository{Lesson}"/>
    public class LessonRepository(AppDbContext context) : AbstractBaseRepository<Lesson>(context)
    {
        /// <summary>
        /// Creates the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>The entity</returns>
        public override async Task<Lesson> CreateAsync(Lesson entity)
        {
            await Context.Lesson.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Deletes the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the bool</returns>
        public override async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            Context.Lesson.Remove(user);
            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing a list of lesson</returns>
        public override async Task<List<Lesson>> GetAllAsync()
        {
            return await Context.Lesson.Include(e => e.Exercises).ToListAsync();
        }

        /// <summary>
        /// Gets the by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the lesson</returns>
        public override async Task<Lesson?> GetByIdAsync(int id)
        {
            return await Context.Lesson.FindAsync(id);
        }

        /// <summary>
        /// Updates the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="entity">The entity</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A task containing the bool</returns>
        public override Task<bool> UpdateAsync(int id, Lesson entity)
        {
            throw new NotImplementedException();
        }
    }
}
