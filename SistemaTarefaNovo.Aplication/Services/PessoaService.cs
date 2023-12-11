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
    public class PessoaService : IPessoaService
    {
        private readonly IBaseRepository<Pessoa> _repository;
        private readonly IMapper _mapper;

        public PessoaService(IBaseRepository<Pessoa> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public  async Task CadastrarPessoa(PessoaDTO pessoaDTO)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);
            await _repository.AddAsync(pessoa);          

        }

        public async Task<bool> DeletarPessoa(int id)
        { 
            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<PessoaDTO>> GetAll()
        {
            var pessoas = await _repository.GetAll();
            return _mapper.Map<IEnumerable<PessoaDTO>>(pessoas);
        }

        public async Task<PessoaDTO> GetById(int id)
        {
            var pessoa = await _repository.GetById(id);
            return _mapper.Map<PessoaDTO>(pessoa);
        }

        public async Task<PessoaDTO> Update(PessoaDTO pessoaDTO)
        {

            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);
            await _repository.UpdateAsync(pessoa);
            return _mapper.Map<PessoaDTO>(pessoa);
            
        }
    }
}
