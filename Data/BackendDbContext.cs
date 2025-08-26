using backend.Models;
using backend.Models.Enums;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Funcionario f1;
            Funcionario f2;
            Funcionario f3;
            Funcionario f4;
            Funcionario f5;

            Sala s1;
            Sala s2;
            Sala s3;
            Sala s4;
            Sala s5;

            Laboratorio l1;
            Laboratorio l2;
            Laboratorio l3;
            Laboratorio l4;
            Laboratorio l5;

            Notebook n1;
            Notebook n2;
            Notebook n3;
            Notebook n4;
            Notebook n5;

            // Funcionários
            modelBuilder.Entity<Funcionario>().HasData(
                f1 = new Funcionario { IdFuncionario = 1, Matricula = 100167, Nome = "Nicholas Navarro", Cargo = CargoFuncionario.Desenvolvedor, DataAdmissao = new DateTime(2025, 8, 20, 12, 0, 0).ToUniversalTime() },
                f2 = new Funcionario { IdFuncionario = 2, Matricula = 100168, Nome = "Júlia Schivisnky", Cargo = CargoFuncionario.Desenvolvedor, DataAdmissao = new DateTime(2025, 8, 20, 12, 0, 0).ToUniversalTime() },
                f3 = new Funcionario { IdFuncionario = 3, Matricula = 100169, Nome = "Ellen", Cargo = CargoFuncionario.Desenvolvedor, DataAdmissao = new DateTime(2025, 8, 20, 12, 0, 0).ToUniversalTime() },
                f4 = new Funcionario { IdFuncionario = 4, Matricula = 100170, Nome = "Henrique Coralles", Cargo = CargoFuncionario.Desenvolvedor, DataAdmissao = new DateTime(2025, 8, 20, 12, 0, 0).ToUniversalTime() },
                f5 = new Funcionario { IdFuncionario = 5, Matricula = 101010, Nome = "MR Gabriel Velloso", Cargo = CargoFuncionario.Diretor, DataAdmissao = new DateTime(2025, 8, 20, 12, 0, 0).ToUniversalTime() }
            );

            // Salas
            modelBuilder.Entity<Sala>().HasData(
                s1 = new Sala { IdSala = 1, Numero= 101, QtdLugares = 30, TemProjetor = true },
                s2 = new Sala { IdSala = 2, Numero= 102, QtdLugares = 20, TemProjetor = false },
                s3 = new Sala { IdSala = 3, Numero= 103, QtdLugares = 25, TemProjetor = true },
                s4 = new Sala { IdSala = 4, Numero= 104, QtdLugares = 15, TemProjetor = false },
                s5 = new Sala { IdSala = 5, Numero= 105, QtdLugares = 40, TemProjetor = true }
            );

            // Laboratórios
            modelBuilder.Entity<Laboratorio>().HasData(
                l1 = new Laboratorio { IdLaboratorio = 1, Nome = "Lab Redes", QtdComputadores = 20, Descricao = "Computadores Core i5, 8GB RAM" },
                l2 = new Laboratorio { IdLaboratorio = 2, Nome = "Lab Desenvolvimento", QtdComputadores = 25, Descricao = "Core i7, 16GB RAM, SSD" },
                l3 = new Laboratorio { IdLaboratorio = 3, Nome = "Lab Hardware", QtdComputadores = 15, Descricao = "Core i5, 8GB RAM, kits de hardware" },
                l4 = new Laboratorio { IdLaboratorio = 4, Nome = "Lab Inteligência Artificial", QtdComputadores = 10, Descricao = "Core i9, 32GB RAM, GPU dedicada" },
                l5 = new Laboratorio { IdLaboratorio = 5, Nome = "Lab Banco de Dados", QtdComputadores = 18, Descricao = "Core i5, 16GB RAM" }
            );

            // Notebooks
            modelBuilder.Entity<Notebook>().HasData(
                n1 = new Notebook { IdNotebook = 1, NumeroPatrimonio = 1001, DataAquisicao = new DateTime(2023, 8, 20, 12, 0, 0).ToUniversalTime(), Descricao = "Dell Inspiron i5" },
                n2 = new Notebook { IdNotebook = 2, NumeroPatrimonio = 1002, DataAquisicao = new DateTime(2022, 8, 20, 12, 0, 0).ToUniversalTime(), Descricao = "HP Elitebook i7" },
                n3 = new Notebook { IdNotebook = 3, NumeroPatrimonio = 1003, DataAquisicao = new DateTime(2024, 8, 20, 12, 0, 0).ToUniversalTime(), Descricao = "Lenovo Thinkpad i5" },
                n4 = new Notebook { IdNotebook = 4, NumeroPatrimonio = 1004, DataAquisicao = new DateTime(2021, 8, 20, 12, 0, 0).ToUniversalTime(), Descricao = "Acer Aspire i3" },
                n5 = new Notebook { IdNotebook = 5, NumeroPatrimonio = 1005, DataAquisicao = new DateTime(2019, 8, 20, 12, 0, 0).ToUniversalTime(), Descricao = "Macbook Air M1" }
            );

            // Alocações
            modelBuilder.Entity<Alocacao>().HasData(
                new Alocacao { IdAlocacao = 1, FuncionarioId = f1.IdFuncionario, IdRecurso = n1.IdNotebook, TipoRecurso= TipoRecurso.Notebook, DataReserva = new DateTime(2025, 8, 27).ToUniversalTime(), DataCriacao = new DateTime(2025, 8, 20, 12, 0, 0).ToUniversalTime() },
                new Alocacao { IdAlocacao = 2, FuncionarioId = f2.IdFuncionario, IdRecurso = l2.IdLaboratorio, TipoRecurso = TipoRecurso.Laboratorio, DataReserva = new DateTime(2025, 8, 27).AddDays(1).ToUniversalTime(), DataCriacao = new DateTime(2025, 8, 20, 12, 0, 0).ToUniversalTime() },
                new Alocacao { IdAlocacao = 3, FuncionarioId = f3.IdFuncionario, IdRecurso = s4.IdSala, TipoRecurso = TipoRecurso.Sala,DataReserva = new DateTime(2025, 8, 27).AddDays(2).ToUniversalTime(), DataCriacao = new DateTime(2025, 8, 20, 12, 0, 0).ToUniversalTime() },
                new Alocacao { IdAlocacao = 4, FuncionarioId = f4.IdFuncionario, IdRecurso = n4.IdNotebook, TipoRecurso = TipoRecurso.Notebook, DataReserva = new DateTime(2025, 8, 27).AddDays(3).ToUniversalTime(), DataCriacao = new DateTime(2025, 8, 20, 12, 0, 0).ToUniversalTime() },
                new Alocacao { IdAlocacao = 5, FuncionarioId = f5.IdFuncionario, IdRecurso = l1.IdLaboratorio, TipoRecurso = TipoRecurso.Laboratorio, DataReserva = new DateTime(2025, 8, 27).AddDays(4).ToUniversalTime(), DataCriacao = new DateTime(2025, 8, 20, 12, 0, 0).ToUniversalTime() }
            );
        }
    }
}