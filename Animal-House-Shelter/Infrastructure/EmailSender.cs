using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Animal_House_Shelter.Infrastructure
{
    //https://github.com/BrightSoul/background-email-sender
    public class EmailSender : IEmailSender, IHostedService, IDisposable
    {
        private readonly BufferBlock<MailMessage> mailMessages;
        private readonly ILogger logger;
        private readonly SmtpClient smtpClient;
        private Task sendTask;
        private CancellationTokenSource cancellationTokenSource;
        public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
        {
            this.logger = logger;
            this.mailMessages = new BufferBlock<MailMessage>();
            this.smtpClient = CreateSmtpClient(configuration);
        }

        private SmtpClient CreateSmtpClient(IConfiguration configuration)
        {
            return new SmtpClient
            {
                Host = configuration["Smtp:Host"],
                Port = configuration.GetValue<int>("Smtp:Port"),
                EnableSsl = configuration.GetValue<bool>("Smtp:Ssl"),
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(
                                    userName: configuration["Smtp:Username"],
                                    password: configuration["Smtp:Password"]
                )
            };
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting background e-mail delivery");
            cancellationTokenSource = new CancellationTokenSource();
            sendTask = Send(cancellationTokenSource.Token);
            return Task.CompletedTask;
        }
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            CancelSendTask();
            await Task.WhenAny(sendTask, Task.Delay(Timeout.Infinite, cancellationToken));
        }

        private void CancelSendTask()
        {
            try
            {
                if (cancellationTokenSource != null)
                {
                    logger.LogInformation("Stopping e-mail background delivery");
                    cancellationTokenSource.Cancel();
                    cancellationTokenSource = null;
                }
            }
            catch
            {

            }
        }

        public void Post(string subject, string body, string recipients, string sender)
        {
            var mailMessage = new MailMessage(
               from: sender,
               to: recipients
            )
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            bool posted = mailMessages.Post(mailMessage);
            if (!posted)
            {
                throw new InvalidOperationException("This service is no longer accepting e-mails");
            }
        }

        public async Task Send(CancellationToken token)
        {
            logger.LogInformation("E-mail background delivery started");

            while (!token.IsCancellationRequested)
            {
                MailMessage message = null;
                try
                {
                    message = await mailMessages.ReceiveAsync(token);

                    await smtpClient.SendMailAsync(message);
                    logger.LogInformation($"E-mail sent to {message.To}");
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch
                {
                    logger.LogWarning($"Couldn't send an e-mail to {message.To}");
                }
            }

            logger.LogInformation("E-mail background delivery stopped");
        }

        public void Dispose()
        {
            CancelSendTask();
        }
    }
}
