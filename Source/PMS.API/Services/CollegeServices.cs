using PMS_API.DataAccessLayer;
using System.Linq;
namespace PMS_API
{
    public class CollegeServices : ICollegeServices
    {
        private readonly ICollegeDataAccessLayer _collegeDataAccessLayer = CollegeDataFactory.GetCollegeDataAccessLayerObject();
        //private College _college = CollegeDataFactory.GetCollegeObject();
        private readonly ILogger<CollegeServices>_logger = default!;
              
        public IEnumerable<College> ViewColleges() //Getting List of Colleges
        {
            try
            {
                //IEnumerable<College> colleges = new List<College>();
                return from college in _collegeDataAccessLayer.GetColleges() select college; 
            }
            catch (Exception ex) //unknown exception occurs
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}"); 
                 throw;
                
            }
        }

    }
}