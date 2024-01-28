using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Models;

namespace TNE_Test.DTO.VoltageTransformers;

public class VoltageTransformerCreateDto:VoltageTransformerBaseDto
{
    [Required]
    public new string Number { get; set; }
    [Required]
    public new float TransformationRatio { get; set; } // КТН (коэффициент трансформации)
    [Required]
    public new string VerificationDate { get; set; } // Дата поверки
    [Required]
    public new string TransformerType { get; set; }    // Тип трансформатора тока

    public static explicit operator VoltageTransformer(VoltageTransformerCreateDto dto) => new VoltageTransformer
    {
        Number = dto.Number,
        TransformationRatio = dto.TransformationRatio,
        VerificationDate = DateTime.ParseExact(dto.VerificationDate, new [] { "o" },
            CultureInfo.InvariantCulture,
            DateTimeStyles.None ),
        TransformerType = dto.TransformerType
    };
}