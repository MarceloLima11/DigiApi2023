namespace Application.DTOs.User.Request
{
    public record ResetPasswordDTO(string Email, string Token, string Password);
}