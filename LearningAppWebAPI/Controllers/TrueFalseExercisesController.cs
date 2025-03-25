using LearningAppWebAPI.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "exercises")]
    public class TrueFalseExercisesController(TrueFalseExerciseService trueFalseExerciseService) : ControllerBase
    {
        private readonly TrueFalseExerciseService _trueFalseExerciseService = trueFalseExerciseService;

        /* // GET: api/TrueFalseExercises
         [HttpGet]
         public async Task<ActionResult<IEnumerable<TrueFalseExercise>>> GetTrue_False_Exercises()
         {
             return await _context.True_False_Exercises.ToListAsync();
         }

         // GET: api/TrueFalseExercises/5
         [HttpGet("{id}")]
         public async Task<ActionResult<TrueFalseExercise>> GetTrueFalseExercise(int id)
         {
             var trueFalseExercise = await _context.True_False_Exercises.FindAsync(id);

             if (trueFalseExercise == null)
             {
                 return NotFound();
             }

             return trueFalseExercise;
         }

         // PUT: api/TrueFalseExercises/5
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPut("{id}")]
         public async Task<IActionResult> PutTrueFalseExercise(int id, TrueFalseExercise trueFalseExercise)
         {
             if (id != trueFalseExercise.Exercise_Id)
             {
                 return BadRequest();
             }

             _context.Entry(trueFalseExercise).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!TrueFalseExerciseExists(id))
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

         // POST: api/TrueFalseExercises
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
         public async Task<ActionResult<TrueFalseExercise>> PostTrueFalseExercise(TrueFalseExercise trueFalseExercise)
         {
             _context.True_False_Exercises.Add(trueFalseExercise);
             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateException)
             {
                 if (TrueFalseExerciseExists(trueFalseExercise.Exercise_Id))
                 {
                     return Conflict();
                 }
                 else
                 {
                     throw;
                 }
             }

             return CreatedAtAction("GetTrueFalseExercise", new { id = trueFalseExercise.Exercise_Id }, trueFalseExercise);
         }

         // DELETE: api/TrueFalseExercises/5
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteTrueFalseExercise(int id)
         {
             var trueFalseExercise = await _context.True_False_Exercises.FindAsync(id);
             if (trueFalseExercise == null)
             {
                 return NotFound();
             }

             _context.True_False_Exercises.Remove(trueFalseExercise);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool TrueFalseExerciseExists(int id)
         {
             return _context.True_False_Exercises.Any(e => e.Exercise_Id == id);
         }*/
    }
}
