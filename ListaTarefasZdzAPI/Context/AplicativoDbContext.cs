using ListaTarefasZdzAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefasZdzAPI.Context
{
    public class AplicativoDbContext : DbContext
    {
        public AplicativoDbContext(DbContextOptions<AplicativoDbContext> options) : base(options)
        {
        }

        public DbSet<Tarefa>Tarefas{get;set;}
    }
}
