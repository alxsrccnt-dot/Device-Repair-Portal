namespace Application.ChangePassword;

public record ChangePasswordRequest(string UserEmail, string OldPassword, string NewPassword);