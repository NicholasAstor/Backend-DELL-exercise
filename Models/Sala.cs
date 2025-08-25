using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class Sala
{
    [Key]
    public long IdSala { get; set; }
    
    [Required]
    public int Numero {get; set;}
    
    public int QtdLugares {get; set;}
    
    [Required]
    public bool TemProjetor {get; set;}
}