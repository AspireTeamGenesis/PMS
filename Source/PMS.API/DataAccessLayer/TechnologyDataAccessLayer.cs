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