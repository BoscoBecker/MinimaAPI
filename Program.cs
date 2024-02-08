using Microsoft.EntityFrameworkCore;
using MinimaAPI.Context;
using MinimaAPI.EndPoints;

var builder = WebApplication.CreateBuilder(args);
    builder.Services
           .AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

var app = builder.Build()
                 .AddEndPoints();
    app.Run();


