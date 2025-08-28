using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adicionar diretamente do env depois
        builder.Services.AddDbContext<BackendDbContext>(options => options.UseNpgsql($"HOST=localhost;Port=5432;Database=restapi;Username=postgres;Password=rest"));

        // Add services to the container.
        //Repository
        builder.Services.AddScoped<Repository.Interface.ILaboratorioRepository, Repository.LaboratorioRepository>();
        builder.Services.AddScoped<Repository.Interface.ISalaRepository, Repository.SalaRepository>();
        builder.Services.AddScoped<Repository.Interface.IFuncionarioRepository, Repository.FuncionarioRepository>();
        builder.Services.AddScoped<Repository.Interface.INotebookRepository, Repository.NotebookRepository>();
        builder.Services.AddScoped<Repository.Interface.IAlocacaoRepository, Repository.AlocacaoRepository>();

        //Services
        builder.Services.AddScoped<Service.Interface.ILaboratorioService, Service.LaboratorioService>();
        builder.Services.AddScoped<Service.Interface.ISalaService, Service.SalaService>();
        builder.Services.AddScoped<Service.Interface.IFuncionarioService, Service.FuncionarioService>();
        builder.Services.AddScoped<Service.Interface.INotebookService, Service.NotebookService>();
        builder.Services.AddScoped<Service.Interface.IAlocacaoService, Service.AlocacaoService>();

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddOpenApi();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend",
                p => p.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
            );
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowFrontend");

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
