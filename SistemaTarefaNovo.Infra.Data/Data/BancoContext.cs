using Microsoft.EntityFrameworkCore;
using SistemaTarefaNovo.Domain.Entities;



namespace SistemaTarefaNovo.Infra.Data.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<Pessoa> pessoa { get; set; }
        public DbSet<Tarefa> tarefa { get; set; }
    }
}
