namespace TNE_Test.DTO.ElectricEnergyMeters;

public class ElectricEnergyMeterBaseDto
{
    public string Number { get; set; }              // Номер
    public string CounterType { get; set; }         // Тип счетчика
    public string VerificationDate { get; set; }  //Дата поверки
}