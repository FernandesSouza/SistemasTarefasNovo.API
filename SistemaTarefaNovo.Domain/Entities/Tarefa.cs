using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaTarefaNovo.Domain.Entities
{
    [Table("tarefas")]
    public class Tarefa
    {
        [Key]
        [Column("id_tarefa")]
        public int id_tarefa { get; set; }

        [Column("tarefa")]
        public string? tarefa { get; set; }

        [Column("descricao")]
        public string? descricao { get; set; }

        [Column("datavencimento")]
        public DateTime dataVencimento { get; set; }

        [Column("prioridade")]
        public string? prioridade { get; set; }


        public Tarefa(int id_tarefa, string? tarefa, string? descricao, DateTime dataVencimento, string? prioridade)
        {
            this.id_tarefa = id_tarefa;
            this.tarefa = tarefa;
            this.descricao = descricao;
            this.dataVencimento = dataVencimento;
            this.prioridade = prioridade;
        }
    }
}
