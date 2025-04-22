﻿namespace LearningAppWebAPI.Models.DTO.Response;

public class MerriamWebsterResponseDto
{
    public string Headword { get; set; }
    public PronunciationResponseDto? Pronunciation { get; set; }
    public List<string> ShortDefinitions { get; set; }
    public string PartOfSpeech { get; set; }
}