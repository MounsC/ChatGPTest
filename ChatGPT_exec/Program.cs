using System.Text;
using Newtonsoft.Json;

string apiKey = "OPENAI_API_KEY";
string url = "https://api.openai.com/v1/completions";

while (true)
{
    Console.WriteLine("___________________");
    Console.Write("Question : "); // bof
    string input = Console.ReadLine();

    if (input.ToLower() == "exit")
    {
        break;
    }

    var request = new
    {
        model = "text-davinci-003",
        prompt = input,
        temperature = 0.5, // maxValue = 2, 2 = AI works like a drunk guy
        max_tokens = 1024,
        stop = "",
    }; // tricky but ok

    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        var response = client.PostAsync(url, content).Result;
        var responseString = response.Content.ReadAsStringAsync().Result;

        dynamic json = JsonConvert.DeserializeObject(responseString);

        Console.WriteLine(json.choices[0].text);
    }
}