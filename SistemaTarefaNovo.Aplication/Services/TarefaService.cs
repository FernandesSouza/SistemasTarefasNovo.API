using AutoMapper;
using SistemaTarefaNovo.Aplication.DTOs;
using SistemaTarefaNovo.Aplication.Interfaces;
using SistemaTarefaNovo.Domain.Entities;
using SistemaTarefaNovo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefaNovo.Aplication.Services
{
    public class TarefaService : ITarefaService
    {

        private readonly IBaseRepository<Tarefa> _repository;
        private readonly IMapper _mapper;

        public TarefaService(IBaseRepository<Tarefa> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CadastrarTarefa(TarefaDTO tarefaDTO)
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaDTO);
            await _repository.AddAsync(tarefa);

            
        }

        public async Task<IEnumerable<TarefaDTO>> GetAll()
        {
            var tarefa = await _repository.GetAll();
            return _mapper.Map<IEnumerable<TarefaDTO>>(tarefa);
        }

        public async Task<TarefaDTO> GetById(int id)
        {
            var tarefa = await _repository.GetById(id);
            return _mapper.Map<TarefaDTO>(tarefa);

        }

        public async Task<TarefaDTO> Update(TarefaDTO tarefaDTO)
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaDTO);
            await _repository.UpdateAsync(tarefa);
            return _mapper.Map<TarefaDTO>(tarefa);

        }
    }
}
