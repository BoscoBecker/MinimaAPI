using Microsoft.EntityFrameworkCore;
using MinimaAPI.Context;
using MinimaAPI.EndPoints;

class Program
{
    public static void main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

        var app = builder.Build().AddEndPoints();
            app.Run();
    }
}