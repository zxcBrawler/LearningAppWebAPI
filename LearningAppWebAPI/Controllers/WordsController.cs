
using MerriamWebster.NET;
using MerriamWebster.NET.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "admin")]
    [ApiController]
    public class WordsController(MerriamWebsterSearch search) : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestWord"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetWordFromDictionary(string requestWord)
        {
            
            var result = await search.SearchCollegiateDictionary(requestWord);
           
            foreach (var entry in result.Entries)            
            {
                foreach (var definition in entry.Definitions)
                {
                    foreach (var senseSequence in definition.SenseSequence)  
                    {
                        foreach (var sense in senseSequence.Senses.OfType<Sense>())
                        {
                            foreach (var definingText in sense.DefiningTexts)
                            {
                                string text = definingText.MainText;
                                return Ok(text);
                            }
                        }
                    }
                }
            }
            return NotFound();
        }
    }
}
