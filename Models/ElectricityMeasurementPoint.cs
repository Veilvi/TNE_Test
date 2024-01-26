namespace Models;
/*Точка измерения электроэнергии*/
public class ElectricityMeasurementPoint:EntityBase
{
    public string Name { get; set; } // Наименование
    //Links
    public ElectricEnergyMeter ElectricEnergyMeter { get; set; }
    public CurrentTransformer CurrentTransformer { get; set; }
    public VoltageTransformer VoltageTransformer { get; set; }
    public ObjectOfConsumption ObjectsOfConsumption { get; set; }
    public CalculationMeter CalculationMeter { get; set; }
}