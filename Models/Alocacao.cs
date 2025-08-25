using System.ComponentModel.DataAnnotations;
using backend.Models.Enums;

namespace backend.Models;

public class Alocacao
{
    [Key]
    public long IdAlocacao {get; set;}
    
    [Required]
    public long IdFuncionario {get; set;}
    
    [Required]
    public Funcionario Funcionario {get; set;}
    
    [Required]
    public long IdRecurso {get; set;}
    
    [Required]
    public TipoRecurso TipoRecurso {get; set;}
    
    [Required]
    public DateTime DataReserva {get; set;}
    
    [Required]
    public DateTime DataCriacao  {get; set;}
    
    
}