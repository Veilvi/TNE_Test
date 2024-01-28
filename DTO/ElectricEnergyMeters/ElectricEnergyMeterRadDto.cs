using Models;

namespace TNE_Test.DTO.ElectricEnergyMeters;

public class ElectricEnergyMeterRadDto:ElectricEnergyMeterBaseDto
{
    public long Id { get; set; }
    public static explicit operator ElectricEnergyMeterRadDto(ElectricEnergyMeter em) => new ElectricEnergyMeterRadDto
    {
        Id = em.Id,
        Number = em.Number,
        CounterType = em.CounterType,
        VerificationDate = em.VerificationDate.ToString("o")
    };
    public static List<ElectricEnergyMeterRadDto> ToList(List<ElectricEnergyMeter> em)
    {
        var Dtos= new List<ElectricEnergyMeterRadDto>();
        foreach (var m in em)
        {
            Dtos.Add((ElectricEnergyMeterRadDto)m);
        }
        return Dtos;
    }
}