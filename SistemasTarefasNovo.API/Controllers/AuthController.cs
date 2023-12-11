using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemasTarefasNovo.API.Autenticates;
using SistemaTarefaNovo.Aplication.DTOs;
using SistemaTarefaNovo.Domain.Entities;
using SistemaTarefaNovo.Infra.Data.Data;
using System.Runtime.CompilerServices;

namespace SistemasTarefasNovo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly BancoContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

      

        public AuthController(BancoContext context, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> AutenticarPessoa(string senha, string username)
        {
            var pessoaModel = await _context.pessoa.
                Where(comparar => comparar.username.ToLower() == username && comparar.password.ToLower() == senha)
                .FirstOrDefaultAsync();

            var pessoaDTO = _mapper.Map<PessoaDTO>(pessoaModel);

            if(pessoaDTO != null)
            {
                var token = _tokenService.GerarToken(pessoaDTO.username, pessoaDTO.password);

                return Ok(new { Token = token, pessoaDTO = pessoaDTO });
            } else
            {

                return BadRequest("Usuário ou senha inválidos");

            }




        }

    }
}
