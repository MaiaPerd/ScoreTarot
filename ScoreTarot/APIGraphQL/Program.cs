using APIGraphQL.Query;
using APIGraphQL.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddAutoMapper(typeof(Mapper))
    .AddGraphQLServer()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
