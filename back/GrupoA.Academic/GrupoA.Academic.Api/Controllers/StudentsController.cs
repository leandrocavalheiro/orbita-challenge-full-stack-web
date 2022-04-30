using GrupoA.Academic.Api.Controllers.Abstractions;
using GrupoA.Academic.Application.Students.Commands;
using GrupoA.Academic.Application.Students.Queries;
using GrupoA.Academic.Application.Students.ViewModels;
using GrupoA.Academic.Commom.Interfaces;
using GrupoA.Academic.Commom.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GrupoA.Academic.Api.Controllers;

[Route("api/v{version:apiVersion}/students")]
[Produces("application/json")]
public class StudentsController : ApiController
{
    public StudentsController(IMediator mediator, INotificationContext notificationContext) : base(mediator, notificationContext)
    {
    }

    /// <summary>
    /// Método responsável por retornar um Aluno, filtrando pelo seu ID
    /// </summary>
    /// <returns>StudentViewModel</returns>
    /// <response code="200">Retorna um aluno</response>
    /// <response code="400">Erro ao tentar obter um aluno</response>
    /// <response code="404">Aluno não encontrado</response> 
    /// <response code="500">Informa que um erro interno ocorreu</response> 
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StudentViewModel>> GetById(Guid id)
        => AcademicResponse(await mediator.Send(new GetStudentByIdQuery(id)));

    /// <summary>
    /// Método responsável por cadastrar um aluno
    /// </summary>
    /// <param name="command">Payload com dados do aluno a ser cadastrado</param>
    /// <returns>StudentViewModel</returns>
    /// <response code="201">Aluno cadastrado com sucesso</response>
    /// <response code="400">Erro ao tentar cadastrar um aluno</response>
    /// <response code="500">Informa que um erro interno ocorreu</response>         
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<StudentViewModel>> Create([FromBody] CreateStudentCommand command)
        => AcademicResponse(await mediator.Send(command), false, nameof(GetById), command.Id);

    /// <summary>
    /// Método responsável por atualizar um aluno
    /// </summary>
    /// <param name="id">Id do aluno</param>
    /// <param name="command">payload com novos dados do aluno</param>
    /// <returns>StudentViewModel</returns>
    /// <response code="200">Aluno atualizado com sucesso</response>
    /// <response code="400">Erro ao tentar atualizar o aluno</response>
    /// <response code="404">Aluno não encontrado</response>
    /// <response code="500">Informa que um erro interno ocorreu</response>        
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<StudentViewModel>> Update(Guid id, [FromBody] UpdateStudentCommand command)
        => AcademicResponse(await mediator.Send(command.SetId(id)), true, nameof(GetById), command.Id);

    /// <summary>
    /// Método responsável por retornar uma lista de alunos
    /// </summary>
    /// <param name="filter">Valor usado como filtro</param>
    /// <param name="page">Número da pagina desejada</param>
    /// <param name="pageSize">Quantidade de registros por página</param>
    /// <param name="sortBy">Por qual campo será a ordenação. Default: Code</param>
    /// <param name="sortDesc">Ordenação descendente</param>
    /// <returns>PaginationViewModel<StudentListViewModel></returns>
    /// <response code="200">Lista de alunos</response>
    /// <response code="400">Erro ao tentar obter uma lista de alunos</response>
    /// <response code="500">Informa que um erro interno ocorreu</response> 
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult<PaginationViewModel<StudentListViewModel>>> Get([FromQuery(Name = "filter")] string filter = "", [FromQuery(Name = "page")] int page = Page, [FromQuery(Name = "pageSize")] int pageSize = PageSize,
                                                                                   [FromQuery(Name = "sortBy")] string sortBy = "Code", [FromQuery(Name = "sortDesc")] bool sortDesc = true)
        => AcademicResponse(await mediator.Send(new GetStudentsQuery(filter, page, pageSize, sortBy, sortDesc)));

    /// <summary>
    /// Método responsável por deletar um aluno
    /// </summary>
    /// <param name="id"></param>
    /// <returns>NoContent</returns>
    /// <response code="204">Aluno deletado com sucesso</response>        
    /// <response code="400">Erro ao tentar deletar aluno</response>
    /// <response code="404">Aluno não encontrado</response>
    /// <response code="500">Informa que um erro interno ocorreu</response> 
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await mediator.Send(new DeleteStudentCommand(id));
        return AcademicResponse();
    }
}