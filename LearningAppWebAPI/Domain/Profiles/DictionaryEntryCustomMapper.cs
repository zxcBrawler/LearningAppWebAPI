using LearningAppWebAPI.Models.DTO.Response;
using MerriamWebster.NET.Results;

namespace LearningAppWebAPI.Domain.Profiles;

/// <summary>
/// 
/// </summary>
public static class DictionaryEntryCustomMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="resultModel"></param>
    /// <returns></returns>
    public static MerriamWebsterResponseDto MapToDto(Entry resultModel)
    {
        return new MerriamWebsterResponseDto
        {
            Headword = resultModel.Headword.Text?.Replace("*", "") ?? string.Empty,
            PartOfSpeech = resultModel.FunctionalLabel,
            Pronunciation = resultModel.Headword.Pronunciations != null ? resultModel.Headword.Pronunciations.Select(p => new PronunciationResponseDto()
            {
                AudioLink = p.AudioLink ?? new Uri(""),
                Pronunciation = p.WrittenPronunciation,
            }).FirstOrDefault() : new PronunciationResponseDto(),
            ShortDefinitions = resultModel.ShortDefs.ToList()
        };
    }
}