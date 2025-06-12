using LearningDDD.Domain.SeedWork;
using MediatR;

namespace LearningDDD.Api.Application.Commands.Groups
{
    public record DeleteGroupCommand(Guid Id) : IRequest<Result<bool>>;
}
