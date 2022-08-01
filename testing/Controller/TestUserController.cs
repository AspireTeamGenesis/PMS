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
    public class TestUserController
    {
        private readonly UserController userControllers;
        private readonly Mock<IUserServices> userServices=new Mock<IUserServices>();
        private readonly Mock<ILogger<UserController>> logger =new Mock<ILogger<UserController>>();
        public TestUserController()
        {
            userControllers=new UserController(userServices.Object,logger.Object);
        }
       //AddUser
       [Theory]
       [InlineData(null)]
       public void AddUser_ShouldreturnStatuscode400_WhenUserObjectIsNull(User user)
       {
           var Result=userControllers.AddUser(user)as ObjectResult;//act
           Assert.Equal(400,Result?.StatusCode);
       }
        
        [Fact]
       public void AddUser_ShouldreturnStatuscode200_WhenUserObjectIsPassed()
       {

           User user=UserMock.AddValidUser();
           userServices.Setup(obj => obj.AddUser(user)).Returns(true);
           var Result=userControllers.AddUser(user)as ObjectResult;//act
           Assert.Equal(200,Result?.StatusCode);
       }
        [Fact]
       public void AddUser_ShouldreturnStatuscode500_WhenUserObjectIsPassed()
       {

           User user=UserMock.AddValidUser();
           userServices.Setup(obj => obj.AddUser(user)).Returns(false);
           var Result=userControllers.AddUser(user)as ObjectResult;//act
           Assert.Equal(500,Result?.StatusCode);
       }
       //Exception
       [Fact]
       public void AddUser_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
       {

          User user=UserMock.AddValidUser();
           userServices.Setup(obj => obj.AddUser(user)).Throws(new ValidationException());
           var Result=userControllers.AddUser(user)as ObjectResult;//act
           Assert.Equal(400,Result?.StatusCode);
       }
         [Fact]
       public void AddUser_ShouldreturnStatuscode400_WhenArgumentNullExceptionIsThrown()
       {

           User user=UserMock.AddValidUser();
           userServices.Setup(obj => obj.AddUser(user)).Throws(new ArgumentNullException());
           var Result=userControllers.AddUser(user)as ObjectResult;//act
           Assert.Equal(400,Result?.StatusCode);
       }
        
       [Fact]
        public void AddUser_ShouldreturnStatuscode500_WhenExceptionIsThrown()
       {

          User user=UserMock.AddValidUser();
           userServices.Setup(obj => obj.AddUser(user)).Throws(new Exception());//Arrange
           var Result=userControllers.AddUser(user)as ObjectResult;//act
           Assert.Equal(500,Result?.StatusCode);
       }

       //GetUser
       
       [Theory]
       [InlineData(-1)]
       public void GetUser_ShouldReturnStatusCode400_WhenIdIsPassed(int UserId)
       {
        var Result=userControllers.GetUserById(UserId) as ObjectResult;
        Assert.Equal(400,Result?.StatusCode);
       }

       [Theory]
       [InlineData(001)]
       public void GetUser_ShouldReturnStatusCode200_WhenIdIsPassed(int UserId)
       {
        userServices.Setup(obj =>obj.GetUser(UserId)).Returns(new object());
        var Result=userControllers.GetUserById(UserId) as ObjectResult;
        Assert.Equal(200,Result?.StatusCode);

       }
       //Exception
       [Theory]
       [InlineData(1)]
       public void GetUser_ShouldReturnStatusCode500_WhenExceptionIsThrown(int UserId)
       {
        userServices.Setup(obj =>obj.GetUser(UserId)).Throws(new Exception());
        var Result=userControllers.GetUserById(UserId) as ObjectResult;
        Assert.Equal(500,Result?.StatusCode);

       }

       //GetAll
       [Fact]
       public void GetAllUsers_ShouldReturnGetAllUsers_WhenMethodIsCalled()
       {
          var user=UserMock.GetValidateAllUsers();
          userServices.Setup(obj=>obj.GetallUsers()).Returns(user);
          var Result=userControllers.Getallusers() as ObjectResult;
          Assert.Equal(user,Result?.Value);
          
       }
       //Exception
        [Fact]
       public void GetAllUsers_ShouldReturnStatuscode500_WhenExceptionIsThrown()
       {
          
          userServices.Setup(obj=>obj.GetallUsers()).Throws(new Exception());
          var Result=userControllers.Getallusers() as ObjectResult;
          Assert.Equal(500,Result?.StatusCode);
          
       }

       //GetSpecificUser
       [Fact]
       public void GetSpecificUser_ShouldReturnObject_WhenMethodIsCalled()
       {
            userServices.Setup(obj=>obj.GetSpecificUserDetails()).Returns(new object());
            var Result=userControllers.GetSpecificUserDetails() as ObjectResult;
            Assert.Equal(200,Result?.StatusCode);
       }
       [Fact]
       public void GetSpecificUserDetails_ShouldReturnStatusCode500_WhenObjectIsPassed()
       {
            userServices.Setup(obj=>obj.GetSpecificUserDetails()).Throws(new Exception());
            var Result=userControllers.GetSpecificUserDetails() as ObjectResult;
            Assert.Equal(500,Result?.StatusCode);
       }

       //Update
       [Theory]
       [InlineData(null)]
       public void UpdateUser_ShouldReturnStatusCode400_WhenObjectIsPassed(User user)
       {
           var Result=userControllers.UpdateUser(user) as ObjectResult;
           Assert.Equal(400,Result?.StatusCode);
       }

       [Fact]
       public void UpdateUser_ShouldReturnStatusCode200_WhenObjectIsPassed()
       {
           User user=UserMock.UpdateValidUser();
           userServices.Setup(obj=>obj.UpdateUser(user)).Returns(true);
           var Result=userControllers.UpdateUser(user) as ObjectResult;
           Assert.Equal(200,Result?.StatusCode);
       }
        [Fact]
       public void UpdateUser_ShouldReturnStatusCode500_WhenUserServiceReturnsFalse()
       {
           User user=UserMock.UpdateValidUser();
           userServices.Setup(obj=>obj.UpdateUser(user)).Returns(false);
           var Result=userControllers.UpdateUser(user) as ObjectResult;
           Assert.Equal(500,Result?.StatusCode);
       }
       //Exception
        [Fact]
       public void UpdateUser_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown()
       {
           User user=UserMock.UpdateValidUser();
           userServices.Setup(obj=>obj.UpdateUser(user)).Throws(new ArgumentNullException());
           var Result=userControllers.UpdateUser(user) as ObjectResult;
           Assert.Equal(400,Result?.StatusCode);
       }

       [Fact]
       public void UpdateUser_ShouldReturnStatusCode500_WhenExceptionIsThrown()
       {
           User user=UserMock.UpdateValidUser();
           userServices.Setup(obj=>obj.UpdateUser(user)).Throws(new Exception());
           var Result=userControllers.UpdateUser(user) as ObjectResult;
           Assert.Equal(500,Result?.StatusCode);
       }

        //Remove
        [Theory]
        [InlineData(-1)]
        public void RemoveUser_ShouldReturnStatusCode400_WhenIdIsPassed(int Userid)
        {
            var Result=userControllers.Disable(Userid) as ObjectResult;
            Assert.Equal(400,Result?.StatusCode);
        }
       [Theory]
       [InlineData(2)]
       
       public void RemoveUser_ShouldReturnStatusCode200_WhenIdIsPassed(int id)
       {
            userServices.Setup(obj=>obj.Disable(id)).Returns(true);
            var Result=userControllers.Disable(id) as ObjectResult;
            Assert.Equal(200,Result?.StatusCode);
       }
       [Theory]
       [InlineData(1)]
       public void RemoveUser_ShouldReturnStatusCode500_WhenIdIsPassed(int id)
       {
            userServices.Setup(obj=>obj.Disable(id)).Returns(false);
            var Result=userControllers.Disable(id) as ObjectResult;
            Assert.Equal(500,Result?.StatusCode);
       }

      //Exception
       [Theory]
       [InlineData(1)]
       public void RemoveUser_ShouldReturnStatusCode500_WhenExceptionIsThrown(int UserId)
       {
            userServices.Setup(obj =>obj.Disable(UserId)).Throws(new Exception());
            var Result=userControllers.Disable(UserId) as ObjectResult;
            Assert.Equal(500,Result?.StatusCode);

       }

       //ChangePassword

       [Theory]
       [InlineData(null,null,null)]
       public void ChangePassword_ShouldReturnStatusCode400_WhenPasswordIsNull(string Oldpassword,string Newpassword,string Confirmpassword)
       {
            var Result=userControllers.ChangePassword(Oldpassword,Newpassword,Confirmpassword) as ObjectResult;
            Assert.Equal(400,Result?.StatusCode);
       }
       [Theory]
       [InlineData("Brindha17@12","Brindha@123","BrindhaM@123",1)]
       public void ChangePassword_ShouldReturnStatusCode200_WhenPasswordIsPassed(string Oldpassword,string Newpassword,string Confirmpassword,int Userid)
       {
           userServices.Setup(obj=>obj.ChangePassword(Oldpassword,Newpassword,Confirmpassword,Userid)).Returns(true);
           var Result=userControllers.ChangePassword(Oldpassword,Newpassword,Confirmpassword) as ObjectResult;
           Assert.Equal(200,Result?.StatusCode);

       }
       [Theory]
       [InlineData("Brindha17@12","BrindhaM@123","BrindhaM@123",1)]
       public void ChangePassword_ShouldReturnStatusCode500_WhenPasswordIsPassed(string Oldpassword,string Newpassword,string Confirmpassword,int Userid)
       {
           userServices.Setup(obj=>obj.ChangePassword(Oldpassword,Newpassword,Confirmpassword,Userid)).Returns(false);
           var Result=userControllers.ChangePassword(Oldpassword,Newpassword,Confirmpassword) as ObjectResult;
           Assert.Equal(500,Result?.StatusCode);

       }
       [Theory]
       [InlineData("Brindha17@12","BrindhaM@123","BrindhaM@123",1)]
       public void ChangePassword_ShouldReturnStatusCode400_WhenValidationExceptionIsThrown(string Oldpassword,string Newpassword,string Confirmpassword,int Userid)
       {
           userServices.Setup(obj=>obj.ChangePassword(Oldpassword,Newpassword,Confirmpassword,Userid)).Throws(new ValidationException());
           var Result=userControllers.ChangePassword(Oldpassword,Newpassword,Confirmpassword) as ObjectResult;
           Assert.Equal(400,Result?.StatusCode);

       }
       [Theory]
       [InlineData("Brindha17@12","BrindhaM@123","BrindhaM@123",1)]
       public void ChangePassword_ShouldReturnStatusCode500_WhenExceptionIsThrown(string Oldpassword,string Newpassword,string Confirmpassword,int Userid)
       {
           userServices.Setup(obj=>obj.ChangePassword(Oldpassword,Newpassword,Confirmpassword,Userid)).Throws(new Exception());
           var Result=userControllers.ChangePassword(Oldpassword,Newpassword,Confirmpassword) as ObjectResult;
           Assert.Equal(500,Result?.StatusCode);

       }

    }
}