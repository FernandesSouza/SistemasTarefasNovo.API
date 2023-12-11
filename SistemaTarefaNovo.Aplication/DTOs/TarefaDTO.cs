using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTarefaNovo.Aplication.DTOs
{
   public class TarefaDTO
   {

        
    
        public int id_tarefa { get; set; }

        public string? tarefa { get; set; }

        public string? descricao { get; set; }
        
        public DateTime dataVencimento { get; set; }

        public string? prioridade { get; set; }

        public TarefaDTO(int id_tarefa, string? tarefa, string? descricao, DateTime dataVencimento, string? prioridade)
        {
            this.id_tarefa = id_tarefa;
            this.tarefa = tarefa;
            this.descricao = descricao;
            this.dataVencimento = dataVencimento;
            this.prioridade = prioridade;
        }

    }
}
