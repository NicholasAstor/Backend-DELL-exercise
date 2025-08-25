using backend.Models;
using backend.Models.Dto;
using backend.Repository.Impl;
using backend.Service.Interface;

namespace backend.Service.Impl;

public class LaboratorioService(LaboratorioRepository repository) : ILaboratorioService
{
    public async Task<List<Laboratorio>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Laboratorio?> GetByIdAsync(long id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<Laboratorio> UpdateAsync(long id, LaboratorioDto dto)
    {
        return await repository.UpdateAsync(id, dto.Nome, dto.QtdComputadores, dto.Descricao);
    }
}