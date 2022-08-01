using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PMS_API;
namespace Testing.Controller
{
    public class TestOrganisationController
    {
        private readonly OrganisationController OrganisationControllers;
        private readonly Mock<IOrganisationServices> OrganisationServices=new Mock<IOrganisationServices>();
        private readonly Mock<ILogger<OrganisationController>> logger =new Mock<ILogger<OrganisationController>>();
        public TestOrganisationController()
        {
            OrganisationControllers=new OrganisationController(logger.Object, OrganisationServices.Object);
        }
      
        
        [Fact]
       public void ViewOrganisation_ShouldreturnStatuscode200_WhenOrganisationObjectIsPassed()
       {

        //    Organisation Organisation=OrganisationMock.AddValidOrganisation();
           
           var Result=OrganisationControllers.ViewOrganisations()as ObjectResult;//act
           Assert.Equal(200,Result?.StatusCode);
       }
 
}


      

    


      



    }
