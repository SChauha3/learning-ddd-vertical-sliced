using LearningDDD.Api.Dtos.Group;
using LearningDDD.Domain.SeedWork;

namespace LearningDDD.Api.Application.Queries
{
    public interface IChargingQueries
    {
        Task<Result<IEnumerable<CreatedGroup>>> GetGroupsAsync();
        Task<Result<CreatedGroup>> GetGroupByIdAsync(Guid groupId);
    }
}
