using Models;
using TNE_Test.DTO.CurrentTransformers;
using TNE_Test.DTO.ElectricEnergyMeters;
using TNE_Test.DTO.VoltageTransformers;

namespace TNE_Test.DTO.MeasurementPoints;

public class MeasurementPointReadDto:MeasurementPointBaseDto
{
    public long Id { get; set; }
    public ElectricEnergyMeterRadDto ElectricEnergyMeter { get; set; }
    public CurrentTransformerReadDto CurrentTransformer { get; set; }
    public VoltageTransformerReadDto VoltageTransformer { get; set; }

    public static explicit operator MeasurementPointReadDto(ElectricityMeasurementPoint mp) =>
        new MeasurementPointReadDto
        {
            Id = mp.Id,
            Name = mp.Name,
            ElectricEnergyMeter = (ElectricEnergyMeterRadDto)mp.ElectricEnergyMeter,
            CurrentTransformer = (CurrentTransformerReadDto)mp.CurrentTransformer,
            VoltageTransformer = (VoltageTransformerReadDto)mp.VoltageTransformer
        };
    
    
    public static List<MeasurementPointReadDto> ToList(List<ElectricityMeasurementPoint> mp)
    {
        var Dtos= new List<MeasurementPointReadDto>();
        foreach (var p in mp)
        {
            Dtos.Add((MeasurementPointReadDto)p);
        }
        return Dtos;
    }
}