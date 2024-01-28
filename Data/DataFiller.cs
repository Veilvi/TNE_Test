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

    public bool IsDbHasData()
    {
        var cMeters =  _context.Set<CalculationMeter>().FirstOrDefault();
        var childOrganisations =  _context.Set<ChildOrganization>().FirstOrDefault();
        var cTransformers =  _context.Set<CurrentTransformer>().FirstOrDefault();
        var eMeters = _context.Set<ElectricEnergyMeter>().FirstOrDefault();
        var mPoints =  _context.Set<ElectricityMeasurementPoint>().FirstOrDefault();
        var sPoints =  _context.Set<ElectricitySupplyPoint>().FirstOrDefault();
        var consumers = _context.Set<ObjectOfConsumption>().FirstOrDefault();
        var organizations =  _context.Set<Organization>().FirstOrDefault();
        var vTransformers =  _context.Set<VoltageTransformer>().FirstOrDefault();
        return cMeters != null
               && childOrganisations != null
               && cTransformers != null
               && eMeters != null
               && mPoints != null
               && sPoints != null
               && consumers != null
               && organizations != null
               && vTransformers != null;
    }

    public bool FillDbByData()
    {
        var Organization1 =
            new Organization
            {
                Name = "ПАО «ОАК»",
                Address = "Россия, 115054, Москва, улица Б. Пионерская, д. 1",
                ChildOrganizations =
                [
                    new ChildOrganization
                    {
                        Name = "АО «ЛИИ им. М.М. Громова»",
                        Address = "140180, Московская область, г. Жуковский, ул. Гарнаева, д. 2А ",
                        ObjectsOfConsumption =
                        [
                            new ObjectOfConsumption
                            {
                                ObjectName = "Здание ЛИИ",
                                Address = "140180, Московская область, г. Жуковский, ул. Гарнаева, д. 2А",
                                ElectricitySupplyPoints =
                                [
                                    new ElectricitySupplyPoint
                                    {
                                        NameOfDeliveryPoint = "Трансформатор 1",
                                        MaximumPower = 500
                                    }
                                ],
                                ElectricityMeasurementPoints =
                                [
                                    new ElectricityMeasurementPoint
                                    {
                                        Name = "SomeName",
                                        CurrentTransformer = new CurrentTransformer
                                        {
                                            TransformerType = "защитный",
                                            Number = "11111111",
                                            TransformationRatio = 0.8f,
                                            VerificationDate =  new DateTime(2017,12,01)
                                        },
                                        VoltageTransformer = new VoltageTransformer
                                        {
                                            TransformerType = "Автотрансформаторы",
                                            Number = "1211111",
                                            TransformationRatio = 0.9f,
                                            VerificationDate = new DateTime(2017,09,15)
                                        },
                                        ElectricEnergyMeter = new ElectricEnergyMeter
                                        {
                                            CounterType = "Электронные",
                                            Number = "13111111",
                                            VerificationDate = new DateTime(2017,06,16)
                                        }
                                    }
                                ]
                            }
                        ]
                    }
                ]
            };
        Organization1.ChildOrganizations[0]
            .ObjectsOfConsumption[0]
            .ElectricitySupplyPoints[0]
            .CalculationMeter = new CalculationMeter
        {
            SDate = new DateTime(2014, 06, 16), 
            EDate = new DateTime(2024,06,16),
            MeasurementPoints = Organization1.ChildOrganizations[0].ObjectsOfConsumption[0].ElectricityMeasurementPoints
        };
         _context.Set<Organization>().Add(Organization1);
         _context.SaveChanges();
        return true;
    }
}