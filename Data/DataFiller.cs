using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace TNE_Test.Data;

public class DataFiller
{
    private readonly DbContext _context;

    public DataFiller(DbContext context)
    {
        _context = context;
    }

    public async Task<bool> IsDbHasData()
    {
        return await _context.Set<CalculationMeter>().FirstOrDefaultAsync() == null
               && await _context.Set<ChildOrganization>().FirstOrDefaultAsync() == null
               && await _context.Set<CurrentTransformer>().FirstOrDefaultAsync() == null
               && await _context.Set<ElectricEnergyMeter>().FirstOrDefaultAsync() == null
               && await _context.Set<ElectricityMeasurementPoint>().FirstOrDefaultAsync() == null
               && await _context.Set<ObjectOfConsumption>().FirstOrDefaultAsync() == null
               && await _context.Set<Organization>().FirstOrDefaultAsync() == null
               && await _context.Set<VoltageTransformer>().FirstOrDefaultAsync() == null;
        /*var cMeters = ;
        var childOrganisations = ;
        var cTransformers = ;
        var eMeters = ;
        var mPoints = ;
        var sPoints = ;
        var consumers = ;
        var organizations = ;
        var vTransformers = ;
        return cMeters == null
               && childOrganisations == null
               && cTransformers == null
               && eMeters == null
               && mPoints == null
               && sPoints == null
               && consumers == null
               && organizations == null
               && vTransformers == null;*/
    }
}