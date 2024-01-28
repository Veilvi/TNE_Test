using Microsoft.EntityFrameworkCore;
using Models;
using TNE_Test.Data;
using TNE_Test.DTO.CalculationMeters;
using TNE_Test.DTO.CurrentTransformers;
using TNE_Test.DTO.ElectricEnergyMeters;
using TNE_Test.DTO.MeasurementPoints;
using TNE_Test.DTO.VoltageTransformers;
using TNE_Test.Exceptions;

namespace TNE_Test.Services;

public class TneServices : ITneServices
{
    private readonly DbContext _context;
    
    public TneServices(DbContext context, IConfiguration configuration)
    {
        _context = context;
    }
    

    public async Task<bool> GenerateData()
    {
        var datafiller = new DataFiller(_context);
        if (!datafiller.IsDbHasData())
        {
          return datafiller.FillDbByData();
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> CreateNewMeasurementPoint(long objOfConsumptionId,MeasurementPointCreateDto dto)
    {
        var eMeter = (ElectricEnergyMeter)dto.ElectricEnergyMeter;
        var vTransformer = (VoltageTransformer)dto.VoltageTransformer;
        var cTransformer = (CurrentTransformer)dto.CurrentTransformer;
        var mp = (ElectricityMeasurementPoint)dto;
        mp.CurrentTransformer = cTransformer;
        mp.ElectricEnergyMeter = eMeter;
        mp.VoltageTransformer = vTransformer;
        mp.CalculationMeter = new CalculationMeter();
        var objOfConsumption =
            await _context.Set<ObjectOfConsumption>()
                .Include(o=>o.ElectricityMeasurementPoints)
                .FirstOrDefaultAsync(o => o.Id == objOfConsumptionId);
        if (objOfConsumption==null)
        {
            throw new ItemNotFoundException();
        }
        objOfConsumption.ElectricityMeasurementPoints.Add(mp);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<CalculationMeterReadDto>> GetAllCalculationMeters(int year)
    {
        var calculationMeters = await _context.Set<CalculationMeter>()
            .Include(cm=>cm.MeasurementPoints).ThenInclude(mp=>mp.VoltageTransformer)
            .Include(cm=>cm.MeasurementPoints).ThenInclude(mp=>mp.CurrentTransformer)
            .Include(cm=>cm.MeasurementPoints).ThenInclude(mp=>mp.ElectricEnergyMeter)
            .Include(cm=>cm.ElectricitySupplyPoints)
            .Where(cm => cm.SDate.Year <= year && cm.EDate.Year >= year).ToListAsync();
        return CalculationMeterReadDto.ToList(calculationMeters);
    }

    public async Task<List<ElectricEnergyMeterRadDto>> GetExpiredEnergyMetersByObjectId(long objId)
    {
        var obj = await _context.Set<ObjectOfConsumption>()
            .FirstOrDefaultAsync(o => o.Id == objId);
        if (obj==null)
        {
            throw new ItemNotFoundException();
        }
        var meters = await _context.Set<ElectricEnergyMeter>()
            .Include(m=>m.ElectricityMeasurementPoint)
            .ThenInclude(mp=>mp.ObjectsOfConsumption)
            .Where(m => m.ElectricityMeasurementPoint.ObjectsOfConsumption==obj && m.VerificationDate < DateTime.Now).ToListAsync();
        return ElectricEnergyMeterRadDto.ToList(meters);
    }

    public async Task<List<CurrentTransformerReadDto>> GetExpiredCurrentTransformersByObjectId(long objId)
    {
        var obj = await _context.Set<ObjectOfConsumption>()
            .FirstOrDefaultAsync(o => o.Id == objId);
        if (obj==null)
        {
            throw new ItemNotFoundException();
        }
        var transformers = await _context.Set<CurrentTransformer>()
            .Include(t=>t.ElectricityMeasurementPoint)
            .ThenInclude(mp=>mp.ObjectsOfConsumption)
            .Where(m => m.ElectricityMeasurementPoint.ObjectsOfConsumption==obj && m.VerificationDate < DateTime.Now).ToListAsync();
        return CurrentTransformerReadDto.ToList(transformers);
    }

    public async Task<List<VoltageTransformerReadDto>> GetExpiredVoltageTransformersByObjectId(long objId)
    {
        var obj = await _context.Set<ObjectOfConsumption>()
            .Include(o=>o.ElectricityMeasurementPoints)
            .ThenInclude(mp=>mp.VoltageTransformer)
            .FirstOrDefaultAsync(o => o.Id == objId);
        if (obj==null)
        {
            throw new ItemNotFoundException();
        }
        var transformers = await _context.Set<VoltageTransformer>()
            .Include(t=>t.ElectricityMeasurementPoint)
            .ThenInclude(mp=>mp.ObjectsOfConsumption)
            .Where(m => m.ElectricityMeasurementPoint.ObjectsOfConsumption==obj && m.VerificationDate < DateTime.Now).ToListAsync();
        return VoltageTransformerReadDto.ToList(transformers);
    }
}