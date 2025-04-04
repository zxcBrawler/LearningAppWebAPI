using LearningAppWebAPI.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dictionaryService"></param>
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "admin")]
    [ApiController]
    public class DictionariesController(DictionaryService dictionaryService) : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllDictionary()
        {
            var dictionaries = await dictionaryService.GetAllByUserIdAsync(9);
            return Ok(dictionaries);
        }
    }
}
