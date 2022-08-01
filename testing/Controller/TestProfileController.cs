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
using testing.Mock;
namespace testing.Controller
{
    public class TestProfileController
    {
        private readonly ProfileController profileControllers;
        private readonly Mock<IProfileService> profileService = new Mock<IProfileService>();
        private readonly Mock<ILogger<ProfileController>> logger = new Mock<ILogger<ProfileController>>();
        public TestProfileController()
        {
            profileControllers = new ProfileController(profileService.Object, logger.Object);
        }

        //AddProfile
        [Theory]
        [InlineData(null)]
        public void AddProfile_ShouldreturnStatuscode400_WhenProfileObjectIsNull(Profile profile)
        {
            var Result = profileControllers.AddProfile(profile) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddProfile_ShouldreturnStatuscode200_WhenProfileObjectIsPassed()
        {

            Profile profile = ProfileMock.AddValidProfile();
            profileService.Setup(obj => obj.AddProfile(profile)).Returns(true);
            var Result = profileControllers.AddProfile(profile) as ObjectResult;//act
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void AddProfile_ShouldreturnStatuscode500_WhenProfileObjectIsPassed()
        {

            Profile profile = ProfileMock.AddValidProfile();
            profileService.Setup(obj => obj.AddProfile(profile)).Returns(false);
            var Result = profileControllers.AddProfile(profile) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //Exception
        [Fact]
        public void AddProfile_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
        {

            Profile profile = ProfileMock.AddValidProfile();
            profileService.Setup(obj => obj.AddProfile(profile)).Throws(new ValidationException());
            var Result = profileControllers.AddProfile(profile) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddProfile_ShouldreturnStatuscode400_WhenArgumentNullExceptionIsThrown()
        {

            Profile profile = ProfileMock.AddValidProfile();
            profileService.Setup(obj => obj.AddProfile(profile)).Throws(new ArgumentNullException());
            var Result = profileControllers.AddProfile(profile) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddProfile_ShouldreturnStatuscode500_WhenExceptionIsThrown()
        {

            Profile profile = ProfileMock.AddValidProfile();
            profileService.Setup(obj => obj.AddProfile(profile)).Throws(new Exception());//Arrange
            var Result = profileControllers.AddProfile(profile) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }

        //AddPersonalDetails
        [Theory]
        [InlineData(null)]
        public void AddPersonalDetail_ShouldreturnStatuscode400_WhenPersonalDetailsObjectIsNull(PersonalDetails personalDetails)
        {
            var Result = profileControllers.AddPersonalDetail(personalDetails) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddPersonalDetail_ShouldreturnStatuscode200_WhenPersonalDetailsObjectIsPassed()
        {

            PersonalDetails personalDetails = ProfileMock.AddValidPersonalDetails();
            profileService.Setup(obj => obj.AddPersonalDetail(personalDetails)).Returns(true);
            var Result = profileControllers.AddPersonalDetail(personalDetails) as ObjectResult;//act
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void AddPersonalDetail_ShouldreturnStatuscode500_WhenPersonalDetailsObjectIsPassed()
        {

            PersonalDetails personalDetails = ProfileMock.AddValidPersonalDetails();
            profileService.Setup(obj => obj.AddPersonalDetail(personalDetails)).Returns(false);
            var Result = profileControllers.AddPersonalDetail(personalDetails) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //Exception
        [Fact]
        public void AddPersonalDetail_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
        {

            PersonalDetails personalDetails = ProfileMock.AddValidPersonalDetails();
            profileService.Setup(obj => obj.AddPersonalDetail(personalDetails)).Throws(new ValidationException());
            var Result = profileControllers.AddPersonalDetail(personalDetails) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddPersonalDetail_ShouldreturnStatuscode400_WhenArggumentNullExceptionIsThrown()
        {

            PersonalDetails personalDetails = ProfileMock.AddValidPersonalDetails();
            profileService.Setup(obj => obj.AddPersonalDetail(personalDetails)).Throws(new ArgumentNullException());
            var Result = profileControllers.AddPersonalDetail(personalDetails) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddPersonalDetail_ShouldreturnStatuscode500_WhenExceptionIsThrown()
        {

            PersonalDetails personalDetails = ProfileMock.AddValidPersonalDetails();
            profileService.Setup(obj => obj.AddPersonalDetail(personalDetails)).Throws(new Exception());//Arrange
            var Result = profileControllers.AddPersonalDetail(personalDetails) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //GetAllPersonalDetails
        [Fact]
        public void GetAllPersonalDetails_ShouldReturnGetAllPersonalDetails_WhenMethodIsCalled()
        {
            var personaldetails = ProfileMock.GetValidateAllPersonalDetails();
            profileService.Setup(obj => obj.GetAllPersonalDetails()).Returns(personaldetails);
            var Result = profileControllers.GetallPersonalDetails() as ObjectResult;
            Assert.Equal(personaldetails, Result?.Value);

        }
        //Exception
        [Fact]
        public void GetAllPersonalDetails_ShouldReturnStatuscode500_WhenExceptionIsThrown()
        {
            var personaldetails = ProfileMock.GetValidateAllPersonalDetails();
            profileService.Setup(obj => obj.GetAllPersonalDetails()).Throws(new Exception());
            var Result = profileControllers.GetallPersonalDetails() as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);

        }
        //GetPersonalDetailsById
        [Theory]
        [InlineData(-1)]
        public void GetPersonalDetailsById_ShouldReturnStatusCode400_WhenIdIsPassed(int Personalid)
        {
            var Result = profileControllers.GetPersonalDetailsById(Personalid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(001)]
        public void GetPersonalDetailsById_ShouldReturnStatusCode200_WhenIdIsPassed(int Personalid)
        {
            profileService.Setup(obj => obj.GetPersonalDetailsById(Personalid)).Returns(true);
            var Result = profileControllers.GetPersonalDetailsById(Personalid) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);

        }
        //Exception
        [Theory]
        [InlineData(1)]
        public void GetPersonalDetailsById_ShouldreturnStatuscode400_WhenArgumentNullExceptionIsThrown(int Personalid)
        {
            profileService.Setup(obj => obj.GetPersonalDetailsById(Personalid)).Throws(new ArgumentNullException());
            var Result = profileControllers.GetPersonalDetailsById(Personalid) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void GetPersonalDetailsById_ShouldReturnStatusCode500_WhenExceptionIsThrown(int Personalid)
        {
            profileService.Setup(obj => obj.GetPersonalDetailsById(Personalid)).Throws(new Exception());
            var Result = profileControllers.GetPersonalDetailsById(Personalid) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void GetPersonalDetailsByProfileId_ShouldReturnStatusCode400_WhenIdIsPassed(int Profileid)
        {
            var Result = profileControllers.GetPersonalDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(001)]
        public void GetPersonalDetailsByProfileId_ShouldReturnStatusCode200_WhenIdIsPassed(int Profileid)
        {
            profileService.Setup(obj => obj.GetPersonalDetailsByProfileId(Profileid)).Returns(true);
            var Result = profileControllers.GetPersonalDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);

        }
        //Exception
        [Theory]
        [InlineData(1)]
        public void GetPersonalDetailsByProfileId_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int Profileid)
        {
            profileService.Setup(obj => obj.GetPersonalDetailsByProfileId(Profileid)).Throws(new ArgumentNullException());
            var Result = profileControllers.GetPersonalDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);

        }
        [Theory]
        [InlineData(1)]
        public void GetPersonalDetailsByProfileId_ShouldReturnStatusCode500_WhenExceptionIsThrown(int Profileid)
        {
            profileService.Setup(obj => obj.GetPersonalDetailsByProfileId(Profileid)).Throws(new Exception());
            var Result = profileControllers.GetPersonalDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);

        }
        //UpdatePersonalDetails
        [Fact]
        public void UpdatePersonalDetail_ShouldReturnStatusCode200_WhenPersonalDetailIsValid()
        {
            PersonalDetails personalDetails = ProfileMock.GetValidPersonalDetails();
            profileService.Setup(obj => obj.UpdatePersonalDetail(personalDetails)).Returns(true);
            var Result = profileControllers.UpdatePersonalDetail(personalDetails) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void UpdatePersonalDetail_ShouldReturnStatusCode500_WhenPersonalDetailIsInValid()
        {
            PersonalDetails personalDetails = ProfileMock.GetValidPersonalDetails();
            profileService.Setup(obj => obj.UpdatePersonalDetail(personalDetails)).Returns(false);
            var Result = profileControllers.UpdatePersonalDetail(personalDetails) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Fact]
        public void UpdatePersonalDetail_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown()
        {
            PersonalDetails personalDetails = ProfileMock.GetValidPersonalDetails();
            profileService.Setup(obj => obj.UpdatePersonalDetail(personalDetails)).Throws(new ArgumentNullException());
            var Result = profileControllers.UpdatePersonalDetail(personalDetails) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void UpdatePersonalDetail_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            PersonalDetails personalDetails = ProfileMock.GetValidPersonalDetails();
            profileService.Setup(obj => obj.UpdatePersonalDetail(personalDetails)).Throws(new Exception());
            var Result = profileControllers.UpdatePersonalDetail(personalDetails) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Fact]
        public void UpdatePersonalDetail_ShouldReturnStatusCode400_WhenPersonalDetailIsInValid()
        {
            PersonalDetails personalDetails = null;
            profileService.Setup(obj => obj.UpdatePersonalDetail(personalDetails)).Returns(false);
            var Result = profileControllers.UpdatePersonalDetail(personalDetails) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        //DisablePersonalDetails
        [Theory]
        [InlineData(1)]

        public void DisablePersonalDetails_ShouldReturnStatusCode200_WhenIdIsPassed(int PersonalDetailsId)
        {
            profileService.Setup(obj => obj.DisablePersonalDetails(PersonalDetailsId)).Returns(true);
            var Result = profileControllers.DisablePersonalDetails(PersonalDetailsId) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void DisablePersonalDetails_ShouldReturnStatusCode400_WhenExceptionIsThrown(int PersonalDetailsId)
        {
            var Result = profileControllers.DisablePersonalDetails(PersonalDetailsId) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]

        public void DisablePersonalDetails_ShouldReturnStatusCode500_WhenIdIsPassed(int PersonalDetailsId)
        {
            profileService.Setup(obj => obj.DisablePersonalDetails(PersonalDetailsId)).Returns(false);
            var Result = profileControllers.DisablePersonalDetails(PersonalDetailsId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisablePersonalDetails_ShouldReturnStatusCode500_WhenExceptionIsThrown(int PersonalDetailsId)
        {
            profileService.Setup(obj => obj.DisablePersonalDetails(PersonalDetailsId)).Throws(new Exception());
            var Result = profileControllers.DisablePersonalDetails(PersonalDetailsId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisablePersonalDetails_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int PersonalDetailsId)
        {
            profileService.Setup(obj => obj.DisablePersonalDetails(PersonalDetailsId)).Throws(new ArgumentNullException());
            var Result = profileControllers.DisablePersonalDetails(PersonalDetailsId) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }

        //AddEducationDetails
        [Theory]
        [InlineData(null)]
        public void AddEducation_ShouldreturnStatuscode400_WhenEducationObjectIsNull(Education education)
        {
            var Result = profileControllers.AddEducation(education) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddEducation_ShouldreturnStatuscode200_WhenEducationObjectIsPassed()
        {

            Education education = ProfileMock.AddValidEducationalDetails();
            profileService.Setup(obj => obj.AddEducation(education)).Returns(true);
            var Result = profileControllers.AddEducation(education) as ObjectResult;//act
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void AddEducation_ShouldreturnStatuscode500_WhenEducationObjectIsPassed()
        {

            Education education = ProfileMock.AddValidEducationalDetails();
            profileService.Setup(obj => obj.AddEducation(education)).Returns(false);
            var Result = profileControllers.AddEducation(education) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //Exception
        [Fact]
        public void AddEducation_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
        {

            Education education = ProfileMock.AddValidEducationalDetails();
            profileService.Setup(obj => obj.AddEducation(education)).Throws(new ValidationException());
            var Result = profileControllers.AddEducation(education) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddEducation_ShouldreturnStatuscode400_WhenArgumentNullExceptionIsThrown()
        {

            Education education = ProfileMock.AddValidEducationalDetails();
            profileService.Setup(obj => obj.AddEducation(education)).Throws(new ArgumentNullException());
            var Result = profileControllers.AddEducation(education) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddEducation_ShouldreturnStatuscode500_WhenExceptionIsThrown()
        {

            Education education = ProfileMock.AddValidEducationalDetails();
            profileService.Setup(obj => obj.AddEducation(education)).Throws(new Exception());//Arrange
            var Result = profileControllers.AddEducation(education) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //GetAllEducationDetails
        [Fact]
        public void GetallEducationDetails_ShouldReturnGetAllEducationDetails_WhenMethodIsCalled()
        {
            var education = ProfileMock.GetAllValidEducationDetails();
            profileService.Setup(obj => obj.GetallEducationDetails()).Returns(education);
            var Result = profileControllers.GetallEducationDetails() as ObjectResult;
            Assert.Equal(education, Result?.Value);

        }
        //Exception
        [Fact]
        public void GetallEducationDetails_ShouldReturnStatuscode500_WhenExceptionIsThrown()
        {
            var education = ProfileMock.GetAllValidEducationDetails();
            profileService.Setup(obj => obj.GetallEducationDetails()).Throws(new Exception());
            var Result = profileControllers.GetallEducationDetails() as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);

        }
        [Theory]
        [InlineData(-1)]
        public void GetEducationDetailsById_ShouldReturnStatusCode400_WhenIdIsPassed(int Educationid)
        {
            var Result = profileControllers.GetEducationDetailsById(Educationid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(001)]
        public void GetEducationDetailsById_ShouldReturnStatusCode200_WhenIdIsPassed(int Educationid)
        {
            profileService.Setup(obj => obj.GetEducationDetailsById(Educationid)).Returns(true);
            var Result = profileControllers.GetEducationDetailsById(Educationid) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);

        }
        //Exception
        [Theory]
        [InlineData(1)]
        public void GetEducationDetailsById_ShouldReturnStatusCode400_WhenArumentNullExceptionIsThrown(int Educationid)
        {
            profileService.Setup(obj => obj.GetEducationDetailsById(Educationid)).Throws(new ArgumentNullException());
            var Result = profileControllers.GetEducationDetailsById(Educationid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void GetEducationDetailsById_ShouldReturnStatusCode500_WhenExceptionIsThrown(int Educationid)
        {
            profileService.Setup(obj => obj.GetEducationDetailsById(Educationid)).Throws(new Exception());
            var Result = profileControllers.GetEducationDetailsById(Educationid) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void GetAllEducationDetailsByProfileId_ShouldReturnStatusCode400_WhenIdIsPassed(int Profileid)
        {
            var Result = profileControllers.GetAllEducationDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(001)]
        public void GetAllEducationDetailsByProfileId_ShouldReturnStatusCode200_WhenIdIsPassed(int Profileid)
        {
            profileService.Setup(obj => obj.GetAllEducationDetailsByProfileId(Profileid)).Returns(ProfileMock.GetAllValidEducationDetails());
            var Result = profileControllers.GetAllEducationDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);

        }
        //Exception
        [Theory]
        [InlineData(1)]
        public void GetAllEducationDetailsByProfileId_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int Profileid)
        {
            profileService.Setup(obj => obj.GetAllEducationDetailsByProfileId(Profileid)).Throws(new ArgumentNullException());
            var Result = profileControllers.GetAllEducationDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);

        }
     
        [Theory]
        [InlineData(1)]
        public void GetAllEducationDetailsByProfileId_ShouldReturnStatusCode500_WhenExceptionIsThrown(int Profileid)
        {
            profileService.Setup(obj => obj.GetAllEducationDetailsByProfileId(Profileid)).Throws(new Exception());
            var Result = profileControllers.GetAllEducationDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);

        }
        //UpdateEducationDetails
        [Fact]
        public void UpdateEducation_ShouldReturnStatusCode200_WhenEducationDetailIsValid()
        {
            Education education = ProfileMock.GetValidEducationDetails();
            profileService.Setup(obj => obj.UpdateEducation(education)).Returns(true);
            var Result = profileControllers.UpdateEducation(education) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void UpdateEducation_ShouldReturnStatusCode500_WhenEducationDetailIsInValid()
        {
            Education education = ProfileMock.GetValidEducationDetails();
            profileService.Setup(obj => obj.UpdateEducation(education)).Returns(false);
            var Result = profileControllers.UpdateEducation(education) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Fact]
        public void UpdateEducation_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown()
        {
            Education education = ProfileMock.GetValidEducationDetails();
            profileService.Setup(obj => obj.UpdateEducation(education)).Throws(new ArgumentNullException());
            var Result = profileControllers.UpdateEducation(education) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void UpdateEducation_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            Education education = ProfileMock.GetValidEducationDetails();
            profileService.Setup(obj => obj.UpdateEducation(education)).Throws(new Exception());
            var Result = profileControllers.UpdateEducation(education) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Fact]
        public void UpdateEducation_ShouldReturnStatusCode400_WhenEducationDetailIsInValid()
        {
            Education education = null;
            profileService.Setup(obj => obj.UpdateEducation(education)).Returns(false);
            var Result = profileControllers.UpdateEducation(education) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        //DisableEducationDetails
        [Theory]
        [InlineData(1)]

        public void DisableEducationalDetails_ShouldReturnStatusCode200_WhenIdIsPassed(int EducationId)
        {
            profileService.Setup(obj => obj.DisableEducationalDetails(EducationId)).Returns(true);
            var Result = profileControllers.DisableEducationalDetails(EducationId) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void DisableEducationalDetails_ShouldReturnStatusCode400_WhenExceptionIsThrown(int EducationId)
        {
            var Result = profileControllers.DisableEducationalDetails(EducationId) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]

        public void DisableEducationalDetails_ShouldReturnStatusCode500_WhenIdIsPassed(int EducationId)
        {
            profileService.Setup(obj => obj.DisableEducationalDetails(EducationId)).Returns(false);
            var Result = profileControllers.DisableEducationalDetails(EducationId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableEducationalDetails_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int EducationId)
        {
            profileService.Setup(obj => obj.DisableEducationalDetails(EducationId)).Throws(new ArgumentNullException());
            var Result = profileControllers.DisableEducationalDetails(EducationId) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableEducationalDetails_ShouldReturnStatusCode500_WhenExceptionIsThrown(int EducationId)
        {
            profileService.Setup(obj => obj.DisableEducationalDetails(EducationId)).Throws(new Exception());
            var Result = profileControllers.DisableEducationalDetails(EducationId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }

        //AddProjectDetails
        [Theory]
        [InlineData(null)]
        public void AddProjects_ShouldreturnStatuscode400_WhenProjectObjectIsNull(Projects projects)
        {
            var Result = profileControllers.AddProjects(projects) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddProjects_ShouldreturnStatuscode200_WhenProjectObjectIsPassed()
        {
            Projects projects = ProfileMock.AddValidProjectDetails();
            profileService.Setup(obj => obj.AddProjects(projects)).Returns(true);
            var Result = profileControllers.AddProjects(projects) as ObjectResult;//act
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void AddProjects_ShouldreturnStatuscode500_WhenProjectObjectIsPassed()
        {
            Projects projects = ProfileMock.AddValidProjectDetails();
            profileService.Setup(obj => obj.AddProjects(projects)).Returns(false);
            var Result = profileControllers.AddProjects(projects) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //Exception
        [Fact]
        public void AddProjects_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
        {
            Projects projects = ProfileMock.AddValidProjectDetails();
            profileService.Setup(obj => obj.AddProjects(projects)).Throws(new ValidationException());
            var Result = profileControllers.AddProjects(projects) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddProjects_ShouldreturnStatuscode400_WhenArgumentNullExceptionIsThrown()
        {
            Projects projects = ProfileMock.AddValidProjectDetails();
            profileService.Setup(obj => obj.AddProjects(projects)).Throws(new ArgumentNullException());
            var Result = profileControllers.AddProjects(projects) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddProjects_ShouldreturnStatuscode500_WhenExceptionIsThrown()
        {

            Projects projects = ProfileMock.AddValidProjectDetails();
            profileService.Setup(obj => obj.AddProjects(projects)).Throws(new Exception());//Arrange
            var Result = profileControllers.AddProjects(projects) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //GetAllProjectDetails
        [Fact]
        public void GetallProjectDetails_ShouldReturnGetAllProjectDetails_WhenMethodIsCalled()
        {
            var project = ProfileMock.GetAllValidProjectDetails();
            profileService.Setup(obj => obj.GetallProjectDetails()).Returns(project);
            var Result = profileControllers.GetallProjectDetails() as ObjectResult;
            Assert.Equal(project, Result?.Value);

        }
        //Exception
        [Fact]
        public void GetallProjectDetails_ShouldReturnStatuscode500_WhenExceptionIsThrown()
        {
            var project = ProfileMock.GetAllValidProjectDetails();
            profileService.Setup(obj => obj.GetallProjectDetails()).Throws(new Exception());
            var Result = profileControllers.GetallProjectDetails() as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);

        }
        [Theory]
        [InlineData(-1)]
        public void GetProjectDetailsById_ShouldReturnStatusCode400_WhenIdIsPassed(int Projectid)
        {
            var Result = profileControllers.GetProjectDetailsById(Projectid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(001)]
        public void GetProjectDetailsById_ShouldReturnStatusCode200_WhenIdIsPassed(int Projectid)
        {
            profileService.Setup(obj => obj.GetProjectDetailsById(Projectid)).Returns(true);
            var Result = profileControllers.GetProjectDetailsById(Projectid) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);

        }
        //Exception
        [Theory]
        [InlineData(1)]
        public void GetProjectDetailsById_ShouldReturnStatusCode400_WhenArguentNullExceptionIsThrown(int Projectid)
        {
            profileService.Setup(obj => obj.GetProjectDetailsById(Projectid)).Throws(new ArgumentNullException());
            var Result = profileControllers.GetProjectDetailsById(Projectid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void GetProjectDetailsById_ShouldReturnStatusCode500_WhenExceptionIsThrown(int Projectid)
        {
            profileService.Setup(obj => obj.GetProjectDetailsById(Projectid)).Throws(new Exception());
            var Result = profileControllers.GetProjectDetailsById(Projectid) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void GetAllProjectDetailsByProfileId_ShouldReturnStatusCode400_WhenIdIsPassed(int Profileid)
        {
            var Result = profileControllers.GetAllProjectDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(001)]
        public void GetAllProjectDetailsByProfileId_ShouldReturnStatusCode200_WhenIdIsPassed(int Profileid)
        {
            profileService.Setup(obj => obj.GetAllProjectDetailsByProfileId(Profileid)).Returns(ProfileMock.GetAllValidProjectDetails());
            var Result = profileControllers.GetAllProjectDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);

        }
        //Exception
        [Theory]
        [InlineData(1)]
        public void GetAllProjectDetailsByProfileId_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int Profileid)
        {
            profileService.Setup(obj => obj.GetAllProjectDetailsByProfileId(Profileid)).Throws(new ArgumentNullException());
            var Result = profileControllers.GetAllProjectDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);

        }
        [Theory]
        [InlineData(1)]
        public void GetAllProjectDetailsByProfileId_ShouldReturnStatusCode500_WhenExceptionIsThrown(int Profileid)
        {
            profileService.Setup(obj => obj.GetAllProjectDetailsByProfileId(Profileid)).Throws(new Exception());
            var Result = profileControllers.GetAllProjectDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);

        }
        //UpdateProjectDetails
        [Fact]
        public void UpdateProjects_ShouldReturnStatusCode200_WhenProjectDetailIsValid()
        {
            Projects projects= ProfileMock.GetValidProjectDetails();
            profileService.Setup(obj => obj.UpdateProjects(projects)).Returns(true);
            var Result = profileControllers.UpdateProjects(projects) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void UpdateProjects_ShouldReturnStatusCode500_WhenProjectDetailIsInValid()
        {
            Projects projects= ProfileMock.GetValidProjectDetails();
            profileService.Setup(obj => obj.UpdateProjects(projects)).Returns(false);
            var Result = profileControllers.UpdateProjects(projects) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Fact]
        public void UpdateProjects_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown()
        {
            Projects projects = ProfileMock.GetValidProjectDetails();
            profileService.Setup(obj => obj.UpdateProjects(projects)).Throws(new ArgumentNullException());
            var Result = profileControllers.UpdateProjects(projects) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void UpdateProjects_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            Projects projects = ProfileMock.GetValidProjectDetails();
            profileService.Setup(obj => obj.UpdateProjects(projects)).Throws(new Exception());
            var Result = profileControllers.UpdateProjects(projects) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Fact]
        public void UpdateProjects_ShouldReturnStatusCode400_WhenProjectDetailIsInValid()
        {
            Projects projects = null;
            profileService.Setup(obj => obj.UpdateProjects(projects)).Returns(false);
            var Result = profileControllers.UpdateProjects(projects) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        //DisableProjectDetails
        [Theory]
        [InlineData(1)]

        public void DisableProjectDetails_ShouldReturnStatusCode200_WhenIdIsPassed(int ProjectsId)
        {
            profileService.Setup(obj => obj.DisableProjectDetails(ProjectsId)).Returns(true);
            var Result = profileControllers.DisableProjectDetails(ProjectsId) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void DisableProjectDetails_ShouldReturnStatusCode400_WhenExceptionIsThrown(int ProjectsId)
        {
            var Result = profileControllers.DisableProjectDetails(ProjectsId) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]

        public void DisableProjectDetails_ShouldReturnStatusCode500_WhenIdIsPassed(int ProjectsId)
        {
            profileService.Setup(obj => obj.DisableProjectDetails(ProjectsId)).Returns(false);
            var Result = profileControllers.DisableProjectDetails(ProjectsId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableProjectDetails_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int ProjectsId)
        {
            profileService.Setup(obj => obj.DisableProjectDetails(ProjectsId)).Throws(new ArgumentNullException());
            var Result = profileControllers.DisableProjectDetails(ProjectsId) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableProjectDetails_ShouldReturnStatusCode500_WhenExceptionIsThrown(int ProjectsId)
        {
            profileService.Setup(obj => obj.DisableProjectDetails(ProjectsId)).Throws(new Exception());
            var Result = profileControllers.DisableProjectDetails(ProjectsId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }

        //AddSkillDetails
        [Theory]
        [InlineData(null)]
        public void AddSkills_ShouldreturnStatuscode400_WhenSkillObjectIsNull(Skills skills)
        {
            var Result = profileControllers.AddSkills(skills) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddSkills_ShouldreturnStatuscode200_WhenSkillObjectIsPassed()
        {
            Skills skills = ProfileMock.AddValidSkillDetails();
            profileService.Setup(obj => obj.AddSkills(skills)).Returns(true);
            var Result = profileControllers.AddSkills(skills) as ObjectResult;//act
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void AddSkills_ShouldreturnStatuscode500_WhenSkillObjectIsPassed()
        {
            Skills skills = ProfileMock.AddValidSkillDetails();
            profileService.Setup(obj => obj.AddSkills(skills)).Returns(false);
            var Result = profileControllers.AddSkills(skills) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //Exception
        [Fact]
        public void AddSkills_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
        {
            Skills skills = ProfileMock.AddValidSkillDetails();
            profileService.Setup(obj => obj.AddSkills(skills)).Throws(new ValidationException());
            var Result = profileControllers.AddSkills(skills) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddSkills_ShouldreturnStatuscode400_WhenArgumentNullExceptionIsThrown()
        {
            Skills skills = ProfileMock.AddValidSkillDetails();
            profileService.Setup(obj => obj.AddSkills(skills)).Throws(new ArgumentNullException());
            var Result = profileControllers.AddSkills(skills) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddSkills_ShouldreturnStatuscode500_WhenExceptionIsThrown()
        {

            Skills skills = ProfileMock.AddValidSkillDetails();
            profileService.Setup(obj => obj.AddSkills(skills)).Throws(new Exception());//Arrange
            var Result = profileControllers.AddSkills(skills) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //GetAllSkillDetails
        [Fact]
        public void GetallSkillDetails_ShouldReturnGetAllSkillDetails_WhenMethodIsCalled()
        {
            var skill = ProfileMock.GetAllValidSkillDetails();
            profileService.Setup(obj => obj.GetallSkillDetails()).Returns(skill);
            var Result = profileControllers.GetallSkillDetails() as ObjectResult;
            Assert.Equal(skill, Result?.Value);

        }
        //Exception
        [Fact]
        public void GetallSkillDetails_ShouldReturnStatuscode500_WhenExceptionIsThrown()
        {
            var skill = ProfileMock.GetAllValidSkillDetails();
            profileService.Setup(obj => obj.GetallSkillDetails()).Throws(new Exception());
            var Result = profileControllers.GetallSkillDetails() as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);

        }
        [Theory]
        [InlineData(-1)]
        public void GetSkillDetailsById_ShouldReturnStatusCode400_WhenIdIsPassed(int Skillid)
        {
            var Result = profileControllers.GetSkillDetailsById(Skillid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(001)]
        public void GetSkillDetailsById_ShouldReturnStatusCode200_WhenIdIsPassed(int Skillid)
        {
            profileService.Setup(obj => obj.GetSkillDetailsById(Skillid)).Returns(true);
            var Result = profileControllers.GetSkillDetailsById(Skillid) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);

        }
        //Exception
        [Theory]
        [InlineData(1)]
        public void GetSkillDetailsById_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int Skillid)
        {
            profileService.Setup(obj => obj.GetSkillDetailsById(Skillid)).Throws(new ArgumentNullException());
            var Result = profileControllers.GetSkillDetailsById(Skillid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void GetSkillDetailsById_ShouldReturnStatusCode500_WhenExceptionIsThrown(int Skillid)
        {
            profileService.Setup(obj => obj.GetSkillDetailsById(Skillid)).Throws(new Exception());
            var Result = profileControllers.GetSkillDetailsById(Skillid) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void GetAllSkillDetailsByProfileId_ShouldReturnStatusCode400_WhenIdIsPassed(int Profileid)
        {
            var Result = profileControllers.GetAllSkillDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(001)]
        public void GetAllSkillDetailsByProfileId_ShouldReturnStatusCode200_WhenIdIsPassed(int Profileid)
        {
            profileService.Setup(obj => obj.GetAllSkillDetailsByProfileId(Profileid)).Returns(ProfileMock.GetAllValidSkillDetails());
            var Result = profileControllers.GetAllSkillDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);

        }
        //Exception
        [Theory]
        [InlineData(1)]
        public void GetAllSkillDetailsByProfileId_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int Profileid)
        {
            profileService.Setup(obj => obj.GetAllSkillDetailsByProfileId(Profileid)).Throws(new ArgumentNullException());
            var Result = profileControllers.GetAllSkillDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);

        }
        [Theory]
        [InlineData(1)]
        public void GetAllSkillDetailsByProfileId_ShouldReturnStatusCode500_WhenExceptionIsThrown(int Profileid)
        {
            profileService.Setup(obj => obj.GetAllSkillDetailsByProfileId(Profileid)).Throws(new Exception());
            var Result = profileControllers.GetAllSkillDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);

        }
        //UpdateSkillDetails
        [Fact]
        public void UpdateSkills_ShouldReturnStatusCode200_WhenSkillDetailIsValid()
        {
            Skills skills= ProfileMock.GetValidSkillDetails();
            profileService.Setup(obj => obj.UpdateSkills(skills)).Returns(true);
            var Result = profileControllers.UpdateSkills(skills) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void UpdateSkills_ShouldReturnStatusCode500_WhenSkillDetailIsInValid()
        {
            Skills skills= ProfileMock.GetValidSkillDetails();
            profileService.Setup(obj => obj.UpdateSkills(skills)).Returns(false);
            var Result = profileControllers.UpdateSkills(skills) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Fact]
        public void UpdateSkills_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown()
        {
            Skills skills= ProfileMock.GetValidSkillDetails();
            profileService.Setup(obj => obj.UpdateSkills(skills)).Throws(new ArgumentNullException());
            var Result = profileControllers.UpdateSkills(skills) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void UpdateSkills_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        {
            Skills skills= ProfileMock.GetValidSkillDetails();
            profileService.Setup(obj => obj.UpdateSkills(skills)).Throws(new Exception());
            var Result = profileControllers.UpdateSkills(skills) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Fact]
        public void UpdateSkills_ShouldReturnStatusCode400_WhenSkillDetailIsInValid()
        {
            Skills skills = null;
            profileService.Setup(obj => obj.UpdateSkills(skills)).Returns(false);
            var Result = profileControllers.UpdateSkills(skills) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        //DisableSkillDetails
        [Theory]
        [InlineData(1)]

        public void DisableSkillDetails_ShouldReturnStatusCode200_WhenIdIsPassed(int SkillId)
        {
            profileService.Setup(obj => obj.DisableSkillDetails(SkillId)).Returns(true);
            var Result = profileControllers.DisableSkillDetails(SkillId) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void DisableSkillDetails_ShouldReturnStatusCode400_WhenExceptionIsThrown(int SkillId)
        {
            var Result = profileControllers.DisableSkillDetails(SkillId) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]

        public void DisableSkillDetails_ShouldReturnStatusCode500_WhenIdIsPassed(int SkillId)
        {
            profileService.Setup(obj => obj.DisableSkillDetails(SkillId)).Returns(false);
            var Result = profileControllers.DisableSkillDetails(SkillId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableSkillDetails_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int SkillId)
        {
            profileService.Setup(obj => obj.DisableSkillDetails(SkillId)).Throws(new ArgumentNullException());
            var Result = profileControllers.DisableSkillDetails(SkillId) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableSkillDetails_ShouldReturnStatusCode500_WhenExceptionIsThrown(int SkillId)
        {
            profileService.Setup(obj => obj.DisableSkillDetails(SkillId)).Throws(new Exception());
            var Result = profileControllers.DisableSkillDetails(SkillId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }

        //AddAchievementDetails
        [Theory]
        [InlineData(null)]
        public void AddAchievement_ShouldreturnStatuscode400_WhenAchievementObjectIsNull(Achievements achievements)
        {
            var Result = profileControllers.AddAchievement(achievements) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddAchievement_ShouldreturnStatuscode200_WhenAchievementObjectIsPassed()
        {
            Achievements achievements = ProfileMock.AddValidAchievementDetails();
            profileService.Setup(obj => obj.AddAchievements(achievements)).Returns(true);
            var Result = profileControllers.AddAchievement(achievements) as ObjectResult;//act
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void AddAchievement_ShouldreturnStatuscode500_WhenAchievementObjectIsPassed()
        {
            Achievements achievements = ProfileMock.AddValidAchievementDetails();
            profileService.Setup(obj => obj.AddAchievements(achievements)).Returns(false);
            var Result = profileControllers.AddAchievement(achievements) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //Exception
        [Fact]
        public void AddAchievement_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
        {
            Achievements achievements = ProfileMock.AddValidAchievementDetails();
            profileService.Setup(obj => obj.AddAchievements(achievements)).Throws(new ValidationException());
            var Result = profileControllers.AddAchievement(achievements) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddAchievement_ShouldreturnStatuscode400_WhenArgumentNullExceptionIsThrown()
        {
            Achievements achievements = ProfileMock.AddValidAchievementDetails();
            profileService.Setup(obj => obj.AddAchievements(achievements)).Throws(new ArgumentNullException());
            var Result = profileControllers.AddAchievement(achievements) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddAchievement_ShouldreturnStatuscode500_WhenExceptionIsThrown()
        {
            Achievements achievements = ProfileMock.AddValidAchievementDetails();
            profileService.Setup(obj => obj.AddAchievements(achievements)).Throws(new Exception());//Arrange
            var Result = profileControllers.AddAchievement(achievements) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //GetAllAchievementDetails
        [Fact]
        public void GetallAchievements_ShouldReturnGetAllAchievementDetails_WhenMethodIsCalled()
        {
            var achievement = ProfileMock.GetAllValidAchievementDetails();
            profileService.Setup(obj => obj.GetallAchievements()).Returns(achievement);
            var Result = profileControllers.GetallAchievements() as ObjectResult;
            Assert.Equal(achievement, Result?.Value);

        }
        //Exception
        [Fact]
        public void GetallAchievements_ShouldReturnStatuscode500_WhenExceptionIsThrown()
        {
            var achievement = ProfileMock.GetAllValidAchievementDetails();
            profileService.Setup(obj => obj.GetallAchievements()).Throws(new Exception());
            var Result = profileControllers.GetallAchievements() as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);

        }
        [Theory]
        [InlineData(-1)]
        public void GetAllAchievementDetailsByProfileId_ShouldReturnStatusCode400_WhenIdIsPassed(int Profileid)
        {
            var Result = profileControllers.GetAllAchievementDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(001)]
        public void GetAllAchievementDetailsByProfileId_ShouldReturnStatusCode200_WhenIdIsPassed(int Profileid)
        {
            profileService.Setup(obj => obj.GetAllAchievementDetailsByProfileId(Profileid)).Returns(ProfileMock.GetAllValidAchievementDetails());
            var Result = profileControllers.GetAllAchievementDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);

        }
        //Exception
        [Theory]
        [InlineData(1)]
        public void GetAllAchievementDetailsByProfileId_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int Profileid)
        {
            profileService.Setup(obj => obj.GetAllAchievementDetailsByProfileId(Profileid)).Throws(new ArgumentNullException());
            var Result = profileControllers.GetAllAchievementDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);

        }
        [Theory]
        [InlineData(1)]
        public void GetAllAchievementDetailsByProfileId_ShouldReturnStatusCode500_WhenExceptionIsThrown(int Profileid)
        {
            profileService.Setup(obj => obj.GetAllAchievementDetailsByProfileId(Profileid)).Throws(new Exception());
            var Result = profileControllers.GetAllAchievementDetailsByProfileId(Profileid) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);

        }
        //DisableAchievementDetails
        [Theory]
        [InlineData(1)]

        public void DisableAchievements_ShouldReturnStatusCode200_WhenIdIsPassed(int achievementId)
        {
            profileService.Setup(obj => obj.DisableAchievement(achievementId)).Returns(true);
            var Result = profileControllers.DisableAchievements(achievementId) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void DisableAchievements_ShouldReturnStatusCode400_WhenExceptionIsThrown(int achievementId)
        {
            var Result = profileControllers.DisableAchievements(achievementId) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]

        public void DisableAchievements_ShouldReturnStatusCode500_WhenIdIsPassed(int achievementId)
        {
            profileService.Setup(obj => obj.DisableAchievement(achievementId)).Returns(false);
            var Result = profileControllers.DisableAchievements(achievementId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableAchievements_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int achievementId)
        {
            profileService.Setup(obj => obj.DisableAchievement(achievementId)).Throws(new ArgumentNullException());
            var Result = profileControllers.DisableAchievements(achievementId) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableAchievements_ShouldReturnStatusCode500_WhenExceptionIsThrown(int achievementId)
        {
            profileService.Setup(obj => obj.DisableAchievement(achievementId)).Throws(new Exception());
            var Result = profileControllers.DisableAchievements(achievementId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }

        //AddBreakDurationDetails
        [Theory]
        [InlineData(null)]
        public void AddBreakDuration_ShouldreturnStatuscode400_WhenBreakDurationObjectIsNull(BreakDuration duration)
        {
            var Result = profileControllers.AddBreakDuration(duration) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddBreakDuration_ShouldreturnStatuscode200_WhenBreakDurationObjectIsPassed()
        {
            BreakDuration duration = ProfileMock.AddValidBreakDuration();
            profileService.Setup(obj => obj.AddBreakDuration(duration)).Returns(true);
            var Result = profileControllers.AddBreakDuration(duration) as ObjectResult;//act
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void AddBreakDuration_ShouldreturnStatuscode500_WhenBreakDurationObjectIsPassed()
        {
            BreakDuration duration = ProfileMock.AddValidBreakDuration();
            profileService.Setup(obj => obj.AddBreakDuration(duration)).Returns(false);
            var Result = profileControllers.AddBreakDuration(duration)  as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //Exception
        [Fact]
        public void AddBreakDuration_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
        {
            BreakDuration duration = ProfileMock.AddValidBreakDuration();
            profileService.Setup(obj => obj.AddBreakDuration(duration)).Throws(new ValidationException());
            var Result = profileControllers.AddBreakDuration(duration) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddBreakDuration_ShouldreturnStatuscode400_WhenArgumentNullExceptionIsThrown()
        {
            BreakDuration duration = ProfileMock.AddValidBreakDuration();
            profileService.Setup(obj => obj.AddBreakDuration(duration)).Throws(new ArgumentNullException());
            var Result = profileControllers.AddBreakDuration(duration) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddBreakDuration_ShouldreturnStatuscode500_WhenExceptionIsThrown()
        {
            BreakDuration duration = ProfileMock.AddValidBreakDuration();
            profileService.Setup(obj => obj.AddBreakDuration(duration)).Throws(new Exception());
            var Result = profileControllers.AddBreakDuration(duration) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //DisableBreakDurationDetails
        [Theory]
        [InlineData(1)]

        public void DisableBreakDuration_ShouldReturnStatusCode200_WhenIdIsPassed(int BreakDurationId)
        {
            profileService.Setup(obj => obj.DisableBreakDuration(BreakDurationId)).Returns(true);
            var Result = profileControllers.DisableBreakDuration(BreakDurationId) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void DisableBreakDuration_ShouldReturnStatusCode400_WhenExceptionIsThrown(int BreakDurationId)
        {
            var Result = profileControllers.DisableBreakDuration(BreakDurationId) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]

        public void DisableBreakDuration_ShouldReturnStatusCode500_WhenIdIsPassed(int BreakDurationId)
        {
            profileService.Setup(obj => obj.DisableBreakDuration(BreakDurationId)).Returns(false);
            var Result = profileControllers.DisableBreakDuration(BreakDurationId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableBreakDuration_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int BreakDurationId)
        {
            profileService.Setup(obj => obj.DisableBreakDuration(BreakDurationId)).Throws(new ArgumentNullException());
            var Result = profileControllers.DisableBreakDuration(BreakDurationId) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableBreakDuration_ShouldReturnStatusCode500_WhenExceptionIsThrown(int BreakDurationId)
        {
            profileService.Setup(obj => obj.DisableBreakDuration(BreakDurationId)).Throws(new Exception());
            var Result = profileControllers.DisableBreakDuration(BreakDurationId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        //AddLanguageDetails
        [Theory]
        [InlineData(null)]
        public void AddLanguage_ShouldreturnStatuscode400_WhenLanguageObjectIsNull(Language language)
        {
            var Result = profileControllers.AddLanguage(language) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddLanguage_ShouldreturnStatuscode200_WhenLanguageObjectIsPassed()
        {
            Language language = ProfileMock.AddValidLanguage();
            profileService.Setup(obj => obj.AddLanguage(language)).Returns(true);
            var Result = profileControllers.AddLanguage(language) as ObjectResult;//act
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void AddLanguage_ShouldreturnStatuscode500_WhenLanguageObjectIsPassed()
        {
            Language language = ProfileMock.AddValidLanguage();
            profileService.Setup(obj => obj.AddLanguage(language)).Returns(false);
            var Result = profileControllers.AddLanguage(language) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //Exception
        [Fact]
        public void AddLanguage_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
        {
            Language language = ProfileMock.AddValidLanguage();
            profileService.Setup(obj => obj.AddLanguage(language)).Throws(new ValidationException());
            var Result = profileControllers.AddLanguage(language) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddLanguage_ShouldreturnStatuscode400_WhenArgumentNullExceptionIsThrown()
        {
            Language language = ProfileMock.AddValidLanguage();
            profileService.Setup(obj => obj.AddLanguage(language)).Throws(new ArgumentNullException());
            var Result = profileControllers.AddLanguage(language) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddLanguage_ShouldreturnStatuscode500_WhenExceptionIsThrown()
        {
            Language language = ProfileMock.AddValidLanguage();
            profileService.Setup(obj => obj.AddLanguage(language)).Throws(new Exception());
            var Result = profileControllers.AddLanguage(language) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //DisableLanguageDetails
        [Theory]
        [InlineData(1)]

        public void DisableLanguage_ShouldReturnStatusCode200_WhenIdIsPassed(int Language_Id)
        {
            profileService.Setup(obj => obj.DisableLanguage(Language_Id)).Returns(true);
            var Result = profileControllers.DisableLanguage(Language_Id) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void DisableLanguage_ShouldReturnStatusCode400_WhenExceptionIsThrown(int Language_Id)
        {
            var Result = profileControllers.DisableLanguage(Language_Id) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]

        public void DisableLanguage_ShouldReturnStatusCode500_WhenIdIsPassed(int Language_Id)
        {
            profileService.Setup(obj => obj.DisableLanguage(Language_Id)).Returns(false);
            var Result = profileControllers.DisableLanguage(Language_Id) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableLanguage_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int Language_Id)
        {
            profileService.Setup(obj => obj.DisableLanguage(Language_Id)).Throws(new ArgumentNullException());
            var Result = profileControllers.DisableLanguage(Language_Id) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableLanguage_ShouldReturnStatusCode500_WhenExceptionIsThrown(int Language_Id)
        {
            profileService.Setup(obj => obj.DisableLanguage(Language_Id)).Throws(new Exception());
            var Result = profileControllers.DisableLanguage(Language_Id) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }

        //AddSocialMediaDetails
        [Theory]
        [InlineData(null)]
        public void AddSocialMedia_ShouldreturnStatuscode400_WhenSocialMediaObjectIsNull(SocialMedia media)
        {
            var Result = profileControllers.AddSocialMedia(media) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddSocialMedia_ShouldreturnStatuscode200_WhenSocialMediaObjectIsPassed()
        {
            SocialMedia media = ProfileMock.AddValidSocialMedia();
            profileService.Setup(obj => obj.AddSocialMedia(media)).Returns(true);
            var Result = profileControllers.AddSocialMedia(media) as ObjectResult;//act
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void AddSocialMedia_ShouldreturnStatuscode500_WhenSocialMediaObjectIsPassed()
        {
            SocialMedia media = ProfileMock.AddValidSocialMedia();
            profileService.Setup(obj => obj.AddSocialMedia(media)).Returns(false);
            var Result = profileControllers.AddSocialMedia(media) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //Exception
        [Fact]
        public void AddSocialMedia_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
        {
            SocialMedia media = ProfileMock.AddValidSocialMedia();
            profileService.Setup(obj => obj.AddSocialMedia(media)).Throws(new ValidationException());
            var Result = profileControllers.AddSocialMedia(media) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddSocialMedia_ShouldreturnStatuscode400_WhenArgumentNullExceptionIsThrown()
        {
            SocialMedia media = ProfileMock.AddValidSocialMedia();
            profileService.Setup(obj => obj.AddSocialMedia(media)).Throws(new ArgumentNullException());
            var Result = profileControllers.AddSocialMedia(media) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddSocialMedia_ShouldreturnStatuscode500_WhenExceptionIsThrown()
        {
            SocialMedia media = ProfileMock.AddValidSocialMedia();
            profileService.Setup(obj => obj.AddSocialMedia(media)).Throws(new Exception());
            var Result = profileControllers.AddSocialMedia(media) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //DisableLanguageDetails
        [Theory]
        [InlineData(1)]

        public void DisableSocialMedia_ShouldReturnStatusCode200_WhenIdIsPassed(int SocialMedia_Id)
        {
            profileService.Setup(obj => obj.DisableSocialMedia(SocialMedia_Id)).Returns(true);
            var Result = profileControllers.DisableSocialMedia(SocialMedia_Id) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void DisableSocialMedia_ShouldReturnStatusCode400_WhenExceptionIsThrown(int SocialMedia_Id)
        {
            var Result = profileControllers.DisableSocialMedia(SocialMedia_Id) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]

        public void DisableSocialMedia_ShouldReturnStatusCode500_WhenIdIsPassed(int SocialMedia_Id)
        {
            profileService.Setup(obj => obj.DisableSocialMedia(SocialMedia_Id)).Returns(false);
            var Result = profileControllers.DisableSocialMedia(SocialMedia_Id) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableSocialMedia_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int SocialMedia_Id)
        {
            profileService.Setup(obj => obj.DisableSocialMedia(SocialMedia_Id)).Throws(new ArgumentNullException());
            var Result = profileControllers.DisableSocialMedia(SocialMedia_Id) as ObjectResult;
            Assert.Equal(400, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void DisableSocialMedia_ShouldReturnStatusCode500_WhenExceptionIsThrown(int SocialMedia_Id)
        {
            profileService.Setup(obj => obj.DisableSocialMedia(SocialMedia_Id)).Throws(new Exception());
            var Result = profileControllers.DisableSocialMedia(SocialMedia_Id) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }

        //AddProfileHistoryDetails
        [Theory]
        [InlineData(null)]
        public void AddProfileHistory_ShouldreturnStatuscode400_WhenProfileHistoryObjectIsNull(ProfileHistory profilehistory)
        {
            var Result = profileControllers.AddProfileHistory(profilehistory) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddProfileHistory_ShouldreturnStatuscode200_WhenProfileHistoryObjectIsPassed()
        {
            ProfileHistory profilehistory = ProfileMock.AddValidProfileHistory();
            profileService.Setup(obj => obj.AddProfileHistory(profilehistory)).Returns(true);
            var Result = profileControllers.AddProfileHistory(profilehistory) as ObjectResult;//act
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void AddProfileHistory_ShouldreturnStatuscode500_WhenProfileHistoryObjectIsPassed()
        {
            ProfileHistory profilehistory = ProfileMock.AddValidProfileHistory();
            profileService.Setup(obj => obj.AddProfileHistory(profilehistory)).Returns(false);
            var Result = profileControllers.AddProfileHistory(profilehistory) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //Exception
        [Fact]
        public void AddProfileHistory_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
        {
            ProfileHistory profilehistory = ProfileMock.AddValidProfileHistory();
            profileService.Setup(obj => obj.AddProfileHistory(profilehistory)).Throws(new ValidationException());
            var Result = profileControllers.AddProfileHistory(profilehistory) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddProfileHistory_ShouldreturnStatuscode400_WhenArgumentNullExceptionIsThrown()
        {
            ProfileHistory profilehistory = ProfileMock.AddValidProfileHistory();
            profileService.Setup(obj => obj.AddProfileHistory(profilehistory)).Throws(new ArgumentNullException());
            var Result = profileControllers.AddProfileHistory(profilehistory) as ObjectResult;//act
            Assert.Equal(400, Result?.StatusCode);
        }
        [Fact]
        public void AddProfileHistory_ShouldreturnStatuscode500_WhenExceptionIsThrown()
        {
            ProfileHistory profilehistory = ProfileMock.AddValidProfileHistory();
            profileService.Setup(obj => obj.AddProfileHistory(profilehistory)).Throws(new Exception());
            var Result = profileControllers.AddProfileHistory(profilehistory) as ObjectResult;//act
            Assert.Equal(500, Result?.StatusCode);
        }
        //GetAllProfileHistoryDetails
        [Fact]
        public void GetallProfileHistories_ShouldReturnGetAllProfileHistories_WhenMethodIsCalled()
        {
            var profilehistory = ProfileMock.GetAllValidProfileHistories();
            profileService.Setup(obj => obj.GetallProfileHistories()).Returns(profilehistory);
            var Result = profileControllers.GetallProfileHistories() as ObjectResult;
            Assert.Equal(profilehistory, Result?.Value);

        }
        //Exception
        [Fact]
        public void GetallProfileHistory_ShouldReturnStatuscode500_WhenExceptionIsThrown()
        {
            var profilehistory = ProfileMock.GetAllValidProfileHistories();
            profileService.Setup(obj => obj.GetallProfileHistories()).Throws(new Exception());
            var Result = profileControllers.GetallProfileHistories() as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);

        }
        // [Theory]
        // [InlineData(-1)]
        // public void GetProfileHistoryById_ShouldReturnStatusCode400_WhenIdIsPassed(int Profileid)
        // {
        //     var Result = profileControllers.GetProfileHistoryById(Profileid) as ObjectResult;
        //     Assert.Equal(400, Result?.StatusCode);
        // }
        // [Theory]
        // [InlineData(001)]
        // public void GetProfileHistoryById_ShouldReturnStatusCode200_WhenIdIsPassed(int Profileid)
        // {
        //     profileService.Setup(obj => obj.GetProfileHistoryById(Profileid)).Returns(ProfileMock.GetAllValidProfileHistories());
        //     var Result = profileControllers.GetProfileHistoryById(Profileid) as ObjectResult;
        //     Assert.Equal(200, Result?.StatusCode);

        // }
        // //Exception
        // [Theory]
        // [InlineData(1)]
        // public void GetProfileHistoryById_ShouldReturnStatusCode400_WhenArgumentNullExceptionIsThrown(int Profileid)
        // {
        //     profileService.Setup(obj => obj.GetProfileHistoryById(Profileid)).Throws(new ArgumentNullException());
        //     var Result = profileControllers.GetProfileHistoryById(Profileid) as ObjectResult;
        //     Assert.Equal(400, Result?.StatusCode);

        // }
        // [Fact]
        // public void GetProfileHistoryById_ShouldReturnStatusCode500_WhenExceptionIsThrown()
        // {
        //     int Profileid=2;
        //     profileService.Setup(obj => obj.GetProfileHistoryById(Profileid)).Throws(new Exception());
        //     var Result = profileControllers.GetProfileHistoryById(Profileid) as ObjectResult;
        //     Assert.Equal(500, Result?.StatusCode);

        // }
    }
}