namespace LearningAppWebAPI.Models.DTO.Response;

public class PronunciationResponseDto
{
    public Uri AudioLink { get; set; }
    public string Pronunciation { get; set; }
}