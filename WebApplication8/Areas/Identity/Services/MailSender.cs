using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Areas.Identity.Services
{
    public class MailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("webApp", "noreply.webapp@gmail.com"));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = subject;

            var builder = new BodyBuilder();

            builder.HtmlBody = htmlMessage;

            // builder.Attachments.Add(@"C:\file\data.xlxs");

            message.Body = builder.ToMessageBody();

            try
            {
                var client = new SmtpClient();

                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("noreply.rentacar@gmail.com", "Rentacar2019");
                client.Send(message);
                client.Disconnect(true);

                Console.WriteLine("Send Mail Success.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Send Mail Failed : " + e.Message);
            }
            return Task.CompletedTask;
        }
    }
}
