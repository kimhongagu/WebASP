﻿//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using QLSV.Data;
//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();
//builder.Services.AddDbContext<QLSVContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("QLSVContext") ?? throw new InvalidOperationException("Connection string 'QLSVContext' not found.")));

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

//app.Run();


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLSV.Data;
using QLSV.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<QLSVContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLSVContext") ?? throw new InvalidOperationException("Connection string 'QLSVContext' not found.")));

var app = builder.Build();

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Lỗi khởi tạo dữ liệu.");
    }
}

app.Run();
