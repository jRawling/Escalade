
namespace Escalade.Application.UserSession.Dto
{
    public class CreateUserDto
    {
        public CreateUserDto(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public string Username { get; }
        public string Email { get; }
        public string Password { get; }
    }
}