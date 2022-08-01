using PMS_API;

namespace PMS_API
{
    public interface IMailService
    {
        public Task SendEmailAsync(MailRequest mailRequest,bool isSingleMail);
       
        public MailRequest RequestToUpdate(int Userid);
        public Task RequestToUpdateFile(int profileId);
        public Task ShareProfile(string profileUrl,int profileId,string toEmailName);
    }
}