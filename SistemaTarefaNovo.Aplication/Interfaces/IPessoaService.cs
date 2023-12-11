using SistemaTarefaNovo.Aplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefaNovo.Aplication.Interfaces
{
   public interface IPessoaService
   {
        Task CadastrarPessoa(PessoaDTO pessoa);
        Task<bool> DeletarPessoa(int id);
        Task<PessoaDTO> GetById(int id);
        Task<IEnumerable<PessoaDTO>> GetAll();
        Task<PessoaDTO> Update(PessoaDTO pessoa);
    }
}
