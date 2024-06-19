using System.Text.Json.Serialization;

namespace _7DaysOfCode.Modelos;

internal class Abilitie
{
    [JsonPropertyName("name")]
    public string AbilitieName { get; set; }
    [JsonPropertyName("url")]
    public string Url { get; set; }

}
