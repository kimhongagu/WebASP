using BTTH03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BTTH03Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BTTH03Context") ?? throw new InvalidOperationException("Connection string 'BTTH03Context' not found.")));

var app = builder.Build();

async Task CreateDBAsync(WebApplication app)
{
	using (var scope = app.Services.CreateScope())
	{
		var services = scope.ServiceProvider;
		try
		{
			var context = services.GetRequiredService<BTTH03Context>();
			await context.Database.EnsureCreatedAsync();
			//try
			//{
				InitData.Initialize(context);
			//}
			//catch (Exception initDataEx)
			//{
			//	var logger = services.GetRequiredService<ILogger<Program>>();
			//	logger.LogError(initDataEx, "Lỗi khi khởi tạo dữ liệu.");
			//}
		}
		catch (Exception ex)
		{
			var logger = services.GetRequiredService<ILogger<Program>>();
			logger.LogError(ex, "Lỗi tạo DB.");
		}
	}
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
