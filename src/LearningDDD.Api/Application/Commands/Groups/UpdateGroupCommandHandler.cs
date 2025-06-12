using LearningDDD.Api.Dtos.Group;
using LearningDDD.Domain.Interfaces;
using LearningDDD.Domain.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LearningDDD.Api.Application.Commands.Groups
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Result<bool>> Handle(UpdateGroupCommand command, CancellationToken cancellationToken)
        {
            var group = await _unitOfWork.Groups.FindAsync(
                g => g.Id == command.Id,
                query => query
                .Include(g => g.ChargeStations)
                .ThenInclude(cs => cs.Connectors));

            if (group is null)
                return Result<bool>.Fail("Group not found", ErrorType.GroupNotFound);

            var result = group.Update(command.Name, command.Capacity);
            if (result.IsSuccess)
                await _unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
