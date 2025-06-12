using LearningDDD.Domain.SeedWork;
using MediatR;

namespace LearningDDD.Api.Application.Commands.Groups
{
    public record UpdateGroupCommand(Guid Id, string Name, int Capacity) : IRequest<Result<bool>>;
}
