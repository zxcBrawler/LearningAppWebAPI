
using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Complex;
using LearningAppWebAPI.Models.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// The options controller class
    /// </summary>
    /// <seealso cref="ControllerBase"/>
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController(OptionService optionService) : ControllerBase
    {
        /* // GET: api/Options
         [HttpGet]
         public async Task<ActionResult<IEnumerable<Option>>> GetOptions()
         {
             return await _context.Options.ToListAsync();
         }*/

        // GET: api/Options/5
        /// <summary>
        /// Gets the option using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing an action result of option complex dto</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OptionComplexDto>> GetOption(int id)
        {
            var option = await optionService.GetOption(id);

            if (option == null)
            {
                return NotFound();
            }

            return Ok(option);
        }

        /* // PUT: api/Options/5
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPut("{id}")]
         public async Task<IActionResult> PutOption(int id, Option option)
         {
             if (id != option.Id)
             {
                 return BadRequest();
             }

             _context.Entry(option).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!OptionExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();
         }*/

        // POST: api/Options
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Posts the option using the specified dto
        /// </summary>
        /// <param name="dto">The dto</param>
        /// <returns>A task containing an action result of option</returns>
        [HttpPost]
        public async Task<ActionResult<Option>> PostOption(AddOptionDto dto)
        {
            var result = await optionService.CreateOption(dto);
            if (result == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetOption", new { id = result.Id }, result);
        }

        /* // DELETE: api/Options/5
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteOption(int id)
         {
             var option = await _context.Options.FindAsync(id);
             if (option == null)
             {
                 return NotFound();
             }

             _context.Options.Remove(option);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool OptionExists(int id)
         {
             return _context.Options.Any(e => e.Id == id);
         }*/
    }
}
