namespace PMS_API
{
    public class TechnologyServices : ITechnologyServices
    {
        private readonly ITechnologyDataAccessLayer _TechnologyDataAccessLayer = TechnologyDataFactory.GetTechnologyDataAccessLayerObject();
       // private Technology _Technology = TechnologyDataFactory.GetTechnologyObject();
        private readonly ILogger<TechnologyServices>_logger = default!; 
       
        public IEnumerable<Technology> ViewTechnologies()
        {
            try
            {
                //IEnumerable<Technology> technologys = new List<Technology>();
                return from technology in _TechnologyDataAccessLayer.GetTechnologies() select technology;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                 throw;
        
            }
        }

    }
}