namespace LearningAppWebAPI.Models.DTO.Request;

public class AddDictionaryRequestDto
{
    public required string DictionaryName { get; set; }
    public string? ImageUrl { get; set; }
}