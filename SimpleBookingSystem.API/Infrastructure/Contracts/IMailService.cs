using SimpleBookingSystem.API.Models;

namespace SimpleBookingSystem.API.Infrastructure.Contracts
{
    public interface IMailService
    {
        void SendMail(MailRequest mailRequest);
    }
}
