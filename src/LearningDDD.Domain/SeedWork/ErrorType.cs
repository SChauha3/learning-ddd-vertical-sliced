namespace LearningDDD.Domain.SeedWork
{
    public enum ErrorType
    {
        GroupNotFound,
        GroupNameRequired,

        ChargeStationNotFound,
        ChargeStationNameRequired,
        ChargeStationNameMustBeUnique,
        ChargeStationWithoutConnector,

        ConnectorNotFound,
        ConnectorNameRequired,
        ConnectorCountExceeded,
        DuplicateConnectorContextId,
        CapacityNotGreaterThanZero,
        UniqueConnector,
        CapacityNotGreaterThanUsedCurrent,

        InvalidId,
        Unknown
    }
}
