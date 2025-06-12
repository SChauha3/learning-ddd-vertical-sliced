using LearningDDD.Domain.Interfaces;
using LearningDDD.Domain.Models;
using LearningDDD.Domain.SeedWork;
using MediatR;

namespace LearningDDD.Api.Application.Commands.Groups
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Result<Group>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Group>> Handle(CreateGroupCommand command, CancellationToken cancellationToken)
        {
            var result = Group.Create(command.Name, command.Capacity);

            if (result.IsSuccess && result.Value is not null)
            {
                await _unitOfWork.Groups.AddAsync(result.Value);
                await _unitOfWork.SaveChangesAsync();
            }

            return result;
        }
    }
}
