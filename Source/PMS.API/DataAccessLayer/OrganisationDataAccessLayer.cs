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
                return _db.Organisations!.ToList();
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