using SistemaTarefaNovo.Aplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefaNovo.Aplication.Interfaces
{
    public interface ITarefaService
    {
        Task CadastrarTarefa(TarefaDTO tarefaDTO);
        Task<TarefaDTO> GetById(int id);
        Task<IEnumerable<TarefaDTO>> GetAll();
        Task<TarefaDTO> Update(TarefaDTO tarefaDTO);

    }
}
