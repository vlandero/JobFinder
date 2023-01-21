using Microsoft.EntityFrameworkCore;
using Tema.Helpers;
using Tema.Helpers.Extensions;
using Tema.Helpers.Middleware;
using Tema.Models;
using Tema.Models.Users.Finder;
using Tema.Models.Users.Seeker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyAppContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DB")));
builder.Services.AddUtils();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.UseCors("corsapp");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.UseMiddleware<JwtMiddleware<Seeker>>();
app.UseMiddleware<JwtMiddleware<Finder>>();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
