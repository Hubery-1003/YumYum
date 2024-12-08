using System.Text.Encodings.Web;
using System.Text.Unicode;
using YumYum.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 註冊 cors 跨源請求
builder.Services.AddCors(options =>
{
    options.AddPolicy("Local5500", builder =>
    {
        builder.WithOrigins(
            "http://localhost:5500"
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
// 加載基礎配置
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// 加載環境專用配置
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.Encoder =
            JavaScriptEncoder.Create(
                UnicodeRanges.BasicLatin,
                UnicodeRanges.CjkUnifiedIdeographs
            );
        options.JsonSerializerOptions.WriteIndented = true;
    });




var connectionString = builder.Configuration.GetConnectionString("connectionString"); // YumYumDB
builder.Services.AddDbContext<YumYumDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddDistributedMemoryCache();
//add session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 啟用 CORS
app.UseCors("Local5500");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Recipe}/{action=Index}/{id?}");

app.Run();
