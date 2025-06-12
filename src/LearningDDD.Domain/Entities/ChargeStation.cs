using LearningDDD.Domain.SeedWork;

namespace LearningDDD.Domain.Models
{
    public class ChargeStation : Entity<Guid>
    {
        private readonly List<Connector> _connectors = new();

        public string Name { get; private set; }

        public IReadOnlyCollection<Connector> Connectors => _connectors.AsReadOnly();
        private ChargeStation() { }

        private ChargeStation(Guid id, string name, IEnumerable<Connector> connectors) : base(id)
        {
            Name = name;
            _connectors.AddRange(connectors);
        }

        internal static Result<ChargeStation> Create(string name, IEnumerable<(int chargeStationContextId, int maxCurrent)> connectorInvariants)
        {
            var connectors = Connector.Create(connectorInvariants);
            if (!connectors.IsSuccess || connectors.Value is null)
                return Result<ChargeStation>.Fail(connectors.Error, (ErrorType)connectors.ErrorType);

            return Result<ChargeStation>.Success(new ChargeStation(Guid.Empty, name, connectors.Value));
        }
            

        internal void UpdateName(string name)
        {
            Name = name;
        }

        internal int GetCurrentLoad() =>
            Connectors.Sum(c => c.MaxCurrent);

        internal void AddConnector(Connector connector) =>
            _connectors.Add(connector);

        internal Result<Connector> RemoveConnector(Guid connectorId)
        {
            var connector = Connectors.FirstOrDefault(c => c.Id == connectorId);
            if (connector is null)
                return Result<Connector>.Fail("Connector cannot be null.", ErrorType.ConnectorNotFound);

            _connectors.Remove(connector);
            return Result<Connector>.Success(connector);
        }
    }
}