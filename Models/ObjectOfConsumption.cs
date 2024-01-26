namespace Models;
/*Объект потребления*/
public class ObjectOfConsumption:EntityBase
{
    public string ObjectName { get; set; } // Наименование объекта
    public string Address { get; set; }    // Адрес
    // Links
    public ChildOrganization ChildOrganization{ get; set; } // Объекты потребления
    public List<ElectricityMeasurementPoint> ElectricityMeasurementPoints { get; set; }
    public List<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; }
}