namespace backend.Models.Dto
{
    public class HomeViewDto
    {
        public IEnumerable<NotebookDto> Notebooks { get; set; }
        public IEnumerable<LaboratorioDto> Laboratorios { get; set; }
        public IEnumerable<Alocacao> Alocacoes { get; set; }
        public IEnumerable<SalaDto> Salas { get; set; }
    }
}