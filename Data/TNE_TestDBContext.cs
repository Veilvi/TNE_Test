using Microsoft.EntityFrameworkCore;
using Models;


namespace TNE_Test.Data;

public class TNE_TestDBContext:DbContext
{
    public DbSet<Organization>                Organizations                { get; set; }
    public DbSet<ChildOrganization>           ChildOrganizations           { get; set; }
    public DbSet<CurrentTransformer>          CurrentTransformers          { get; set; }
    public DbSet<ElectricEnergyMeter>         ElectricEnergyMeters         { get; set; }
    public DbSet<ElectricityMeasurementPoint> ElectricityMeasurementPoints { get; set; }
    public DbSet<ElectricitySupplyPoint>      ElectricitySupplyPoints      { get; set; }
    public DbSet<ObjectOfConsumption>         ObjectsOfConsumptions        { get; set; }
    public DbSet<VoltageTransformer>          VoltageTransformers          { get; set; }
    
    
    public TNE_TestDBContext(DbContextOptions<TNE_TestDBContext> options) : base(options)
    {
            
    }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalculationMeter>()
            .HasMany(cm => cm.ElectricitySupplyPoints)
            .WithMany(sp => sp.CalculationMeters);
        modelBuilder.Entity<CalculationMeter>()
            .HasMany(mp => mp.MeasurementPoints)
            .WithMany(cm => cm.CalculationMeters);

    }*/
}




