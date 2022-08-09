using Microsoft.EntityFrameworkCore;
namespace PMS_API
{
    public class TechnologyDataAccessLayer : ITechnologyDataAccessLayer
    {
       private readonly Context _db = DbContextDataFactory.GetDbContextObject();  
       private readonly ILogger<TechnologyDataAccessLayer> _logger = default!;
        
         public List<Technology> GetTechnologies() // List of Technologies
        {
            try
            {
                return _db.Technologies!.ToList();
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