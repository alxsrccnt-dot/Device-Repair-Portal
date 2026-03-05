namespace Application.Identity.ChangePassword;

public record ChangePasswordRequest(string UserEmail, string OldPassword, string NewPassword);