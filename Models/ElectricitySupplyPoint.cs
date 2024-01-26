namespace Models;
/*Точка поставки электроэнергии*/
public class ElectricitySupplyPoint:EntityBase
{
    public string NameOfDeliveryPoint { get; set; } //Наименование точки поставки
    public int MaximumPower { get; set; } // Максимальная мощность, кВт
    // Links
    public ObjectOfConsumption ObjectOfConsumption { get; set; }
    public CalculationMeter CalculationMeter { get; set; }
}