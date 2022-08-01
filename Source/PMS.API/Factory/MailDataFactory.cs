using PMS_API;
namespace PMS_API{
    public static class MailDataFactory
    {
        
        public static MailRequest GetMailRequestObject()
        {
            return new MailRequest();
        }
    }
}