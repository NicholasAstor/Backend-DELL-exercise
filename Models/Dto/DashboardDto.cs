namespace backend.Models.Dto;

public record DashboardDto(
    DateTime Data,
    int NotesTotais,
    int NotesLivres,
    int SalasTotais,
    int SalasLivres,
    int LabsTotais,
    int LabsLivres
    )
{
}