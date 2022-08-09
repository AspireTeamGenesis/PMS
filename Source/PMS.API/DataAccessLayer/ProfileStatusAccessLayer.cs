
using Microsoft.EntityFrameworkCore;
namespace PMS_API
{
    public class ProfileStatusDataAccessLayer : IProfileStatusDataAccessLayer
    {
       private readonly Context _db = DbContextDataFactory.GetDbContextObject();  
       private readonly ILogger<ProfileStatusDataAccessLayer> _logger = default!;
        
         public List<ProfileStatus> GetProfileStatuss() // List of ProfileStatus
        {
            try
            {
                return _db.ProfileStatuss!.ToList();
            }
            catch (InvalidOperationException ex)              //DB Update Exception Occured
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                throw new InvalidOperationException();

            }
            catch (Exception ex)                      //unknown exception occured
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                 throw;
                
            }
        }



    }
}