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
    public class TarefaController : ControllerBase
    {

        private readonly ITarefaService _service;

        public TarefaController(ITarefaService service)
        {
            _service = service;
        }

        [HttpPost("/cadastrar/tarefa")]
        public async Task<ActionResult> CadastrarTarefa(TarefaDTO tarefaDTO)
        {
            await _service.CadastrarTarefa(tarefaDTO);

            if(tarefaDTO == null)
            {

                return BadRequest("Houve um problema ao efetuar um novo cadastro");

            } else
            {

                return Ok();

            }
          
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaDTO>>> VerTodasTarefas()
        {
            var tarefas = await _service.GetAll();

            return Ok(tarefas);


        }

        [HttpGet("/pesquisar/tarefa/{id}")]
        public async Task<ActionResult<TarefaDTO>> PesquisarTarefa(int id)
        {

            var tarefa = await _service.GetById(id);

            if(tarefa == null)
            {
                return NotFound("TAREFA NÃO ENCONTRADA");
            } else
            {
                return Ok(tarefa);
            }
        }
        [HttpPut("/editar/tarefa/{id}")]
        public async Task<ActionResult> EditarTarefas(int id, TarefaDTO tarefaDTO)
        {
            try
            {
                if (id != tarefaDTO.id_tarefa)
                {
                    return NotFound();
                }
                else
                {
                    await _service.Update(tarefaDTO);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao editar a tarefa: {ex.Message}");
            }
        }
    }
}
