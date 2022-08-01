namespace PMS_API
{
    public class MailException : Exception
    {
        public MailException(string errorMessage) : base(errorMessage){}
    }
}