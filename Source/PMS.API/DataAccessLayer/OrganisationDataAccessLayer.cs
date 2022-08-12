using Microsoft.EntityFrameworkCore;
namespace PMS_API
{
    public class OrganisationDataAccessLayer : IOrganisationDataAccessLayer
    {
       private readonly Context _db = DbContextDataFactory.GetDbContextObject();  
       private readonly ILogger<OrganisationDataAccessLayer> _logger = default!;
        
         public List<Organisation> GetOrganisations() // List of Organisations
        {
            try
            {
                return _db.Organisations!.Where(e=>e.IsActive==true).ToList();
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