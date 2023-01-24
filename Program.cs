using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

object data = default!;

Task.Run(async () =>
{
    while (true)
    {
        string json = await File.ReadAllTextAsync("badge-data.json", Encoding.Default);
        data = JsonSerializer.Deserialize<object>(json)!;
        await Task.Delay(TimeSpan.FromHours(1));
    }
});

app.MapGet("/", () => data);

app.Run("http://localhost:1338");