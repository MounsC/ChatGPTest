using System.Text;
using System.Text.Json;

string apiKey = "API_KEY";
string url = "https://api.openai.com/v1/completions";

while (true)
{
    Console.WriteLine("___________________");
    Console.Write("Question : ");
    string input = Console.ReadLine();

    if (input.ToLower() == "exit")
    {
        break;
    }

    var request = new
    {
        model = "text-davinci-003",
        prompt = input,
        temperature = 0.5,
        max_tokens = 1024,
    };

    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, content);
        var responseString = await response.Content.ReadAsStringAsync();

        ChatResponse json = JsonSerializer.Deserialize<ChatResponse>(responseString);

        Console.WriteLine(json.Choices[0].Text);
    }
}