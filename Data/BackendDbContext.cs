using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class BackendDbContext : DbContext
    {
        public DbSet<Alocacao> Alocacoes { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Sala> Salas { get; set; }

        public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql()
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
        }
    }
}