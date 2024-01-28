using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Models;

namespace TNE_Test.DTO.CurrentTransformers;

public class CurrentTransformerCreateDto:CurrentTransformerBaseDto
{
    [Required]
    public new string Number { get; set; }
    [Required]
    public new string TransformerType { get; set; } // Тип трансформатора тока
    [Required]
    public new string VerificationDate { get; set; }   // Дата поверки
    [Required]
    public new float TransformationRatio { get; set; } // КТТ (коэффициент трансформации)

    public static explicit operator CurrentTransformer(CurrentTransformerCreateDto dto) => new CurrentTransformer
    {
        Number = dto.Number,
        TransformerType = dto.TransformerType,
        VerificationDate = DateTime.ParseExact(dto.VerificationDate, new [] { "o" },
            CultureInfo.InvariantCulture,
            DateTimeStyles.None ),
        TransformationRatio = dto.TransformationRatio
    };
}