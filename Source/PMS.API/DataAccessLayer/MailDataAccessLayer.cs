using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace PMS_API
{
    public interface IMailDataAccessLayer
    {
        public string GetUserEmail(int Userid);
        public string GetUserName(int Userid);
        public string GetUserNameWithProfileId(int profileId);
    }
    public class MailDataAccessLayer:IMailDataAccessLayer
    {
        private Context _context;
        private ILogger<ProfileService> _logger;

        public  MailDataAccessLayer(Context context, ILogger<ProfileService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public string GetUserEmail(int Userid)
        {
            try
            {
                return _context.users.Find(Userid).Email;
            }
            catch (Exception getUserEmailException)
            {
                _logger.LogInformation($"Exception on Mail DAL : GetUserEmail(int UserId) : {getUserEmailException.Message} : {getUserEmailException.StackTrace}");
                throw getUserEmailException;
            }
        }
        public string GetUserName(int Userid)
        {
            try
            {
                return _context.users.Find(Userid).UserName;
            }
            catch (Exception getUserNameException)
            {
                _logger.LogInformation($"Exception on Mail DAL :GetUserName(int Userid) : {getUserNameException.Message} : {getUserNameException.StackTrace}");
                throw getUserNameException;
            }
        }

        public string GetUserNameWithProfileId(int profileId)
        {
            try
            {
                int userId= (from profile in _context.profile where profile.ProfileId==profileId select profile.ProfileId).First();
                return _context.users.Find(userId).UserName;
            }
            catch (Exception getUserNameException)
            {
                _logger.LogInformation($"Exception on Mail DAL :GetUserName(int Userid) : {getUserNameException.Message} : {getUserNameException.StackTrace}");
                throw getUserNameException;
            }
        }
    }
    
    }
