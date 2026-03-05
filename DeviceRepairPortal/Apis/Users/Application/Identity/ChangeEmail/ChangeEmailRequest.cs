namespace Application.Identity.ChangeEmail;

public record ChangeEmailRequest(string CurrentEmail, string NewEmail, string CurrentPassword);