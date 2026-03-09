namespace Application.ChangeUserRole;

public record ChangeRoleRequest(string UserEmail, string NewClaim);