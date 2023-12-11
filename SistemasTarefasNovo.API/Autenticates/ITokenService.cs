
using SistemaTarefaNovo.Aplication.DTOs;
using SistemaTarefaNovo.Domain.Entities;

namespace SistemasTarefasNovo.API.Autenticates
{
    public interface ITokenService
    {
        public string GerarToken(string username, string senha);

    }
}
