using System.Text.RegularExpressions;

namespace Application.Common.Validators;

public static class EmailValidator
{
	private static readonly Regex EmailRegex = new Regex(
		@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
		RegexOptions.Compiled | RegexOptions.IgnoreCase
	);

	public static bool IsValidEmail(string email)
		=> !string.IsNullOrWhiteSpace(email) && EmailRegex.IsMatch(email) ? true : false;
}