namespace PMS_API{
    public static class OrganisationDataFactory
    {
        public static IOrganisationDataAccessLayer GetOrganisationDataAccessLayerObject()
        {
            return new OrganisationDataAccessLayer();
        }
      
         public static Organisation GetOrganisationObject()
        {
            return new Organisation();
        }
       public static IOrganisationServices GetOrganisationServiceObject()
        {
        return new OrganisationServices();
        }
    }
}