using TNE_Test.DTO.CalculationMeters;
using TNE_Test.DTO.CurrentTransformers;
using TNE_Test.DTO.ElectricEnergyMeters;
using TNE_Test.DTO.MeasurementPoints;
using TNE_Test.DTO.VoltageTransformers;

namespace TNE_Test.Services;

public interface ITneServices
{
    public Task<bool> GenerateData();
    public Task<bool> CreateNewMeasurementPoint(long objOfConsumptionId, MeasurementPointCreateDto dto);
    public Task<List<CalculationMeterReadDto>> GetAllCalculationMeters(int year);
    public Task<List<ElectricEnergyMeterRadDto>> GetExpiredEnergyMetersByObjectId(long objId);
    public Task<List<CurrentTransformerReadDto>> GetExpiredCurrentTransformersByObjectId(long objId);
    public Task<List<VoltageTransformerReadDto>> GetExpiredVoltageTransformersByObjectId(long objId);
}