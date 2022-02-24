using Microsoft.AspNetCore.Mvc;
using MinimalToStartup.Dtos;

namespace MinimalToStartup.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    /// <summary>
    /// Obtém todas as tarefas cadastradas
    /// </summary>
    /// <response code="200">Lista obtida com sucesso</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TarefaGetResult>), StatusCodes.Status200OK)]
    public IActionResult ObterTarefas()
    {
        var tarefas = new List<TarefaGetResult>
        {
            new TarefaGetResult
            {
                Id = Guid.NewGuid(),
                Descricao = $"Tarefa nº 1 obtida do método {nameof(ObterTarefas)}",
                DataExecucao = new DateTime(2022, 02, 24),
                TipoTarefa = TipoTarefaDto.Diaria,
                Ativa = true
            },
            new TarefaGetResult
            {
                Id = Guid.NewGuid(),
                Descricao = $"Tarefa nº 2 obtida do método {nameof(ObterTarefas)}",
                DataExecucao = new DateTime(2023, 02, 24),
                TipoTarefa = TipoTarefaDto.Mensal,
                Ativa = true
            }
        };

        return Ok(tarefas);
    }

    /// <summary>
    /// Obtém uma lista de tarefas por tipo
    /// </summary>
    /// <param name="tipoTarefa">Tipo da tarefa</param>
    /// <response code="200">Lista obtida com sucesso</response>
    [HttpGet("Tipos/{tipoTarefa}")]
    [ProducesResponseType(typeof(IEnumerable<TarefaGetResult>), StatusCodes.Status200OK)]
    public IActionResult ObterTarefasPorTipo(TipoTarefaDto tipoTarefa)
    {
        var tarefas = new List<TarefaGetResult>
        {
            new TarefaGetResult
            {
                Id = Guid.NewGuid(),
                Descricao = $"Tarefa nº 1 obtida do método {nameof(ObterTarefasPorTipo)}",
                DataExecucao = new DateTime(2022, 02, 24),
                TipoTarefa = tipoTarefa,
                Ativa = true
            },
            new TarefaGetResult
            {
                Id = Guid.NewGuid(),
                Descricao = $"Tarefa nº 2 obtida do método {nameof(ObterTarefasPorTipo)}",
                DataExecucao = new DateTime(2023, 02, 24),
                TipoTarefa = tipoTarefa,
                Ativa = true
            }
        };

        return Ok(tarefas);
    }

    /// <summary>
    /// Obtém uma tarefa pelo identificador
    /// </summary>
    /// <param name="id">Identificador da tarefa</param>
    /// <response code="200">Tarefa obtida com sucesso</response>
    /// <response code="204">Tarefa não encontrada</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TarefaGetResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult ObterTarefa(Guid id)
    {
        var tarefaGetResult = new TarefaGetResult
        {
            Id = id,
            Descricao = $"Tarefa obtida do método {nameof(ObterTarefa)}",
            DataExecucao = new DateTime(2022, 02, 24),
            TipoTarefa = TipoTarefaDto.Diaria,
            Ativa = true
        };

        return Ok(tarefaGetResult);
    }

    /// <summary>
    /// Cadastra uma nova tarefa
    /// </summary>
    /// <param name="tarefaPost">Dados da nova tarefa</param>
    /// <response code="201">Tarefa criada com sucesso</response>
    [HttpPost]
    [ProducesResponseType(typeof(TarefaPostResult), StatusCodes.Status201Created)]
    public IActionResult CadastrarTarefa(TarefaPost tarefaPost)
    {
        var tarefaPostResult = new TarefaPostResult
        {
            Id = Guid.NewGuid(),
            Descricao = tarefaPost.Descricao,
            DataExecucao = tarefaPost.DataExecucao,
            TipoTarefa = tarefaPost.TipoTarefa,
            Ativa = true
        };

        return CreatedAtAction(nameof(ObterTarefa),
                               new { id = tarefaPostResult.Id },
                               tarefaPostResult);
    }

    /// <summary>
    /// Desativa uma tarefa
    /// </summary>
    /// <param name="id">Identificador da tarefa</param>
    /// <response code="202">Tarefa desativada</response>
    /// <response code="404">Tarefa não encontrada</response>
    [HttpPatch("{id}/Desativa")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DesativarTarefa(Guid id)
    {
        if (id.Equals(Guid.Empty))
        {
            return NotFound();
        }

        return AcceptedAtAction(nameof(ObterTarefa), new { id });
    }

    /// <summary>
    /// Desativa uma tarefa
    /// </summary>
    /// <param name="id">Identificador da tarefa</param>
    /// <response code="202">Tarefa desativada</response>
    /// <response code="404">Tarefa não encontrada</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult ExcluirTarefa(Guid id)
    {
        if (id.Equals(Guid.Empty))
        {
            return NotFound();
        }

        return AcceptedAtAction(nameof(ObterTarefa), new { id }, null);
    }
}