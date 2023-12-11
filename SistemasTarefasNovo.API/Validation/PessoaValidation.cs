using FluentValidation;
using SistemaTarefaNovo.Aplication.DTOs;



namespace SistemaTarefaNovo.Domain.Validation
{
    public class PessoaValidation : AbstractValidator<PessoaDTO>
    {
        public PessoaValidation()
        {
            RuleFor(pessoa => pessoa.username).NotEmpty().WithMessage("O username é obrigatório.");
            RuleFor(pessoa => pessoa.password).NotEmpty().WithMessage("O password é obrigatório.");
            RuleFor(pessoa => pessoa.email).NotEmpty().WithMessage("O email é obrigatório.");
            RuleFor(pessoa => pessoa.nome).NotEmpty().WithMessage("O nome é obrigatório.");
        }

    }
}
