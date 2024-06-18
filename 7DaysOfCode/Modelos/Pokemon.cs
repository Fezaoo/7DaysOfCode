using System.Text.Json.Serialization;

namespace _7DaysOfCode.Modelos;

internal class Pokemon
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("url")]
    public string? Url { get; set; }
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    [JsonPropertyName("height")]
    public int? Height { get; set; }
    [JsonPropertyName("weight")]
    public int? Weight { get; set; }
}
