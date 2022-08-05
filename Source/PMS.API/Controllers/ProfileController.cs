using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
namespace PMS_API
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[Action]")]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IMailService _mailService;
        private readonly ILogger _logger;
        public ProfileController(IProfileService profileService, ILogger<ProfileController> logger, IMailService mailService)
        {
            _profileService = profileService;
            _logger = logger;
            _mailService = mailService;
        }

        //Adding a Profile
        [HttpPost]
        public IActionResult AddProfile(Profile profile)
        {
            if (profile == null)
            {
                _logger.LogError("ProfileController:AddProfile():User tries to enter null values");
                return BadRequest(new { message = "Profile not be null" });
            }
            try
            {
                return _profileService.AddProfile(profile) ? Ok(new { message = "Profile added" }) : Problem("Some internal Error occured");
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController :AddProfile()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :AddProfile()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }

        //Adding Personal details for a Profile
        [HttpPost]
        public IActionResult AddPersonalDetail(PersonalDetails personalDetails)
        {
            if (personalDetails == null)
            {
                _logger.LogError("ProfileController:AddPersonalDetail():User tries to enter null values");
                return BadRequest(new { message = "PersonalDetail not be null" });
            }
            try
            {
                return _profileService.AddPersonalDetail(personalDetails) ? Ok(new { message = "PersonalDetails added" }) : Problem("Some internal Error occured");
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController :AddPersonalDetail()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :AddPersonalDetail()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :AddPersonalDetail()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }

        //Getting Personal details of all Profiles
        [HttpGet]
        public IActionResult GetallPersonalDetails()
        {
            try
            {

                return Ok(_profileService.GetAllPersonalDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetAllPersonalDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }


        }

        //Getting Personal detail of a Profile using Pesronal details Id
        [HttpGet]
        public IActionResult GetPersonalDetailsById(int Personalid)
        {
            if (Personalid <= 0)
            {
                _logger.LogError("ProfileController:GetPersonalDetailsById():User tries to enter invalid id");
                return BadRequest(new { message = "PersonalDetail Id should not be null or negative" });
            }
            try
            {

                return Ok(_profileService.GetPersonalDetailsById(Personalid));
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :GetPersonalDetailsById()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetPersonalDetailsById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Getting Personal detail of a Profile using Profile Id
        [HttpGet]
        public IActionResult GetPersonalDetailsByProfileId(int Profileid)
        {
            if (Profileid <= 0)
            {
                _logger.LogError("ProfileController:GetPersonalDetailsByProfileId():User tries to enter invalid id");
                return BadRequest(new { message = "Profile Id should not be null or negative" });
            }
            try
            {

                return Ok(_profileService.GetPersonalDetailsByProfileId(Profileid));
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :PersonalDetailsByProfileId()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetPersonalDetailsByProfileId()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Updation of Personal details
        [HttpPut]
        public IActionResult UpdatePersonalDetail(PersonalDetails personalDetails)

        {

            if (personalDetails == null)
            {
                _logger.LogInformation("ProfileController :UpdatePersonalDetails()-Profile's personaldetails should not be null values");
                return BadRequest(new { message = "Profile's personaldetails should not be null" });
            }
            try
            {

                return _profileService.UpdatePersonalDetail(personalDetails) ? Ok(new { message = "PersonalDetails Updated Successfully" }) : Problem("Sorry internal error occured");

            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :UpdatePersonalDetail()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController:UpdatePersonalDetail()-{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Disable Personal details
        [HttpDelete]
        public IActionResult DisablePersonalDetails(int PersonalDetailsId)
        {
            if (PersonalDetailsId <= 0)
                return BadRequest(new { message = "PersonalDetailsId can't be null or negative" });


            try
            {
                return _profileService.DisablePersonalDetails(PersonalDetailsId) ? Ok(new { message = "PersonalDetails Removed Successfully" }) : Problem("Sorry internal error occured");
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :DisablePersonalDetails()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : DisablePersonalDetails() throwed an exception : {exception}");
                return Problem("Sorry some internal error occured");
            }

        }

        //Adding Education details for a Profile
        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            if (education == null)
            {
                _logger.LogError("ProfileController:AddEducation():User tries to enter null values");
                return BadRequest(new { message = "Education details should not be null" });
            }
            try
            {
                return _profileService.AddEducation(education) ? Ok(new { message = "Education details added" }) : Problem("Some internal Error occured");
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController :AddEducation()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :AddEducation()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :AddEducation()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }


        }

        //Getting Education details of all Profiles
        [HttpGet]
        public IActionResult GetallEducationDetails()
        {
            try
            {
                return Ok(_profileService.GetallEducationDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetallEducationDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Getting Education details of a Profile using Education Id
        [HttpGet]
        public IActionResult GetEducationDetailsById(int Educationid)
        {
            if (Educationid <= 0)
                return BadRequest(new { message = "Education Id can't be null or negative" });
            try
            {

                return Ok(_profileService.GetEducationDetailsById(Educationid));
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :GetEducationDetailsById()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetEducationDetailsById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Getting all the Education details of a Profile using Profile Id
        [HttpGet]
        public IActionResult GetAllEducationDetailsByProfileId(int Profileid)
        {
            if (Profileid <= 0)
                return BadRequest(new { message = "Profile Id can't be null or negative" });
            try
            {

                return Ok(_profileService.GetAllEducationDetailsByProfileId(Profileid));
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :GetAllEducationDetailsByProfileId()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetAllEducationDetailsByProfileId()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Updation of Education details
        [HttpPut]
        public IActionResult UpdateEducation(Education education)

        {

            if (education == null)
            {
                _logger.LogInformation("ProfileController :UpdateEducation()-Profile's Eucationdetails should not enter null values");
                return BadRequest(new { message = "Education details should not be null" });
            }
            try
            {

                return _profileService.UpdateEducation(education) ? Ok(new { message = "Education Updated Successfully" }) : Problem("Sorry internal error occured");

            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :UpdateEducation()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController:UpdateEducation()-{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Disable Education details
        [HttpDelete]
        public IActionResult DisableEducationalDetails(int EducationId)
        {
            if (EducationId <= 0)
                return BadRequest(new { message = "Education Id can't be null or negative" });


            try
            {
                return _profileService.DisableEducationalDetails(EducationId) ? Ok(new { message = "Education Removed Successfully" }) : Problem("Sorry internal error occured");
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :DisableEducationalDetails()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : DisableEducationalDetails() throwed an exception : {exception}");
                return Problem("Sorry some internal error occured");
            }

        }

        //Adding Project details for a Profile
        [HttpPost]
        public IActionResult AddProjects(Projects projects)
        {
            if (projects == null)
            {
                _logger.LogError("ProfileController:AddProjects():user tries to enter null values");
                return BadRequest(new { message = "Project details should not be null" });
            }
            try
            {
                return _profileService.AddProjects(projects) ? Ok(new { message = "Project details added" }) : Problem("Some internal Error occured");
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController :AddProjects()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :AddProjects()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :AddProjects()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }

        }

        //Getting all Project details
        [HttpGet]
        public IActionResult GetallProjectDetails()
        {
            try
            {

                return Ok(_profileService.GetallProjectDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetallProjectDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }


        }
        
        //Getting Project details of a Profile using Project Id
        [HttpGet]
        public IActionResult GetProjectDetailsById(int Projectid)
        {
            if (Projectid <= 0)
                return BadRequest(new { message = "Project Id can't be null or negative" });
            try
            {

                return Ok(_profileService.GetProjectDetailsById(Projectid));
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :GetProjectDetailsById()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetProjectDetailsById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Getting all the Project details of a Profile using Profile Id
        [HttpGet]
        public IActionResult GetAllProjectDetailsByProfileId(int Profileid)
        {
            if (Profileid <= 0)
                return BadRequest(new { message = "Profile Id can't be null or negative" });
            try
            {

                return Ok(_profileService.GetAllProjectDetailsByProfileId(Profileid));
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :GetAllProjectDetailsByProfileId()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetAllProjectDetailsByProfileId()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Updation of Project details
        [HttpPut]
        public IActionResult UpdateProjects(Projects projects)

        {

            if (projects == null)
            {
                _logger.LogInformation("ProfileController :UpdateProjects()-Profile's Projects should not be null");
                return BadRequest(new { message = "Project values should not be null" });
            }
            try
            {

                return _profileService.UpdateProjects(projects) ? Ok(new { message = "Projects Updated Successfully" }) : Problem("Sorry internal error occured");

            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :UpdateProjects()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController:UpdateProjects()-{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Disable Project details
        [HttpDelete]
        public IActionResult DisableProjectDetails(int ProjectsId)
        {
            if (ProjectsId <= 0)
                return BadRequest(new { message = "Project Id can't be null or negative" });


            try
            {
                return _profileService.DisableProjectDetails(ProjectsId) ? Ok(new { message = "Project Removed Successfully" }) : Problem("Sorry internal error occured");
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :DisableProjectDetails()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : DisableProjectDetails() throwed an exception : {exception}");
                return Problem("Sorry some internal error occured");
            }

        }

        //Adding Skill details for a Profile
        [HttpPost]
        public IActionResult AddSkills(Skills skill)
        {
            if (skill == null)
            {
                _logger.LogError("ProfileController:AddSkills():user tries to enter null values");
                return BadRequest(new { message = "Skill details should not be null" });
            }
            try
            {
                return _profileService.AddSkills(skill) ? Ok(new { message = "Skill details added" }) : Problem("Some internal Error occured");
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController:AddSkills()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :AddSkills()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController:AddSkills()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }

        }

        //Getting all Skill details
        [HttpGet]
        public IActionResult GetallSkillDetails()
        {
            try
            {

                return Ok(_profileService.GetallSkillDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : GetallSkillDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }


        }

        //Getting Skill details of a Profile using Skill Id
        [HttpGet]
        public IActionResult GetSkillDetailsById(int Skillid)
        {
            if (Skillid <= 0)
                return BadRequest(new { message = "Skill Id can't be null or negative" });
            try
            {

                return Ok(_profileService.GetSkillDetailsById(Skillid));
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :GetSkillDetailsById()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : GetSkillDetailsById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Getting all the Skill details of a Profile using Profile Id
        [HttpGet]
        public IActionResult GetAllSkillDetailsByProfileId(int Profileid)
        {
            if (Profileid <= 0)
                return BadRequest(new { message = "Profile Id can't be null or negative" });
            try
            {

                return Ok(_profileService.GetAllSkillDetailsByProfileId(Profileid));
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :GetAllSkillDetailsByProfileId()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetAllSkillDetailsByProfileId()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Updation of Skills
        [HttpPut]
        public IActionResult UpdateSkills(Skills skill)

        {

            if (skill == null)
            {
                _logger.LogInformation("PersonalServiceController :UpdateSkills()-Profiles Skill values not be null");
                return BadRequest(new { message = "Skills values should not be null" });
            }
            try
            {

                return _profileService.UpdateSkills(skill) ? Ok(new { message = "Skills Updated Successfully" }) : Problem("Sorry internal error occured");

            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :UpdateSkills()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController:UpdateSkills()-{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Disable Skill details 
        [HttpDelete]
        public IActionResult DisableSkillDetails(int SkillId)
        {
            if (SkillId <= 0)
                return BadRequest(new { message = "SkillId can't be null or negative" });


            try
            {
                return _profileService.DisableSkillDetails(SkillId) ? Ok(new { message = "Skill Removed Successfully" }) : Problem("Sorry internal error occured");
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :DisableSkillDetails()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : DisableSkillDetails() throwed an exception : {exception}");
                return Problem("Sorry some internal error occured");
            }

        }

        //Adding Languages known for a Profile
        [HttpPost]
        public IActionResult AddLanguage(Language language)
        {
            if (language == null)
            {
                _logger.LogError("ProfileController:AddLanguage():user tries to enter null values");
                return BadRequest(new { message = "Language details not be null" });
            }
            try
            {
                return _profileService.AddLanguage(language) ? Ok(new { message = "Language details added" }) : Problem("Some internal Error occured");
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController:AddLanguage()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :AddLanguage()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController:AddLanguage()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }

        }

        //Disable Langugages known
        [HttpDelete]
        public IActionResult DisableLanguage(int Language_Id)
        {
            if (Language_Id <= 0)
                return BadRequest(new { message = "Language Id can't be null or negative" });


            try
            {
                return _profileService.DisableLanguage(Language_Id) ? Ok(new { message = "Language Removed Successfully" }) : Problem("Sorry internal error occured");
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :DisableLanguage()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : DisableLanguage() throwed an exception : {exception}");
                return Problem("Sorry some internal error occured");
            }
        }

        //Adding Social Media details for a Profile
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia media)
        {
            if (media == null)
            {
                _logger.LogError("ProfileController:AddSocialMedia():user tries to enter null values");
                return BadRequest(new { message = "Social media details should not be null" });
            }
            try
            {
                return _profileService.AddSocialMedia(media) ? Ok(new { message = "Social media details added" }) : Problem("Some internal Error occured");
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController:AddSocialMedia()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :AddSocialMedia()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController:AddSocialMedia()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }

        }

        //Disable Social Media details
        [HttpDelete]
        public IActionResult DisableSocialMedia(int SocialMedia_Id)
        {
            if (SocialMedia_Id <= 0)
                return BadRequest(new { message = "SocialMedia Id can't be null or negative" });


            try
            {
                return _profileService.DisableSocialMedia(SocialMedia_Id) ? Ok(new { message = "SocialMedia_ Removed Successfully" }) : Problem("Sorry internal error occured");
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :DisableSocialMedia()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController : DisableSocialMedia() throwed an exception : {exception}");
                return Problem("Sorry some internal error occured");
            }

        }

        //Adding Achievement details for a Profile
        [HttpPost]
        public IActionResult AddAchievement(Achievements achievement)
        {
            if (achievement == null)
            {
                _logger.LogError("ProfileController:AddAchievement():user tries to enter null values");
                return BadRequest(new { message = "achievement details not be null" });
            }
            try
            {
                return _profileService.AddAchievements(achievement) ? Ok(new { message = "Achievements details added" }) : Problem("Some internal Error occured");
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController:AddAchievement()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :AddAchievement()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController:AddAchievement()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }

        //Getting Achievement details of all Profiles
        [HttpGet]
        public IActionResult GetallAchievements()
        {
            try
            {

                return Ok(_profileService.GetallAchievements());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetallAchievements()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }


        }

        //Getting all the Achievement details of a Profile using Profile Id
        [HttpGet]
        public IActionResult GetAllAchievementDetailsByProfileId(int Profileid)
        {
            if (Profileid <= 0)
                return BadRequest(new { message = "Profile Id can't be null or negative" });
            try
            {

                return Ok(_profileService.GetAllAchievementDetailsByProfileId(Profileid));
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :GetAllAchievementDetailsByProfileId()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetAllAchievementDetailsByProfileId()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Disable Achievement details
        [HttpDelete]
        public IActionResult DisableAchievements(int achievementId)
        {
            if (achievementId <= 0)
                return BadRequest(new { message = "Achievement id can't be null or negative" });


            try
            {
                return _profileService.DisableAchievement(achievementId) ? Ok(new { message = "Achievement Removed Successfully" }) : Problem("Sorry internal error occured");
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :DisableAchievements()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($" ProfileController: DisableAchievements() : {exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Getting all Profile details
        [HttpGet]
        public IActionResult GetallProfiles()
        {
            try
            {

                return Ok(_profileService.GetallProfiles());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetallProfiles()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Getting Profile details of a Profile using Profile Id
        [HttpGet]
        public IActionResult GetProfileById(int id)
        {
            if (id <= 0)
            {
                _logger.LogError("ProfileController:GetProfileById():User tries to enter invalid id");
                return BadRequest(new { message = "Profile Id should not be null or negative" });
            }
            try
            {

                return Ok(_profileService.GetProfileById(id));
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"ProfileController :GetProfileById()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetProfileById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Getting Profile Id by the User Id passed
        [HttpGet]
        public IActionResult GetProfileIdByGivenUserId(int userId)
        {
            try
            {
                return Ok(_profileService.GetProfileIdByUserId(userId));
            }
            catch (ValidationException exception)
            {

                _logger.LogInformation($"ProfileController: GetProfileIdByGivenUserId() {exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);

            }

        }

        //Getting Profile Id by the logged in user's User Id
        [HttpGet]
        public IActionResult GetProfileIdByUserId()
        {
            try
            {
                int currentUser = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                return Ok(_profileService.GetProfileIdByUserId(currentUser)) ;
            }
            catch (Exception exception)
            {

                _logger.LogInformation($"ProfileController: GetProfileIdByUserId() {exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);

            }

        }

        //Getting Count of Profiles
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetProfileCount()
        {
            try
            {
                int currentdesignation = Convert.ToInt32(User.FindFirst("DesignationId")?.Value) ;
                return Ok(_profileService.GetProfileCount(currentdesignation));

            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :GetProfileCount()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Getting Profiles based on Filters applied
        [HttpPost]
        public IActionResult GetFilteredProfile(CascadeFilter filterValues)
        {
            try
            {
                int currentdesignation = Convert.ToInt32(User.FindFirst("DesignationId")?.Value);
                return Ok(_profileService.GetFilteredProfile(filterValues.UserName!,filterValues.DesignationId, filterValues.DomainID, filterValues.TechnologyId, filterValues.CollegeId, filterValues.ProfileStatusId,currentdesignation));
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileController :GetFilteredProfile()- {exception.Message}{exception.StackTrace}");
                return Problem(exception.Message);
            }
        }

        //Accepting or Rejecting of a Profile
        [HttpPost]
        public IActionResult AcceptOrRejectProfile(int profileId, int response)
        {
            if (profileId <= 0)
            {
                _logger.LogError("ProfileController:():AcceptOrRejectProfile() ProfileId is not valid");
                return BadRequest(new { message = "Profile Id cannot be null" });
            }
            try
            {
                _profileService.AcceptOrRejectProfile(profileId, response);
                return Ok(new { message = "Profile Status Changed" });
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController :AcceptOrRejectProfile()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :AcceptOrRejectProfile()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }

        //Requesting to Update a Profile
        [HttpPost]
        public IActionResult RequestToUpdate(int profileId)
        {
            if (profileId <= 0)
            {
                _logger.LogError("ProfileController:():RequestToUpdate() ProfileId is not valid");
                return BadRequest(new { message = "Profile Id cannot be null" });
            }
            try
            {
                _mailService.RequestToUpdateFile(profileId);
                return Ok(new { message ="Requst to update has been sent sucessfully via mail"});
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController :RequestToUpdate()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :RequestToUpdate()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }

        //Sharing a Profile
        [HttpPost]
        public IActionResult ShareProfile(string profileUrl, int profileId, string toEmailName)
        {
            if (String.IsNullOrEmpty(profileUrl))
            {
                _logger.LogError("ProfileController:():ShareProfile() ProfileId is not valid");
                return BadRequest(new { message = "Profile Id cannot be null" });
            }
            try
            {
                _mailService.ShareProfile(profileUrl, profileId, toEmailName);
                return Ok("Profile shared sucessfully via mail");
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController :ShareProfile()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :ShareProfile()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }

        //Updation of Profile Status for a Profile
        [HttpPut]
        public IActionResult updateProfileStatus(Profile profile)
        {
            if (profile.Equals(null))
            {
                _logger.LogError("ProfileController : updateProfileStatus() Profile is not valid");
                return BadRequest(new { message = "Profile cannot be null" });
            }
            try
            {
                return _profileService.updateProfileStatus(profile)? Ok(new{message="changed to waiting for approval"}): Problem("sorry Internal error occured");
                
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController :updateProfileStatus()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileController :updateProfileStatus()-{exception.Message}{exception.StackTrace}");
                return Problem("Sorry Internal error occured");
            }
        }
    }
}
