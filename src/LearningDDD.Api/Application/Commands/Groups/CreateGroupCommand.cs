using LearningDDD.Domain.Models;
using LearningDDD.Domain.SeedWork;
using MediatR;

namespace LearningDDD.Api.Application.Commands.Groups
{
    public record CreateGroupCommand(string Name, int Capacity) : IRequest<Result<Group>>;
}
