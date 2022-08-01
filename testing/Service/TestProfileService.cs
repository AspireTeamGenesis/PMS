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
    public class TestProfileService
    {
        private readonly ProfileService profileService;
        private Mock<IProfileData> profiledata=new Mock<IProfileData>();
        private Mock<ILogger<ProfileService>> logger =new Mock<ILogger<ProfileService>>();
        public TestProfileService()
        {
            profileService=new ProfileService(profiledata.Object,logger.Object);
        }

        //AddPersonalDetails
        [Theory]
        [InlineData(null)]
        public void AddPersonalDetails_ShouldThrowArgumentNullException_WhenObjectIsNull(PersonalDetails personaldetail)
        {
           Assert.Throws<ArgumentNullException>(()=>profileService.AddPersonalDetail(personaldetail));
        }
        [Fact]
        public void AddPersonalDetails_ShouldReturnTrue_WhenObjectIsPassed()
        {
            PersonalDetails personaldetail=ProfileMock.AddValidPersonalDetails();
            profiledata.Setup(obj=>obj.AddPersonalDetail(personaldetail)).Returns(true);
            var Result=profileService.AddPersonalDetail(personaldetail);
            Assert.True(Result);
        }
          [Fact]
        public void AddPersonalDetails_ShouldReturnFalse_WhenObjectIsPassed()
        {
            PersonalDetails personaldetail=ProfileMock.AddValidPersonalDetails();
            profiledata.Setup(obj=>obj.AddPersonalDetail(personaldetail)).Throws(new Exception());
            Assert.False(profileService.AddPersonalDetail(personaldetail));
            
        }

        //GetAllPersonalDetail
        [Fact]
        public void GetallPersonalDetail_ShouldReturnPersonalDetails_WhenMethodIsCalled()
        {
            var personalDetail=ProfileMock.GetValidateAllPersonalDetails();
            profiledata.Setup(obj=>obj.GetAllPersonalDetails()).Returns(personalDetail);
            var Result=profileService.GetAllPersonalDetails();
            Assert.Equal(personalDetail.Count(),Result.Count());

        }
        [Fact]
        public void GetAllPersonalDetail_ShouldThrowException_WhenMethodIsCalled()
        {
            profiledata.Setup(obj=>obj.GetAllPersonalDetails()).Throws(new Exception());
            Assert.Throws<Exception>(()=>profileService.GetAllPersonalDetails());
        }

        //GetPersonalDetail
        [Theory]
        [InlineData(-1)]
        public void GetPersonalDetailById_ShouldThrowArgumentNullException_WhenIdIsInvalid(int personalid)
        {
            Assert.Throws<ArgumentNullException>(()=>profileService.GetPersonalDetailsById(personalid));
        }
        [Theory]
        [InlineData(1)]
        public void GetPersonalDetailById_ShouldThrowException_WhenIdIsPassed(int personalid)
        {
            profiledata.Setup(obj=>obj.GetPersonalDetailsById(personalid)).Throws(new Exception());
            Assert.Throws<Exception>(()=>profileService.GetPersonalDetailsById(personalid));
        }

        //UpdatePersonalDetail
        [Theory]
        [InlineData(null)]
        public void UpdatePersonalDetail_ShouldThrowArgumentNullException_WhenObjectIsNull(PersonalDetails personaldetail)
        {
            Assert.Throws<ArgumentNullException>(()=>profileService.UpdatePersonalDetail(personaldetail));
        }
        // [Fact]
        // public void UpdatePersonalDetail_ShouldReturnTrue_WhenObjectIsPassed()
        // {
        //     PersonalDetails personalDetail=ProfileMock.GetValidPersonalDetails();
        //     profiledata.Setup(obj=>obj.UpdatePersonalDetail(personalDetail)).Returns(true);
        //     var Result=profileService.UpdatePersonalDetail(personalDetail);
        //     Assert.True(Result);
        // }
        // [Fact]
        // public void UpdatePersonalDetail_ShouldThrowException_WhenObjectIsPassed()
        // {
        //     PersonalDetails personaldetail=ProfileMock.GetValidPersonalDetails();
        //     profiledata.Setup(obj=>obj.UpdatePersonalDetail(personaldetail)).Throws(new Exception());
        //     Assert.Throws<Exception>(()=>profileService.UpdatePersonalDetail(personaldetail));
           
        // }
        
        //AddProjects
        [Theory]
        [InlineData(null)]
        public void AddProjects_ShouldReturnArgumentNullException_WhenObjectIsPassed(Projects projects)
        {
            Assert.Throws<ArgumentNullException>(()=>profileService.AddProjects(projects));
        }
        [Fact]
        public void AddProjects_ShouldReturnTrue_WhenObjectIsPassed()
        {
            Projects project=ProfileMock.AddValidProjectDetails();
            profiledata.Setup(obj=>obj.AddProjects(project)).Returns(true);
            var Result=profileService.AddProjects(project);
            Assert.True(Result);
        }
        [Fact]
        public void AddProjects_ShouldThrowException_WhenObjectIsPassed()
        {
            Projects project=new Projects();
            profiledata.Setup(obj=>obj.AddProjects(project)).Throws(new Exception());
            Assert.False(profileService.AddProjects(project));
        }

        //GetAllProjects
        [Fact]
        public void GetAllProjects_ShouldReturnListofProjects_WhenMethodIsCalled()
        {
            var project=ProfileMock.GetAllValidProjectDetails();
            profiledata.Setup(obj=>obj.GetallProjectDetails()).Returns(project);
            var Result=profileService.GetallProjectDetails();
            Assert.Equal(project.Count(),Result.Count());
        }
        [Fact]
        public void GetAllProjects_ShouldThrowException_WhenMethodIsCalled()
        {
            var project=ProfileMock.GetAllValidProjectDetails();
            profiledata.Setup(obj=>obj.GetallProjectDetails()).Throws(new Exception());
            Assert.Throws<Exception>(()=>profileService.GetallProjectDetails());
            
        }

        //GetProjects
        [Theory]
        [InlineData(-1)]
        public void GetProjectDetail_ShouldThrowArgumentNullException_WhenIdIsInvalid(int Projectid)
        {
            Assert.Throws<ArgumentNullException>(()=>profileService.GetProjectDetailsById(Projectid));
        }
        [Theory]
        [InlineData(1)]
        public void GetProjectDetail_ShouldThrowException_WhenIdIsPassed(int Projectid)
        {
            profiledata.Setup(obj=>obj.GetProjectDetailsById(Projectid)).Throws(new Exception());
            Assert.Throws<Exception>(()=>profileService.GetProjectDetailsById(Projectid));
        }

        //GetAllProjectDetailsByProfileId
        // [Theory]
        // [InlineData(1)]
        // public void GetAllProjectDetailsByProfileId_ShouldReturnListofProjects_WhenMethodIsCalled(int profileid)
        // {
        //     var projects=ProfileMock.GetAllValidProjectDetails();
        //     var Result=profileService.GetAllProjectDetailsByProfileId(profileid);
        //     Assert.Equal(Result.Count(),projects.Count());
        // }

        // UpdateProjects
         [Theory]
        [InlineData(null)]
        public void UpdateProjects_ShouldReturnArgumentNullException_WhenObjectIsPassed(Projects projects)
        {
            Assert.Throws<ArgumentNullException>(()=>profileService.UpdateProjects(projects));
        }

        // RemoveProjects
        [Theory]
        [InlineData(-1)]
        public void RemoveProject_ShouldReturnArgumentNullException_WhenIdIsInvalid(int Projectid)
        {
            Assert.Throws<ArgumentNullException>(()=>profileService.DisableProjectDetails(Projectid));
        }
        [Theory]
        [InlineData(1)]
        public void RemoveProject_ShouldReturnTrue_WhenIdIsValid(int Projectid)
        {
            profiledata.Setup(obj=>obj.DisableProjectDetails(Projectid)).Returns(true);
            var Result=profileService.DisableProjectDetails(Projectid);
            Assert.True(Result);
        }
        [Theory]
        [InlineData(1)]
        public void RemoveProject_ShouldThrowException_WhenIdIsValid(int Projectid)
        {
            profiledata.Setup(obj=>obj.DisableProjectDetails(Projectid)).Throws(new Exception());
            Assert.False(profileService.DisableProjectDetails(Projectid));
        }





    }
}