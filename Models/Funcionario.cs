using System.ComponentModel.DataAnnotations;
using backend.Models.Enums;

namespace backend.Models;

public class Funcionario
{
    
    [Key]
    public long IdFuncionario { get; set; }
    
    [Required]
    public int Matricula { get; set; }
    
    [Required]
    public string Nome { get; set; }
    
    [Required]
    public CargoFuncionario Cargo { get; set; }
    
    [Required]
    public DateTime DataAdmissao { get; set; }
    
}