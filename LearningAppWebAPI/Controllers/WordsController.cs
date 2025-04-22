
using AutoMapper;
using LearningAppWebAPI.Domain.Profiles;
using LearningAppWebAPI.Domain.Service.Interface;
using LearningAppWebAPI.Models.DTO.Response;
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
    public class WordsController(MerriamWebsterSearch search, IWordService wordService) : BasicController
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="dictionaryId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddWord([FromBody] MerriamWebsterResponseDto word, int dictionaryId)
        {
            var result = await wordService.AddWord(word, dictionaryId, UserId);
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
        }
    }
}
