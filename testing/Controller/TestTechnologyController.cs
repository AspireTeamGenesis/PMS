using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PMS_API;
namespace Testing.Controller
{
    public class TestTechnologyController
    {
        private readonly TechnologyController TechnologieControllers;
        private readonly Mock<ITechnologyServices> TechnologieServices=new Mock<ITechnologyServices>();
        private readonly Mock<ILogger<TechnologyController>> logger =new Mock<ILogger<TechnologyController>>();
        public TestTechnologyController()
        {
            TechnologieControllers=new TechnologyController(logger.Object, TechnologieServices.Object);
        }
      
        
        [Fact]
       public void ViewTechnologie_ShouldreturnStatuscode200_WhenTechnologieObjectIsPassed()
       {

        //    Technologie Technologie=TechnologieMock.AddValidTechnologie();
           
           var Result=TechnologieControllers.ViewTechnologies()as ObjectResult;//act
           Assert.Equal(200,Result?.StatusCode);
       }
 
}


      

    


      



    }
