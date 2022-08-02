using Microsoft.EntityFrameworkCore;
using PMS_API.DataAccessLayer;

namespace PMS_API
{
    public class DesignationDataAccessLayer : IDesignationDataAccessLayer
    {
        private Context _db = DbContextDataFactory.GetDbContextObject();
        private ILogger<DesignationDataAccessLayer> _logger;

        //Getting The List of Designations
        public List<Designation> GetDesignations() 
        {
            try
            {
                return _db.Designations.Include(d => d.users).ToList();
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