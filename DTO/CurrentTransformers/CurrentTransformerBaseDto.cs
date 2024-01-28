namespace TNE_Test.DTO.CurrentTransformers;

public class CurrentTransformerBaseDto
{
    public string Number { get; set; }
    public string TransformerType { get; set; }    // Тип трансформатора тока
    public string VerificationDate { get; set; } // Дата поверки
    public float TransformationRatio { get; set; } // КТТ (коэффициент трансформации)
}