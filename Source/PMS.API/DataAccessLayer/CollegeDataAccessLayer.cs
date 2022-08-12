using Microsoft.EntityFrameworkCore;
namespace PMS_API.DataAccessLayer
{
    public class  CollegeDataAccessLayer : ICollegeDataAccessLayer
    {
       private readonly Context _db = DbContextDataFactory.GetDbContextObject();  
       private readonly ILogger<CollegeDataAccessLayer> _logger = default!;
        
         public List<College> GetColleges() //List Of Colleges
        {
            try
            {
                return _db.Colleges!.Where(e=>e.IsActive==true).ToList();
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