using PMS_API.DataAccessLayer;
using System.Linq;
namespace PMS_API
{
    public class DesignationServices : IDesignationServices
    {
        private readonly IDesignationDataAccessLayer _designationDataAccessLayer = DesignationDataFactory.GetDesignationDataAccessLayerObject();
        //private Designation _designation = DesignationDataFactory.GetDesignationObject();
        private readonly ILogger<DesignationServices>_logger = default!;
              
        public IEnumerable<Designation> ViewDesignations()
        {
            try
            {
                
                return from designation in _designationDataAccessLayer.GetDesignations() select designation;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                 throw;
                
            }
        }

    }
}