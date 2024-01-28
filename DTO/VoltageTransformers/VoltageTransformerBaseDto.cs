namespace TNE_Test.DTO.VoltageTransformers;

public class VoltageTransformerBaseDto
{
    public string Number { get; set; }
    public float TransformationRatio { get; set; } // КТН (коэффициент трансформации)
    public string VerificationDate { get; set; } // Дата поверки
    public string TransformerType { get; set; }    // Тип трансформатора тока
}