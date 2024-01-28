using Models;

namespace TNE_Test.DTO.ObjectsOfConsumption;

public class ObjectOfConsumptionReadDto:ObjectOfConsumptionBaseDto
{
    public long Id { get; set; }

    public static explicit operator ObjectOfConsumptionReadDto(ObjectOfConsumption co) => new ObjectOfConsumptionReadDto
    {
        Id = co.Id,
        ObjectName = co.ObjectName,
        Address = co.Address
    };
}