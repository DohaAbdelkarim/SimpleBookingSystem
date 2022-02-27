using Microsoft.Extensions.Logging;
using SimpleBookingSystem.API.Infrastructure.Contracts;
using SimpleBookingSystem.API.Models;
using System;

namespace SimpleBookingSystem.API.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly ILogger<MailService> _logger;
        public MailService(ILogger<MailService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public void SendMail(MailRequest mailRequest)
        {
            Console.WriteLine($"EMAIL SENT TO {mailRequest.ToEmail} FOR {mailRequest.Body}");
            _logger.LogInformation($"An email with subject {mailRequest.Subject} Sent to {mailRequest.ToEmail} successfully.");
        }
    }
}