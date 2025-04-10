using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Domain.Service.Impl;
using LearningAppWebAPI.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// The multiple choice exercises controller class
    /// </summary>
    /// <seealso cref="ControllerBase"/>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "admin")]
    public class MultipleChoiceExercisesController(IMultipleChoiceExerciseService multipleChoiceExerciseService) : ControllerBase
    {
        // GET: api/MultipleChoiceExercises
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<MultipleChoiceExercise>>> GetMultiple_Choice_Exercises()
        {
            return await _context.Multiple_Choice_Exercises.ToListAsync();
        }

        // GET: api/MultipleChoiceExercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MultipleChoiceExercise>> GetMultipleChoiceExercise(int id)
        {
            var multipleChoiceExercise = await _context.Multiple_Choice_Exercises.FindAsync(id);

            if (multipleChoiceExercise == null)
            {
                return NotFound();
            }

            return multipleChoiceExercise;
        }

        // PUT: api/MultipleChoiceExercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMultipleChoiceExercise(int id, MultipleChoiceExercise multipleChoiceExercise)
        {
            if (id != multipleChoiceExercise.Exercise_Id)
            {
                return BadRequest();
            }

            _context.Entry(multipleChoiceExercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultipleChoiceExerciseExists(id))
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

        // POST: api/MultipleChoiceExercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MultipleChoiceExercise>> PostMultipleChoiceExercise(MultipleChoiceExercise multipleChoiceExercise)
        {
            _context.Multiple_Choice_Exercises.Add(multipleChoiceExercise);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MultipleChoiceExerciseExists(multipleChoiceExercise.Exercise_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMultipleChoiceExercise", new { id = multipleChoiceExercise.Exercise_Id }, multipleChoiceExercise);
        }

        // DELETE: api/MultipleChoiceExercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMultipleChoiceExercise(int id)
        {
            var multipleChoiceExercise = await _context.Multiple_Choice_Exercises.FindAsync(id);
            if (multipleChoiceExercise == null)
            {
                return NotFound();
            }

            _context.Multiple_Choice_Exercises.Remove(multipleChoiceExercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MultipleChoiceExerciseExists(int id)
        {
            return _context.Multiple_Choice_Exercises.Any(e => e.Exercise_Id == id);
        }*/
    }
}
