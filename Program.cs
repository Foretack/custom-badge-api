using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string data = string.Empty;

Task.Run(async () =>
{
    while (true)
    {
        data = await File.ReadAllTextAsync("badge-data.json", Encoding.Default);
        await Task.Delay(TimeSpan.FromHours(1));
    }
});

app.MapGet("/", () => data);

app.Run("http://localhost:1338");