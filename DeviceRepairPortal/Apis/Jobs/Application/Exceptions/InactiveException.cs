namespace Application.Exceptions;

public class InactiveException : Exception
{
	public InactiveException(string message) : base(message) { }
}