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
                return _db.Domains!.Where(e=>e.IsActive==true).ToList();
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