
using AutoMapper;
using LearningAppWebAPI.Domain.Profiles;
using MerriamWebster.NET;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "admin")]
    [ApiController]
    public class WordsController(MerriamWebsterSearch search) : BasicController
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
            return Ok(result.Entries.Select(DictionaryEntryCustomMapper.MapToDto));
        }
    }
}
