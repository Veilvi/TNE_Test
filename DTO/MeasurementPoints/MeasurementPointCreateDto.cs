using System.ComponentModel.DataAnnotations;
using Models;
using TNE_Test.DTO.CurrentTransformers;
using TNE_Test.DTO.ElectricEnergyMeters;
using TNE_Test.DTO.VoltageTransformers;

namespace TNE_Test.DTO.MeasurementPoints;

public class MeasurementPointCreateDto:MeasurementPointBaseDto
{
    [Required]
    public new string Name { get; set; }
    public ElectricEnergyMeterCreateDto ElectricEnergyMeter { get; set; }
    public CurrentTransformerCreateDto CurrentTransformer { get; set; }
    public VoltageTransformerCreateDto VoltageTransformer { get; set; }

    public static explicit operator ElectricityMeasurementPoint(MeasurementPointCreateDto dto) =>
        new ElectricityMeasurementPoint
        {
            Name = dto.Name
        };
}