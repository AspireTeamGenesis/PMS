namespace PMS_API
{
    public class OrganisationServices : IOrganisationServices
    {
        private IOrganisationDataAccessLayer _OrganisationDataAccessLayer = OrganisationDataFactory.GetOrganisationDataAccessLayerObject();
        private Organisation _Organisation = OrganisationDataFactory.GetOrganisationObject();
        private ILogger<OrganisationServices>?_logger;
       
        

       
        public IEnumerable<Organisation> ViewOrganisations()
        {
            try
            {
                IEnumerable<Organisation> organization = new List<Organisation>();
                return organization = from organisation in _OrganisationDataAccessLayer.GetOrganisations() where organisation.IsActive == true select organisation;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                 throw new Exception();
                
            }
        }

    }
}