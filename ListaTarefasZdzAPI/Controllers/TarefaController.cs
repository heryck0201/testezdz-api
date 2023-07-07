using ListaTarefasZdzAPI.Context;
using ListaTarefasZdzAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefasZdzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly AplicativoDbContext _context;
        public TarefaController(AplicativoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaTarefas = await _context.Tarefas.ToArrayAsync();
                return Ok(listaTarefas);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarefa tarefa)
        {
            try
            {
                _context.Tarefas.Add(tarefa);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Tarefa registrada" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Pust([FromBody] Tarefa tarefa, int id)
        {
            try
            {
                if (id != tarefa.Id)
                {
                    return NotFound();
                }
                tarefa.State = !tarefa.State;
                _context.Entry(tarefa).State = EntityState.Modified;
                return Ok(new { message = "Tarefa atualizada com exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarefa = await _context.Tarefas.FindAsync(id);
                if (tarefa == null)
                {
                    return NotFound();
                }

                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Tarefa atualizada com exito" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
