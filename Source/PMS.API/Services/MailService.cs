using MailKit;
using MimeKit;
using PMS_API;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Net.Mail;


namespace PMS_API
{

    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private ILogger<MailService> _logger;
        private IMailDataAccessLayer _mailDataAccessLayer;
        public MailService(ILogger<MailService> logger, IOptions<MailSettings> mailSettings, IMailDataAccessLayer mailDataAccessLayer)
        {
            _logger = logger;
            _mailSettings = mailSettings.Value;
            _mailDataAccessLayer = mailDataAccessLayer;
        }

        public async Task SendEmailAsync(MailRequest mailRequest, bool isSingleMail)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                if (isSingleMail == true)
                    email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                else
                {
                    foreach (var mailid in mailRequest.ToEmailList)
                        email.To.Add(MailboxAddress.Parse(mailid));
                }
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();

                builder.TextBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (SmtpException sendEmailAsyncSmptException)
            {
                _logger.LogInformation($"SmptException at Mail Service : SendEmailAsync(MailRequest mailRequest, bool isSingleMail) : {sendEmailAsyncSmptException.Message} : {sendEmailAsyncSmptException.StackTrace}");
                throw new MailException("Error Occured While Sending Mail");
            }
            catch (Exception sendEmailAsyncException)
            {
                _logger.LogInformation($"Exception at Mail Service : SendEmailAsync(MailRequest mailRequest, bool isSingleMail) : {sendEmailAsyncException.Message} : {sendEmailAsyncException.StackTrace}");
                throw new MailException("Error Occured While Sending Mail");
            }
        }
        public MailRequest RequestToUpdate(int Userid)
        {
            try
            {
                MailRequest mailRequest = MailDataFactory.GetMailRequestObject();
                mailRequest.ToEmail = _mailDataAccessLayer.GetUserEmail(Userid);
                mailRequest.Subject = "Request To Update";
                mailRequest.Body = $"Hi, {_mailDataAccessLayer.GetUserName(Userid)}.\n\n You have to update your profile \n\nThank you";
                return mailRequest;
            }
            catch (Exception RequestToUpdateException)
            {
                _logger.LogInformation($"Exception at Mail Service : RequestToUpdate(int Userid) : {RequestToUpdateException.Message}");
                throw new MailException("Error Occured While Sending Mail");
            }
        }
        public async Task RequestToUpdateFile(int profileId)
        {            
            string userName = _mailDataAccessLayer.GetUserNameWithProfileId(profileId);
            string path = @"C:\Users\harini.rajkumar.ASPIRESYS\Documents\PMS_Mail_Service";
            string fileName = "User"+userName+System.DateTime.Now.Ticks+".txt";
            string emailContent = $"Hi, {userName}.\n\n You have't updated your profile for the past 6 months.\n Kindly update your profile \n\nThank you - Team Genesis \n\nFor any queries contact : teamgenesis@gmail.com";
            using StreamWriter file = File.CreateText(Path.Combine(path, fileName));
            await file.WriteLineAsync(emailContent);
        }
        public async Task ShareProfile(string profileUrl,int profileId,string toEmailName)
        {            
            string userName = _mailDataAccessLayer.GetUserNameWithProfileId(profileId);
            string path = @"C:\Users\harini.rajkumar.ASPIRESYS\Documents\PMS_Mail_Service";
            string fileName = "Profile"+userName+System.DateTime.Now.Ticks+".txt";
            string emailContent = $"Hi, {toEmailName}.\n\n I have attached {userName}'s profile\n\n Click here for profile : {profileUrl}\n\n Thank you - Team Genesis\n\nFor any queries contact : teamgenesis@gmail.com";
            using StreamWriter file = File.CreateText(Path.Combine(path, fileName));
            await file.WriteLineAsync(emailContent);
        }
    }
}
