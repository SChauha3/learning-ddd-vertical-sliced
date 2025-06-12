using LearningDDD.Domain.Interfaces;
using LearningDDD.Domain.SeedWork;
using MediatR;

namespace LearningDDD.Api.Application.Commands.Groups
{
    public class DeleteGroupCommandHandler:IRequestHandler<DeleteGroupCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteGroupCommand command, CancellationToken cancellationToken)
        {
            var group = await _unitOfWork.Groups.FindByIdAsync(command.Id);
            if (group is null)
                return Result<bool>.Fail("Group not found", ErrorType.GroupNotFound);

            _unitOfWork.Groups.Delete(group);
            await _unitOfWork.SaveChangesAsync();

            return Result<bool>.Success(true);
        }
    }
}