namespace backend.Models.Dto;

public class HomeDto
{
    public List<NotebookDto> Notebooks { get; set; } = [];
    public List<SalaDto> Salas { get; set; } = [];
    public List<LaboratorioDto> Laboratorios { get; set; } = [];
}