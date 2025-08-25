using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class Notebook
{
    [Key]
    public long IdNotebook {get; set;}
    
    [Required]
    public int NumeroPatrimonio {get; set;}
    
    [Required]
    public DateTime DataAquisicao {get; set;}
    
    [Required]
    public string Descricao {get; set;}
}