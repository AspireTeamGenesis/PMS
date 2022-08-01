using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_API;
using Testing.Mock;

namespace Testing.Controller
{
    public class TestLoginController
    {
        private readonly LoginController loginController;

        private Mock<ILoginService> loginservice=new Mock<ILoginService>();
        private Mock<ILogger<LoginController>> logger=new Mock<ILogger<LoginController>>();
        public TestLoginController()
        {
            loginController=new LoginController(loginservice.Object,logger.Object);
        }
        [Theory]
        [InlineData(null,null)]
        public void AuthLogin_ShouldReturnStatusCode400_WhenUsernameandPasswordNull(String Username,string password)
        {
            var Result=loginController.AuthLogin(Username,password)as ObjectResult;
            Assert.Equal(400,Result?.StatusCode);
        }
        [Theory]
        [InlineData("Brindha","Brindha@132")]
        public void AuthLogin_ShouldReturnStatusCode200_WhenUsernameandPasswordValid(String Username,string password)
        {
            loginservice.Setup(obj=>obj.AuthLogin(Username,password)).Returns(new object());
            var Result=loginController.AuthLogin(Username,password) as ObjectResult;
            Assert.Equal(200,Result?.StatusCode);
        }[Theory]
        [InlineData("Brindha","Brindha@132")]
        public void AuthLogin_ShouldReturnStatusCode500_WhenExceptionThrows(String Username,string password)
        {
            loginservice.Setup(obj=>obj.AuthLogin(Username,password)).Throws(new Exception());
            var Result=loginController.AuthLogin(Username,password) as ObjectResult;
            Assert.Equal(500,Result?.StatusCode);
        }

    }
}