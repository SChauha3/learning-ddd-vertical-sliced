using LearningDDD.Api.Dtos.Group;
using LearningDDD.Domain.SeedWork;

namespace LearningDDD.Api.Application.Queries
{
    public class ChargingQueries : IChargingQueries
    {
        public Task<Result<CreatedGroup>> GetGroupByIdAsync(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<CreatedGroup>>> GetGroupsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
