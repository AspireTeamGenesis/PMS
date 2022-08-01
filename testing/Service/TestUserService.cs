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
namespace Testing.Service
{
    public class TestUserService
    {
        private readonly UserServices Userservices;
        private readonly Mock<IUserData> Userdata=new Mock<IUserData>();
        private readonly Mock<ILogger<UserServices>> logger=new Mock<ILogger<UserServices>>();
        public TestUserService()
        {
            Userservices=new UserServices(Userdata.Object,logger.Object);
        }

        //Add
        
        [Theory]
        [InlineData(null)]
        public void AddUser_ShouldThrowArgumentNullException_WhenUserObjectIsNull(User user)
        {
            Assert.Throws<ArgumentNullException>(() => Userservices.AddUser(user));
        }
        [Fact]
        public void AddUser_ShouldReturnTrue_WhenObjectIsPassed()
        {
            User user=UserMock.AddValidUser();
            Userdata.Setup(obj=>obj.AddUser(user)).Returns(true);
            var Result=Userservices.AddUser(user);
            Assert.True(Result);
        }
        [Fact]
        public void AddUser_ShouldThrowValidationException_WhenUserObjectIsInvalid()
        {
            User user=new User();
            Assert.Throws<ValidationException>(() => Userservices.AddUser(user));
        }
        [Fact]
       public void AddUser_ShouldReturnFalse_WhenExceptionIsThrown()
       {
           User user=UserMock.AddValidUser();
           Userdata.Setup(obj=>obj.AddUser(user)).Throws(new Exception());
           var Result=Userservices.AddUser(user);
           Assert.False(Result);
       }
       //Get
       [Theory]
       [InlineData(-1)]
        public void GetUser_ShouldThrowArgumentNullException_WhenUserIdIsInValid(int Userid)
        {
            Assert.Throws<ArgumentException>(() => Userservices.GetUser(Userid));
        }
        
        // [Theory]
        // [InlineData(1)]
        // public void GetUser_ShouldReturnUser_WhenObjectIsPassed(int Userid)
        // {
        //     var user=UserMock.AddValidUser();
        //     Userdata.Setup(obj=>obj.GetUser(Userid)).Returns(user);
        //     var Result=Userservices.GetUser(Userid);
        //     Assert.NotEqual(null,Result);
        // }

        [Theory]
        [InlineData(1)]
       public void GetUser_ShouldThrowException_WhenExceptionRaised(int Userid)
       {
           Userdata.Setup(obj=>obj.GetUser(Userid)).Throws(new Exception());
           Assert.Throws<Exception>(() => Userservices.GetUser(Userid));
       }

       //Getall
       [Fact]
       public void GetAllUsers_ShouldReturnListofUsers_WhenMethodIsCalled()
       {
           var user=UserMock.GetValidateAllUsers();
           Userdata.Setup(obj=>obj.GetallUsers()).Returns(user);
           var Result=Userservices.GetallUsers();
           Assert.Equal(user.Count(),Result.Count());
       }
       [Fact]
       public void GetAllUsers_ShouldThrowException_WhenExceptionRaised()
       {
           
           Userdata.Setup(obj=>obj.GetallUsers()).Throws(new Exception());
           Assert.Throws<Exception>(() => Userservices.GetallUsers());         
       }

       //GetSpecificUser
    //    [Fact]
    //    public void GetSpecificUser_ShouldReturnObject_WhenMethodIsCalled()
    //    {
    //      var Result=Users ervices.GetSpecificUserDetails();
    //      Assert.
    //    }
        
        //Update
        [Theory]
        [InlineData(null)]
        public void UpdateUser_ShouldReturnArgumentNullException_WhenObjectIsNull(User user)
        {
           Assert.Throws<ArgumentNullException>(() => Userservices.UpdateUser(user));
        }
        [Fact]
        public void UpdateUser_ShouldReturnTrue_WhenObjectIsPassed()
        {
            User user=UserMock.UpdateValidUser();
            Userdata.Setup(obj=>obj.UpdateUser(user)).Returns(true);
            var Result=Userservices.UpdateUser(user);
            Assert.True(Result);
        }

        [Fact]
        public void UpdateUser_ShouldReturnFalse_WhenExceptionThrown()
        {
            User user=UserMock.UpdateValidUser();
            Userdata.Setup(obj=>obj.UpdateUser(user)).Returns(false);
            var Result=Userservices.UpdateUser(user);
            Assert.False(Result);
        }

        //Remove
        [Theory]
        [InlineData(0)]
        public void RemoveUser_ShouldThrowArgumentNullException_WhenIdIsNull(int Userid)
        {
            Assert.Throws<ArgumentException>(()=>Userservices.Disable(Userid));
        }

        [Theory]
        [InlineData(1)]
        public void RemoveUser_ShouldReturnTrue_WhenIdIsPassed(int Userid)
        {
            Userdata.Setup(obj=>obj.Disable(Userid)).Returns(true);
            var Result=Userservices.Disable(Userid);
            Assert.True(Result);
        }
        [Theory]
        [InlineData(1)]
        public void RemoveUser_ShouldReturnFalse_WhenExceptionIsThrown(int Userid)
       {
           Userdata.Setup(obj=>obj.Disable(Userid)).Throws(new Exception());
           var Result=Userservices.Disable(Userid);
           Assert.False(Result);
       }

       //ChangePassword

       [Theory]
       [InlineData("Brindham17@12","Brindha@123","BrindhaM@123",1)]
       public void ChangePassword_ShouldThrowValidationException_WhenPasswordIsNotEqual(string Oldpassword,string Newpassword,string Confirmpassword,int Userid)
       {
            Assert.Throws<ValidationException>(()=>Userservices.ChangePassword(Oldpassword,Newpassword,Confirmpassword,1));
       }

        [Theory]
       [InlineData("Brindham17@12","BrindhaMuruga@123","BrindhaMuruga@123",1)]
       public void ChangePassword_ShouldReturnTrue_WhenPasswordIsEqual(string Oldpassword,string Newpassword,string Confirmpassword,int Userid)
       {
            Userdata.Setup(obj=>obj.EditPassword(Oldpassword,Newpassword,Confirmpassword,1)).Returns(true);
            var Result=Userservices.ChangePassword(Oldpassword,Newpassword,Confirmpassword,1);
            Assert.True(Result);
       }

        [Theory]
       [InlineData("Brindham17@12","BrindhaM@123","BrindhaM@123",1)]
       public void ChangePassword_ShouldThrowException_WhenPasswordIsNotValid(string Oldpassword,string Newpassword,string Confirmpassword,int Userid)
       {
            Userdata.Setup(obj=>obj.EditPassword(Oldpassword,Newpassword,Confirmpassword,1)).Returns(false);
            var Result=Userservices.ChangePassword(Oldpassword,Newpassword,Confirmpassword,1);
            Assert.False(Result);
       }

    }
}