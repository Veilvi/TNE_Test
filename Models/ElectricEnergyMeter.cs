namespace Models;
/*Счетчик электрической энергии*/
public class ElectricEnergyMeter : EntityBase
{
    public string Number { get; set; }              // Номер
    public string CounterType { get; set; }         // Тип счетчика
    public DateTime VerificationDate { get; set; }  //Дата поверки
    // Links
    public long ElectricityMeasurementPointId { get; set; }
    public ElectricityMeasurementPoint ElectricityMeasurementPoint { get; set; }
}