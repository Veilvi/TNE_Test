namespace Models;
/*Трансформатор напряжения*/
public class VoltageTransformer:EntityBase
{
    public string Number { get; set; }
    public float TransformationRatio { get; set; } // КТН (коэффициент трансформации)
    public DateTime VerificationDate { get; set; } // Дата поверки
    public string TransformerType { get; set; }    // Тип трансформатора тока
    // Links
    public long ElectricityMeasurementPointId { get; set; }
    public ElectricityMeasurementPoint ElectricityMeasurementPoint { get; set; }
}