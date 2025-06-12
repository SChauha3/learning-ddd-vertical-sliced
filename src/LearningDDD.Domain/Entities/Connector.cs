using LearningDDD.Domain.SeedWork;

namespace LearningDDD.Domain.Models
{
    public class Connector : Entity<Guid>
    {
        public int ChargeStationContextId { get; private set; }
        public int MaxCurrent { get; private set; }

        private Connector(Guid id, int chargeStationContextId, int maxCurrent) : base(id)
        {
            ChargeStationContextId = chargeStationContextId;
            MaxCurrent = maxCurrent;
        }

        internal static Connector Create(int chargeStationContextId, int maxCurrent) =>
            new Connector(Guid.Empty, chargeStationContextId, maxCurrent);

        internal static Result<IEnumerable<Connector>> Create(IEnumerable<(int chargeStationContextId, int maxCurrent)> connectorInvariants)
        {
            if (!connectorInvariants.Any())
                return Result<IEnumerable<Connector>>.Fail(
                    "Connectors must be added to add a new chargestation", 
                    ErrorType.ChargeStationWithoutConnector);

            if (connectorInvariants.Count() < 1 || connectorInvariants.Count() > 5)
                return Result<IEnumerable<Connector>>.Fail(
                    "A charge station must have between 1 and 5 connectors.",
                    ErrorType.ConnectorCountExceeded);

            var duplicateContextIds = connectorInvariants
                .GroupBy(c => c.chargeStationContextId)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicateContextIds.Any())
                return Result<IEnumerable<Connector>>.Fail(
                    $"Duplicate connector context ID(s): {string.Join(", ", duplicateContextIds)}",
                    ErrorType.DuplicateConnectorContextId);

            return Result<IEnumerable<Connector>>.Success(
                connectorInvariants.Select(c => new Connector(Guid.Empty, c.chargeStationContextId, c.maxCurrent)));
        }
            

        internal void Update(int newMaxCurrent) =>
            MaxCurrent = newMaxCurrent;
    }
}