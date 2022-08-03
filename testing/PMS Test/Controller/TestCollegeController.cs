using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PMS_API;
namespace Testing.Controller
{
    public class TestCollegeController
    {
        private readonly CollegeController CollegeControllers;
        private readonly Mock<ICollegeServices> CollegeServices=new Mock<ICollegeServices>();
        private readonly Mock<ILogger<CollegeController>> logger =new Mock<ILogger<CollegeController>>();
        public TestCollegeController()
        {
            CollegeControllers=new CollegeController(logger.Object, CollegeServices.Object);
        }
      
        
        [Fact]
       public void ViewCollege_ShouldreturnStatuscode200_WhenCollegeObjectIsPassed()
       {

        //    College College=CollegeMock.AddValidCollege();
           
           var Result=CollegeControllers.ViewColleges()as ObjectResult;//act
           Assert.Equal(200,Result?.StatusCode);
       }
 
}


      

    


      



    }
