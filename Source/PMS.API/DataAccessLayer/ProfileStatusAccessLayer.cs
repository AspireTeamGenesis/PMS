
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
                return _db.ProfileStatuss!.Where(e=>e.IsActive==true).ToList();
            }
            catch (InvalidOperationException ex)              //InvalidOperation Exception Occurs
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                throw new InvalidOperationException();

            }
            catch (Exception ex)                      //Unknown Exception Occurs
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                 throw;
                
            }
        }



    }
}