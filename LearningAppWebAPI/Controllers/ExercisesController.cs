using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Domain.Service.Impl;
using LearningAppWebAPI.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// The exercises controller class
    /// </summary>
    /// <seealso cref="ControllerBase"/>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "admin")]
    public class ExercisesController(IExerciseService exerciseService) : ControllerBase
    {
        // GET: api/Exercises
        /* [HttpGet]
         public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
         {
             return await _context.Exercises.ToListAsync();
         }

         // GET: api/Exercises/5
         [HttpGet("{id}")]
         public async Task<ActionResult<Exercise>> GetExercise(int id)
         {
             var exercise = await _context.Exercises.FindAsync(id);

             if (exercise == null)
             {
                 return NotFound();
             }

             return exercise;
         }

         // PUT: api/Exercises/5
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPut("{id}")]
         public async Task<IActionResult> PutExercise(int id, Exercise exercise)
         {
             if (id != exercise.Id)
             {
                 return BadRequest();
             }

             _context.Entry(exercise).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!ExerciseExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();
         }

         // POST: api/Exercises
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
         public async Task<ActionResult<Exercise>> PostExercise(Exercise exercise)
         {
             _context.Exercises.Add(exercise);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetExercise", new { id = exercise.Id }, exercise);
         }

         // DELETE: api/Exercises/5
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteExercise(int id)
         {
             var exercise = await _context.Exercises.FindAsync(id);
             if (exercise == null)
             {
                 return NotFound();
             }

             _context.Exercises.Remove(exercise);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool ExerciseExists(int id)
         {
             return _context.Exercises.Any(e => e.Id == id);
         }*/
    }
}
