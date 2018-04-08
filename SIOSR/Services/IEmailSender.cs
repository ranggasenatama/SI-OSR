using System.Threading.Tasks;

namespace SIOSR.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
