namespace Models;
/*Трансформатор тока*/
public class CurrentTransformer:EntityBase
{
    public string Number { get; set; }
    public string TransformerType { get; set; }    // Тип трансформатора тока
    public DateTime VerificationDate { get; set; } // Дата поверки
    public float TransformationRatio { get; set; } // КТТ (коэффициент трансформации)
    // Links
    public long ElectricityMeasurementPointId { get; set; }
    public ElectricityMeasurementPoint ElectricityMeasurementPoint { get; set; }
}