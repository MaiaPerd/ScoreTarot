using APIGraphQL.Query;
using APIGraphQL.Mappers;
using EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddDbContext<SQLiteContext>()
    .AddAutoMapper(typeof(Mapper))
    .AddGraphQLServer()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
