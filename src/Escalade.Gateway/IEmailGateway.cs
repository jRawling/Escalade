using Escalade.Domain.Model;
using System.Threading.Tasks;

namespace Escalade.Gateway
{
    public interface IEmailGateway
    {
        Task SendEmailVerificationAsync(User user, string token);
    }
}