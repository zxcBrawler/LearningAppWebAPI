using System.Text.Json.Serialization;

namespace LearningAppWebAPI.Models.DTO.Simple;

public class DictionarySimpleDto
{
    [JsonPropertyName("id_dictionary")] public int Id { get; init; }
    [JsonPropertyName("dictionary_name")] public string? DictionaryName { get; set; }
    [JsonPropertyName("image_url")]  public string? ImageUrl { get; set; }
    [JsonPropertyName("words")] public List<WordSimpleDto>? Words { get; init; }
    [JsonPropertyName("user_id")] public int? UserId { get; set; }
}