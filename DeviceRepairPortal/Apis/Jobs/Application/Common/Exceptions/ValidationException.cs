using System.Collections.ObjectModel;

namespace Application.Common.Exceptions;

public class ValidationException : Exception
{
	public IEnumerable<string> Errors { get; init; }

	public ValidationException() : base("One or more validation failures have occurred.")
		=> Errors = new Collection<string>();

    public ValidationException(IEnumerable<string> errors) : base("One or more validation failures have occurred.")
        => Errors = errors;

    public ValidationException(string error) : base("One or more validation failures have occurred.")
        => Errors = new Collection<string>() { error };
}
