using Models;

namespace TNE_Test.DTO.ElectricitySupplyPoints;

public class ElectricitySupplyPointReadDto:ElectricitySupplyPointBaseDto
{
    public long Id { get; set; }
    public static explicit operator ElectricitySupplyPointReadDto(ElectricitySupplyPoint sp) =>
        new ElectricitySupplyPointReadDto()
        {
            Id = sp.Id,
            NameOfDeliveryPoint = sp.NameOfDeliveryPoint,
            MaximumPower = sp.MaximumPower
        };

    public static List<ElectricitySupplyPointReadDto> ToList(List<ElectricitySupplyPoint> sp)
    {
        var Dtos= new List<ElectricitySupplyPointReadDto>();
        foreach (var p in sp)
        {
            Dtos.Add((ElectricitySupplyPointReadDto)p);
        }
        return Dtos;
    }
}