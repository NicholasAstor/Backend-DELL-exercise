namespace backend.Models.Dto
{
    public record CreateNotebookDto(int NumeroPatrimonio, DateOnly DataAquisicao, string Descricao);
}