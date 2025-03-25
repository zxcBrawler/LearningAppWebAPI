
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Domain.Repository
{
    public class CourseRepository(AppDbContext context) : AbstractBaseRepository<Course>(context)
    {
        public override async Task<Course> CreateAsync(Course entity)
        {
            await Context.Course.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public override async Task<bool> DeleteAsync(int id)
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

        public override async Task<List<Course>> GetAllAsync()
        {
            return await Context.Course.Include(u => u.Lesson).ToListAsync();
        }

        public override async Task<Course?> GetByIdAsync(int id) => await Context.Course
            .Include(u => u.Lesson)
            .ThenInclude(l => l.Exercises)
            .ThenInclude(t => t.TypeExercise)
            .Include(u => u.Lesson)
            .ThenInclude(l => l.Exercises)
            .ThenInclude(s => s.MultipleChoiceExercise)
            .ThenInclude(w => w.Options)
            .Include(u => u.Lesson)
            .ThenInclude(l => l.Exercises)
            .ThenInclude(s => s.TextAnswerExercise)
            .Include(u => u.Lesson)
            .ThenInclude(l => l.Exercises)
            .ThenInclude(s => s.TrueFalseExercise)
            .FirstOrDefaultAsync(u => u.Id == id);

        public override async Task<bool> UpdateAsync(int id, Course entity)
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
            return await Context.Course.Where(n => n.Course_Name == courseName).FirstOrDefaultAsync();
        }

        private bool CourseExists(int id)
        {
            return Context.Course.Any(u => u.Id == id);
        }
    }
}
