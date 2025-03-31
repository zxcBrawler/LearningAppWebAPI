using LearningAppWebAPI.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// The type exercises controller class
    /// </summary>
    /// <seealso cref="ControllerBase"/>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "admin")]
    public class TypeExercisesController(TypeExerciseService typeExerciseService) : ControllerBase
    {
        /*// GET: api/TypeExercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeExercise>>> GetType_Exercise()
        {
            return await _context.Type_Exercise.ToListAsync();
        }

        // GET: api/TypeExercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeExercise>> GetTypeExercise(int id)
        {
            var typeExercise = await _context.Type_Exercise.FindAsync(id);

            if (typeExercise == null)
            {
                return NotFound();
            }

            return typeExercise;
        }

        // PUT: api/TypeExercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeExercise(int id, TypeExercise typeExercise)
        {
            if (id != typeExercise.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeExercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExerciseExists(id))
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

        // POST: api/TypeExercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeExercise>> PostTypeExercise(TypeExercise typeExercise)
        {
            _context.Type_Exercise.Add(typeExercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeExercise", new { id = typeExercise.Id }, typeExercise);
        }

        // DELETE: api/TypeExercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeExercise(int id)
        {
            var typeExercise = await _context.Type_Exercise.FindAsync(id);
            if (typeExercise == null)
            {
                return NotFound();
            }

            _context.Type_Exercise.Remove(typeExercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeExerciseExists(int id)
        {
            return _context.Type_Exercise.Any(e => e.Id == id);
        }*/
    }
}
