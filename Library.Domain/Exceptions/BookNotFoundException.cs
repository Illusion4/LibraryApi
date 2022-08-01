namespace Library.Domain.Exceptions;

public class BookNotFoundException : Exception
{
    public override string Message { get; } = "Book not found";
}