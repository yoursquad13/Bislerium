using Application.DTOs.Email;

namespace Application.Interfaces.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto email);
    }
}
