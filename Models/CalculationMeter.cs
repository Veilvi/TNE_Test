namespace Models;
/*Расчетный прибор учета*/
public class CalculationMeter:EntityBase
{
    public DateTime SDate { get; set; }
    public DateTime EDate { get; set; }
    // Links
    public List<ElectricityMeasurementPoint> MeasurementPoints { get; set; }
    public List<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; }

    
}