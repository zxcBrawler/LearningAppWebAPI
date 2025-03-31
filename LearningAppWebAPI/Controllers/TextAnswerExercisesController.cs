using LearningAppWebAPI.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// The text answer exercises controller class
    /// </summary>
    /// <seealso cref="ControllerBase"/>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "admin")]
    public class TextAnswerExercisesController(TextAnswerExerciseService textAnswerExerciseService) : ControllerBase
    {
        /*
        // GET: api/TextAnswerExercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TextAnswerExercise>>> GetText_Answer_Exercises()
        {
            return await _context.Text_Answer_Exercises.ToListAsync();
        }

        // GET: api/TextAnswerExercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TextAnswerExercise>> GetTextAnswerExercise(int id)
        {
            var textAnswerExercise = await _context.Text_Answer_Exercises.FindAsync(id);

            if (textAnswerExercise == null)
            {
                return NotFound();
            }

            return textAnswerExercise;
        }

        // PUT: api/TextAnswerExercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTextAnswerExercise(int id, TextAnswerExercise textAnswerExercise)
        {
            if (id != textAnswerExercise.Exercise_Id)
            {
                return BadRequest();
            }

            _context.Entry(textAnswerExercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextAnswerExerciseExists(id))
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

        // POST: api/TextAnswerExercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TextAnswerExercise>> PostTextAnswerExercise(TextAnswerExercise textAnswerExercise)
        {
            _context.Text_Answer_Exercises.Add(textAnswerExercise);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TextAnswerExerciseExists(textAnswerExercise.Exercise_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTextAnswerExercise", new { id = textAnswerExercise.Exercise_Id }, textAnswerExercise);
        }

        // DELETE: api/TextAnswerExercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTextAnswerExercise(int id)
        {
            var textAnswerExercise = await _context.Text_Answer_Exercises.FindAsync(id);
            if (textAnswerExercise == null)
            {
                return NotFound();
            }

            _context.Text_Answer_Exercises.Remove(textAnswerExercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TextAnswerExerciseExists(int id)
        {
            return _context.Text_Answer_Exercises.Any(e => e.Exercise_Id == id);
        }*/
    }
}
