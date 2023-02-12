using APIRest.MapperClass;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SQLiteContext>(option => option.UseSqlite($"Data Source=../EntityFramework/baseTarotScore.db"));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperApiREST));
builder.Services.AddControllersWithViews();

builder.Services.AddApiVersioning(option =>
{
    option.AssumeDefaultVersionWhenUnspecified = true;
    option.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseApiVersioning();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
