using System.Text.Json.Serialization;

public class ChatResponse
{
    public class ChatChoice
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
    [JsonPropertyName("choices")]
    public ChatChoice[] Choices { get; set; }
}