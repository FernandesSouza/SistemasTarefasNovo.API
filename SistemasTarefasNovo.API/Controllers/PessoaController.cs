using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefaNovo.Aplication.DTOs;
using SistemaTarefaNovo.Aplication.Interfaces;

namespace SistemasTarefasNovo.API.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpPost("/cadastrar/pessoa")]
        public async Task<ActionResult> AdicionarPessoa(PessoaDTO pessoaDTO)
        {

             await _service.CadastrarPessoa(pessoaDTO);
            if(pessoaDTO == null)
            {

                return BadRequest("OCORREU UM ERRO AO EFETUAR O CADASTRO");


            }
            return Ok(pessoaDTO);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaDTO>>> RetornarTodasPessoas()
        {
            var pessoas = await _service.GetAll();

            return Ok(pessoas);
        }

        [HttpGet("/pesquisar/pessoa/{id}")]
        public async Task<ActionResult<PessoaDTO>> RetornarPessoaPorID(int id)
        {
            var pessoaDTO = await _service.GetById(id);
            if (pessoaDTO == null)
            {

                return NotFound("FUNCIONARIO NÃO ENCONTRADO");


            }
            return Ok(pessoaDTO);
        }

        [HttpPut("/editar/pessoa/{id}")]
        public async Task<ActionResult> EditarPessoa(int id, PessoaDTO pessoaDTO)
        {
            try
            {
                if (id != pessoaDTO.idusuario)
                {
                    return NotFound();
                }
                else
                {
                    await _service.Update(pessoaDTO);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao editar a tarefa: {ex.Message}");
            }
        }

        [HttpDelete("/deletar/pessoa/{id}")]
        public async Task<IActionResult> DeletarPorId(int id)
        {
            var sucesso = await _service.DeletarPessoa(id);

            if (!sucesso)
            {
                return NotFound("TAREFA NÃO ENCONTRADA");
            }

            return Ok("TAREFA REMOVIDA COM SUCESSO");
        }
    }
}
