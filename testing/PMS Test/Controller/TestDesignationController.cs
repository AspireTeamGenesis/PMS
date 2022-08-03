using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PMS_API;
namespace Testing.Controller
{
    public class TestDesignationController
    {
        private readonly DesignationController DesignationControllers;
        private readonly Mock<IDesignationServices> DesignationServices=new Mock<IDesignationServices>();
        private readonly Mock<ILogger<DesignationController>> logger =new Mock<ILogger<DesignationController>>();
        public TestDesignationController()
        {
            DesignationControllers=new DesignationController(logger.Object, DesignationServices.Object);
        }
      
        
        [Fact]
       public void ViewDesignation_ShouldreturnStatuscode200_WhenDesignationObjectIsPassed()
       {

        //    Designation Designation=DesignationMock.AddValidDesignation();
           
           var Result=DesignationControllers.ViewDesignations()as ObjectResult;//act
           Assert.Equal(200,Result?.StatusCode);
       }
 
}


      

    


      



    }
