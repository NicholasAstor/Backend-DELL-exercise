using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class Laboratorio
{
    [Key]
    public long IdLaboratorio {get; set;}
    
    [Required]
    public string Nome {get; set;}
    
    [Required]
    public int QtdComputadores  {get; set;}
    
    [Required]
    public string Descricao {get; set;}
}