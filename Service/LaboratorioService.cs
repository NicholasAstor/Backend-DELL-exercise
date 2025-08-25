using System.Globalization;
using backend.Models;
using backend.Models.Dto;
using backend.Repository;
using backend.Repository.Interface;
using backend.Service.Interface;

namespace backend.Service;

public class LaboratorioService : ILaboratorioService
{
    private readonly ILaboratorioRepository _repository;

    public LaboratorioService(ILaboratorioRepository repo)
    {
        _repository = repo;
    }
    public async Task<IEnumerable<LaboratorioDto>> GetAllAsync()
    {
        var laboratorios = await _repository.GetAllAsync();

        var result = laboratorios.Select(l => new LaboratorioDto(l.Nome, l.QtdComputadores, l.Descricao)).ToList();

        return result;
    }

    public async Task<LaboratorioDto?> GetByIdAsync(long id)
    {
        var laboratorio = await _repository.GetByIdAsync(id);

        var result = new LaboratorioDto(laboratorio.Nome, laboratorio.QtdComputadores, laboratorio.Descricao);

        return result;
    }

    public async Task<LaboratorioDto> UpdateAsync(long id, LaboratorioDto dto)
    {
        var updatedLab = await _repository.UpdateAsync(id, dto.Nome, dto.QtdComputadores, dto.Descricao);

        var result = new LaboratorioDto(updatedLab.Nome, updatedLab.QtdComputadores, updatedLab.Descricao);

        return result;
    }
}