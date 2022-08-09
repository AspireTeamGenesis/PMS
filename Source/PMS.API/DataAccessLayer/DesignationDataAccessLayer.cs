using Microsoft.EntityFrameworkCore;
using PMS_API.DataAccessLayer;

namespace PMS_API
{
    public class DesignationDataAccessLayer : IDesignationDataAccessLayer
    {
       private readonly Context _db = DbContextDataFactory.GetDbContextObject();  
       private readonly ILogger<DesignationDataAccessLayer> _logger = default!;
        
         public List<Designation> GetDesignations() //List of Designtion
        {
            try
            {
                return _db.Designations!.Include(d=>d.users).ToList();
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