using FluentValidation;
using SistemaTarefaNovo.Aplication.DTOs;

namespace SistemasTarefasNovo.API.Validation
{
    public class TarefaValidation : AbstractValidator<TarefaDTO>
    {

        public TarefaValidation()
        {
            RuleFor(tarefa => tarefa.tarefa).NotEmpty().WithMessage("A tarefa é obrigatória.");
            RuleFor(tarefa => tarefa.descricao).NotEmpty().WithMessage("A descrição é obrigatória.");
            RuleFor(tarefa => tarefa.dataVencimento)
            .NotEmpty().WithMessage("A data de vencimento é obrigatória.")
            .Must(BeValidDateTime).WithMessage("A data de vencimento deve ser uma data e hora válidas.");
            RuleFor(tarefa => tarefa.prioridade).NotEmpty().WithMessage("A prioridade é obrigatória.");
            RuleFor(tarefa => tarefa.id_tarefa).NotEmpty().WithMessage("Não pode ser vazio");
        }

        private bool BeValidDateTime(DateTime dataVencimento)
        {
            

            dataVencimento = DateTime.Now;
        
            return true; 
        }
    }
}
