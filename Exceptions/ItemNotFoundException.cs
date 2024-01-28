namespace TNE_Test.Exceptions;

public class ItemNotFoundException:Exception
{
    public ItemNotFoundException() : base($"Объект не найден.")
    {
    }
}