namespace MinimalToStartup.Dtos;

public class TarefaDto
{
    /// <summary>
    /// Descrição da tarefa
    /// </summary>
    public string Descricao { get; set; }

    /// <summary>
    /// Data que a tarefa será executada
    /// </summary>
    public DateTime DataExecucao { get; set; }

    /// <summary>
    /// Tipo da tarefa
    /// </summary>
    public TipoTarefaDto TipoTarefa { get; set; }
}

public class TarefaPost : TarefaDto { }

public class TarefaPostResult : TarefaDto
{
    /// <summary>
    /// Identificador da tarefa
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Indicador se tarefa ativa ou inativa
    /// </summary>
    public bool Ativa { get; set; }
}

public class TarefaGetResult : TarefaDto
{
    /// <summary>
    /// Identificador da tarefa
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Indicador se tarefa ativa ou inativa
    /// </summary>
    public bool Ativa { get; set; }
}