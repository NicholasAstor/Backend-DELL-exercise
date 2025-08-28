public class RecursoDto
{
    public long Id { get; set; }
    public string Tipo { get; set; }
    public string NomeOuDescricao { get; set; }
    public bool Disponivel { get; set; }
    public DateOnly? DataReserva { get; set; }
}