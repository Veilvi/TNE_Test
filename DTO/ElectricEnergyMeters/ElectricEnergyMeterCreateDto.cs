using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Models;

namespace TNE_Test.DTO.ElectricEnergyMeters;

public class ElectricEnergyMeterCreateDto:ElectricEnergyMeterBaseDto
{
    [Required]
    public new string Number { get; set; }              // Номер
    [Required]
    public new string CounterType { get; set; }         // Тип счетчика
    [Required]
    public new string VerificationDate { get; set; }  //Дата поверки
    public static explicit operator ElectricEnergyMeter(ElectricEnergyMeterCreateDto dto) => new ElectricEnergyMeter
    {
         Number = dto.Number, 
         CounterType = dto.CounterType,         
         VerificationDate = DateTime.ParseExact(dto.VerificationDate, new [] { "o" },
             CultureInfo.InvariantCulture,
             DateTimeStyles.None )
    };
}