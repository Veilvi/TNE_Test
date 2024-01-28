using Models;

namespace TNE_Test.DTO.VoltageTransformers;

public class VoltageTransformerReadDto:VoltageTransformerBaseDto
{

    public static explicit operator VoltageTransformerReadDto(VoltageTransformer vt) =>
        new VoltageTransformerReadDto
        {
            Number = vt.Number,
            TransformationRatio = vt.TransformationRatio,
            VerificationDate = vt.VerificationDate.ToString("o"),
            TransformerType = vt.TransformerType
        };
    public static List<VoltageTransformerReadDto> ToList(List<VoltageTransformer> vt)
    {
        var Dtos= new List<VoltageTransformerReadDto>();
        foreach (var m in vt)
        {
            Dtos.Add((VoltageTransformerReadDto)m);
        }
        return Dtos;
    }
}