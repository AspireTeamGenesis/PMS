using Microsoft.EntityFrameworkCore;
namespace PMS_API.DataAccessLayer
{
    public class CollegeDataAccessLayer : ICollegeDataAccessLayer
    {
       private readonly Context _db = DbContextDataFactory.GetDbContextObject();  
       private readonly ILogger<CollegeDataAccessLayer> _logger = default!;
        
         public List<College> GetColleges() //List Of Colleges
        {
            try
            {
                return _db.Colleges!.ToList();
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
                throw;
            }
        }



    }
}