namespace PMS_API
{
    public class ProfileStatusServices : IProfileStatusServices
    {
        private readonly IProfileStatusDataAccessLayer _ProfileStatusDataAccessLayer = ProfileStatusDataFactory.GetProfileStatusDataAccessLayerObject();
       // private ProfileStatus _ProfileStatus = ProfileStatusDataFactory.GetProfileStatusObject();
        private readonly ILogger<ProfileStatusServices>_logger = default!;
       
        public IEnumerable<ProfileStatus> ViewProfileStatuss()
        {
            try
            {
                //IEnumerable<ProfileStatus> profileStatuss = new List<ProfileStatus>();
                return from profileStatus in _ProfileStatusDataAccessLayer.GetProfileStatuss() where profileStatus.IsActive == true select profileStatus;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                 throw;
                
            }
        }

    }
}