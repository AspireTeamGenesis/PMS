using Microsoft.EntityFrameworkCore;
namespace PMS_API.DataAccessLayer
{
    public class DomainDataAccessLayer : IDomainDataAccessLayer
    {
       private readonly Context _db =DbContextDataFactory.GetDbContextObject();  
       private readonly ILogger<DomainDataAccessLayer> _logger = default!;
        
         public List<Domain> GetDomains() // List of Domains
        {
            try
            {
                return _db.Domains!.ToList();
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