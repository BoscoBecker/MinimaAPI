using Microsoft.EntityFrameworkCore;
using MinimaAPI.Entidade;

namespace MinimaAPI.Context
{
    class TodoDb: DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> option) : base(option) { }
        public DbSet<Todo> Todos => Set<Todo>();
    }
}
