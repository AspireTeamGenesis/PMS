using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PMS_API;
namespace Testing.Controller
{
    public class TestProfileStatusController
    {
        private readonly ProfileStatusController ProfileStatusControllers;
        private readonly Mock<IProfileStatusServices> ProfileStatusServices=new Mock<IProfileStatusServices>();
        private readonly Mock<ILogger<ProfileStatusController>> logger =new Mock<ILogger<ProfileStatusController>>();
        public TestProfileStatusController()
        {
            ProfileStatusControllers=new ProfileStatusController(logger.Object, ProfileStatusServices.Object);
        }
      
        
        [Fact]
       public void ViewProfileStatus_ShouldreturnStatuscode200_WhenProfileStatusObjectIsPassed()
       {

        //    ProfileStatus ProfileStatus=ProfileStatusMock.AddValidProfileStatus();
           
           var Result=ProfileStatusControllers.ViewProfileStatuss()as ObjectResult;//act
           Assert.Equal(200,Result?.StatusCode);
       }
 
}


      

    


      



    }
