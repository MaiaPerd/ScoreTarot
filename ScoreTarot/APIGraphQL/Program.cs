using APIGraphQL.Query;
using APIGraphQL.Mappers;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddDbContext<SQLiteContext>(option=>option.UseSqlite($"Data Source=../EntityFramework/baseTarotScore.db;"))
    .AddScoped<DataManagerAPI>()
    .AddAutoMapper(typeof(Mapper))
    .AddGraphQLServer()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
