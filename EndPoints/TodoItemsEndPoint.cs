using Microsoft.EntityFrameworkCore;
using MinimaAPI.Context;
using MinimaAPI.Entidade;

namespace MinimaAPI.EndPoints
{
    public static class TodoItemsEndPoint
    {
        public static WebApplication AddEndPoints(this WebApplication app)
        {

            app.MapGet("/", () => "Hello World!");
            app.MapGet("/todoitems", async (TodoDb db) => await db.Todos.ToListAsync());
            app.MapGet("/todoitems/complete", async (TodoDb db) => await db.Todos.Where(t => t.IsComplete).ToListAsync());
            app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
            await db.Todos.FindAsync(id) is Todo todo
                                         ? Results.Ok(todo)
                                         : Results.NotFound());

            app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
            {
                db.Todos.Add(todo);
                await db.SaveChangesAsync();
                return Results.Created($"/todositems/{todo.Id}", todo);
            });

            app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
            {
                if (await db.Todos.FindAsync(id) is Todo todo)
                {
                    todo.Name = inputTodo.Name;
                    todo.IsComplete = inputTodo.IsComplete;
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                } else return Results.NotFound();
            });

            app.MapDelete("/todoitems{id}", async (int id, TodoDb db) =>
            {
                if (await db.Todos.FindAsync(id) is Todo todo)
                {
                    db.Todos.Remove(todo);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                } else return Results.NotFound();
            });

            return app;
        }

    }
}
