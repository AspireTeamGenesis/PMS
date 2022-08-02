using Microsoft.EntityFrameworkCore;
namespace PMS_API
{
    public class OrganisationDataAccessLayer : IOrganisationDataAccessLayer
    {
        private Context _db = DbContextDataFactory.GetDbContextObject();
        private ILogger<OrganisationDataAccessLayer> _logger;

        //Getting the List of Organisations
        public List<Organisation> GetOrganisations() 
        {
            try
            {
                return _db.Organisations.ToList();
            }
            catch (DbUpdateException ex)              //DB Update Exception Occured
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                throw new DbUpdateException();

            }
            catch (OperationCanceledException ex)    //Operation cancelled exception
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                throw new OperationCanceledException();

            }
            catch (Exception ex)                      //unknown exception occured
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                throw ex;

            }
        }



    }
}