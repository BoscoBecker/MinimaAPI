using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using MinimaAPI.Context;
using MinimaAPI.EndPoints;
using MinimaAPI.Entidade;

var builder = WebApplication.CreateBuilder(args);
    builder.Services
           .AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

var app = builder.Build()
                 .AddEndPoints();
    app.Run();


