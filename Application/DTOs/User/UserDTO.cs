namespace Application.DTOs.User
{
    public record UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}