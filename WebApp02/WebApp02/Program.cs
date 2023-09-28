var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
var app = builder.Build();



var options = new DefaultFilesOptions();
options.DefaultFileNames.Add("default.html");
app.UseDefaultFiles(options);

app.MapRazorPages();

app.UseStaticFiles();
//app.MapGet("/", () => "Hello World!");

app.Run();
