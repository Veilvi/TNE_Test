using Models;

namespace TNE_Test.DTO.CurrentTransformers;

public class CurrentTransformerReadDto:CurrentTransformerBaseDto
{
    public long Id { get; set; }
    public static explicit operator CurrentTransformerReadDto(CurrentTransformer ct) =>
        new CurrentTransformerReadDto
        {
            Id = ct.Id,
            Number = ct.Number,
            TransformerType = ct.TransformerType,
            VerificationDate = ct.VerificationDate.ToString("o"),
            TransformationRatio = ct.TransformationRatio
        };
    public static List<CurrentTransformerReadDto> ToList(List<CurrentTransformer> ct)
    {
        var Dtos= new List<CurrentTransformerReadDto>();
        foreach (var m in ct)
        {
            Dtos.Add((CurrentTransformerReadDto)m);
        }
        return Dtos;
    }
}