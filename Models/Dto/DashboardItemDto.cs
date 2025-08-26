using backend.Models.Enums;

namespace backend.Models.Dto;

public record DashboardItemDto(TipoRecurso TipoRecurso, long Id, object Info);