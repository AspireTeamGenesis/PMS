using System.Runtime.Serialization;
namespace PMS_API
{
    [Serializable]

    public class MailException : Exception
    {
        public MailException(string errorMessage) : base(errorMessage){}
        protected MailException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}