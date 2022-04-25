using GrupoA.Academic.Application.Abstractions.Models;
using MediatR;

namespace GrupoA.Academic.Application.Abstractions.Interfaces;

public interface ICommand<TResponse> : IRequest<CommandResult<TResponse>>
{
}