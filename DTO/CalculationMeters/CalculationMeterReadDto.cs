using Models;
using TNE_Test.DTO.ElectricitySupplyPoints;
using TNE_Test.DTO.MeasurementPoints;

namespace TNE_Test.DTO.CalculationMeters;

public class CalculationMeterReadDto:CalculationMeterBaseDto
{
    public long Id { get; set; }
    public List<MeasurementPointReadDto> MeasurementPoints { get; set; }
    public List<ElectricitySupplyPointReadDto> ElectricitySupplyPoints { get; set; }

    public static explicit operator CalculationMeterReadDto(CalculationMeter cm) => new CalculationMeterReadDto
    { 
    Id = cm.Id,
    SDate = cm.SDate.ToString("o"),
    EDate = cm.EDate.ToString("o"),
    ElectricitySupplyPoints = ElectricitySupplyPointReadDto.ToList(cm.ElectricitySupplyPoints),
    MeasurementPoints = MeasurementPointReadDto.ToList(cm.MeasurementPoints)
    };
    
    public static List<CalculationMeterReadDto> ToList(List<CalculationMeter> cm)
    {
        var Dtos= new List<CalculationMeterReadDto>();
        foreach (var m in cm)
        {
            Dtos.Add((CalculationMeterReadDto)m);
        }
        return Dtos;
    }
}