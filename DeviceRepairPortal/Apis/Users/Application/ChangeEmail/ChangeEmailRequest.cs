namespace Application.ChangeEmail;

public record ChangeEmailRequest(string CurrentEmail, string NewEmail, string Password);