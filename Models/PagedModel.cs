namespace backend.Models;

public record PagedModel<T>(int Pagina, int Tamanho, int NumeroItems, int NumeroPaginas, IEnumerable<T> ListaItems);