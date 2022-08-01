using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PMS_API;
namespace Testing.Controller
{
    public class TestDomainController
    {
        private readonly DomainController DomainControllers;
        private readonly Mock<IDomainServices> DomainServices=new Mock<IDomainServices>();
        private readonly Mock<ILogger<DomainController>> logger =new Mock<ILogger<DomainController>>();
        public TestDomainController()
        {
            DomainControllers=new DomainController(logger.Object, DomainServices.Object);
        }
      
        
        [Fact]
       public void ViewDomain_ShouldreturnStatuscode200_WhenDomainObjectIsPassed()
       {

        //    Domain Domain=DomainMock.AddValidDomain();
           
           var Result=DomainControllers.ViewDomains()as ObjectResult;//act
           Assert.Equal(200,Result?.StatusCode);
       }
 
}


      

    


      



    }
