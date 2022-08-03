using System.ComponentModel.DataAnnotations;
using PMS_API;

namespace PMS_API
{
    public class ProfileService : IProfileService
    {

        ProfileData profileData;
        private readonly ILogger<ProfileService> _logger;
        private static ProfileValidation _profileValidate = ProfileDataFactory.GetProfileVaidationObject();

        public ProfileService(ILogger<ProfileService> logger)
        {
            _logger = logger;
            profileData = ProfileDataFactory.GetProfileData(logger);

        }

        //Adding a Profile
        public bool AddProfile(Profile profile)
        {
            if (profile == null) throw new ArgumentNullException($"Values cannot be null values are {profile}");
            try
            {
                profile.CreatedBy = profile.UserId;
                profile.CreatedOn = DateTime.Now;
                profile.IsActive = true;
                return profileData.AddProfile(profile) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:AddProfile()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }

        }

        //Adding Personal details for a Profile
        public bool AddPersonalDetail(PersonalDetails personalDetails)
        {
            if (personalDetails == null) throw new ArgumentNullException($"Values cannot be null values are {personalDetails}");
            _profileValidate.PersonalDetailsvalidate(personalDetails);
            try
            {

                personalDetails.CreatedBy = personalDetails.ProfileId;
                personalDetails.CreatedOn = DateTime.Now;
                string Imagedate = "";
                Imagedate = ImageService.Getbase64String(personalDetails.base64header!);

                personalDetails.base64header = ImageService.Getbase64Header(personalDetails.base64header!);

                personalDetails.Image = System.Convert.FromBase64String(Imagedate);
                return profileData.AddPersonalDetail(personalDetails) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:AddPersonalDetail()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }

        }

        //Getting Personal details of all Profiles
        public IEnumerable<PersonalDetails> GetAllPersonalDetails()
        {
            try
            {
                return from personalDetails in profileData.GetAllPersonalDetails() where personalDetails.IsActive == true select personalDetails;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetallPersonalDetails()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting Personal detail of a Profile using Pesronal details Id
        public object GetPersonalDetailsById(int Personalid)
        {
            if (Personalid <= 0)
                throw new ArgumentNullException($"ID is not provided{Personalid}");
            try
            {
                var getpersonaldetails = profileData.GetPersonalDetailsById(Personalid);
                return new
                {
                    personaldetailsid = getpersonaldetails.PersonalDetailsId,
                    Image = getpersonaldetails.Image,
                    objective = getpersonaldetails.Objective,
                    dateofbirth = getpersonaldetails.DateOfBirth,
                    nationality = getpersonaldetails.Nationality,
                    dateofjoining = getpersonaldetails.DateOfJoining,
                    language = getpersonaldetails.language,
                    socialmedia = getpersonaldetails.socialmedia,
                    breakduration = getpersonaldetails.breakDuration,

                };
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetPersonalDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting Personal detail of a Profile using Profile Id
        public object GetPersonalDetailsByProfileId(int Profileid)
        {
            if (Profileid <= 0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var getpersonaldetailsbyprofileid = profileData.GetAllPersonalDetails().Where(item => item.ProfileId == Profileid).Select(item =>
                 new
                 {
                     personaldetailsid = item.PersonalDetailsId,
                     Image = item.Image,
                     objective = item.Objective,
                     dateofbirth = item.DateOfBirth,
                     nationality = item.Nationality,
                     dateofjoining = item.DateOfJoining,
                     language = removeAdditionalDetailsExceptLanguage(item.language!),
                     socialmedia = removeAdditionalDetailsExceptSocialMedia(item.socialmedia!),

                 }).FirstOrDefault(); 

                 return getpersonaldetailsbyprofileid!;

            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetPersonalDetailsByProfileId()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Removing additional details in Personal details except Languages known
        private ICollection<Language> removeAdditionalDetailsExceptLanguage(ICollection<Language> languages)
        {
            foreach (var item in languages)
            {
                if(item.IsActive==true){
                    item.personalDetails = null;
                }
                else{
                    languages.Remove(item);
                }
                
            }
            return languages;
        }
       
        //Removing additional details in Personal details except Social Media
        private ICollection<SocialMedia> removeAdditionalDetailsExceptSocialMedia(ICollection<SocialMedia> socialMedias)
        {
            foreach (var item in socialMedias)
            {
                if(item.IsActive==true){
                item.personalDetails = null;
                }
                else{
                    socialMedias.Remove(item);
                }
            }
            return socialMedias;
        }

        //Getting Personal details using Personal details Id
        public PersonalDetails GetPersonalById(int PersonalDetailsId)
        {
            try
            {
                if (PersonalDetailsId <= 0)
                    throw new ArgumentNullException($"ID is not provided{PersonalDetailsId}");
                PersonalDetails personalDetails = profileData.GetPersonalDetailsById(PersonalDetailsId);
                return personalDetails;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetPersonalById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Updation of Personal details
        public bool UpdatePersonalDetail(PersonalDetails personalDetails)
        {
            if (personalDetails == null) throw new ArgumentNullException($" ProfileService:UpdatePersonalDetail()-Personal values not be null{personalDetails}");
            _profileValidate.PersonalDetailsvalidate(personalDetails);
            try
            {
                var Profile = GetPersonalById(personalDetails.PersonalDetailsId);
                if (Profile.Objective != personalDetails.Objective)
                    Profile.Objective = personalDetails.Objective;
                if (Profile.DateOfBirth != personalDetails.DateOfBirth)
                    Profile.DateOfBirth = personalDetails.DateOfBirth;
                if (Profile.DateOfJoining != personalDetails.DateOfJoining)
                    Profile.DateOfJoining = personalDetails.DateOfJoining;
                if (Profile.Nationality != personalDetails.Nationality)
                    Profile.Nationality = personalDetails.Nationality;
                
                string Imagedate = "";
                Imagedate = ImageService.Getbase64String(personalDetails.base64header!);

                Profile.base64header = ImageService.Getbase64Header(personalDetails.base64header!);

                Profile.Image = System.Convert.FromBase64String(Imagedate);
                Profile.UpdatedBy = personalDetails.CreatedBy;
                Profile.UpdatedOn = DateTime.Now;
                return profileData.UpdatePersonalDetail(Profile);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:UpdatePersonalDetail()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }

        }

        //Disable Personal details
        public bool DisablePersonalDetails(int PersonalDetailid)
        {
            if (PersonalDetailid <= 0)
                throw new ArgumentNullException($"ID is not provided{PersonalDetailid}");


            try
            {

                return profileData.DisablePersonalDetails(PersonalDetailid) ? true : false;

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:DisablePersonalDetails()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }

        //Adding Education details for a Profile
        public bool AddEducation(Education education)
        {
            if (education == null) throw new ArgumentNullException($"Values cannot be null values are {education}");
            _profileValidate.Educationdetailvalidation(education);
            try
            {
                education.CreatedBy = education.ProfileId;
                education.CreatedOn = DateTime.Now;
                return profileData.AddEducation(education) ? true : false;
            }
            catch (ValidationException exception)
            {
                _logger.LogError($"ProfileService:AddEducation()-{exception.Message}\n{exception.StackTrace}");
                throw;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:AddEducation()-{exception.Message}\n{exception.StackTrace}");
                throw;

            }
        }

        //Getting Education details of a Profile using Education Id
        public Object GetEducationDetailsById(int Educationid)
        {
            if (Educationid <= 0)
                throw new ArgumentNullException($"ID is not provided{Educationid}");
            try
            {
                var geteducationdetails = profileData.GetEducationDetailsById(Educationid);
                return new
                {
                    educationid = geteducationdetails.EducationId,
                    degree = geteducationdetails.Degree,
                    course = geteducationdetails.Course,
                    college = geteducationdetails.college!.CollegeName,
                    collegeid = geteducationdetails.CollegeId,
                    starting = geteducationdetails.Starting,
                    ending = geteducationdetails.Ending,
                    percentage = geteducationdetails.Percentage

                };
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetEducationDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting Education details of all Profiles
        public IEnumerable<Education> GetallEducationDetails()
        {
            try
            {

                return from educations in profileData.GetallEducationDetails() where educations.IsActive == true select educations;



            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetallEducationDetails()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting all the Education details of a Profile using Profile Id
        public IEnumerable<Object> GetAllEducationDetailsByProfileId(int Profileid)
        {
            if (Profileid <= 0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var geteducationdetailsbyprofileid = profileData.GetallEducationDetails().Where(item => item.ProfileId == Profileid && item.IsActive == true).Select(item =>
                 new
                 {
                     educationid = item.EducationId,
                     degree = item.Degree,
                     course = item.Course,
                     college = item.college?.CollegeName,
                     startingyear = item.Starting,
                     endingyear = item.Ending,
                     percentage = item.Percentage

                 }); return geteducationdetailsbyprofileid;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetAllEducationDetailsByProfileId()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting Education details by Education Id 
        public Education GetEducationById(int EducationId)
        {
            try
            {
                if (EducationId <= 0)
                    throw new ArgumentNullException($"ID is not provided{EducationId}");
                Education education = profileData.GetEducationDetailsById(EducationId);
                return education;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetEducationDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }

        }

        //Updation of Education details
        public bool UpdateEducation(Education education)
        {
            if (education == null) throw new ArgumentNullException($" ProfileService:UpdateEducation()-Education values not be null{education}");
            _profileValidate.Educationdetailvalidation(education);
            try
            {
                Education Profile = GetEducationById(education.EducationId);

                if (Profile.Degree != education.Degree)
                    Profile.Degree = education.Degree;
                if (Profile.Course != education.Course)
                    Profile.Course = education.Course;
                if (Profile.CollegeId != education.CollegeId)
                    Profile.CollegeId = education.CollegeId;
                if (Profile.Starting != education.Starting)
                    Profile.Starting = education.Starting;
                if (Profile.Ending != education.Ending)
                    Profile.Ending = education.Ending;
                if (Profile.Percentage != education.Percentage)
                    Profile.Percentage = education.Percentage;
                Profile.UpdatedBy = education.CreatedBy;
                Profile.UpdatedOn = DateTime.Now;

                return profileData.UpdateEducation(Profile);

            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:UpdateEduaction()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }

        //Disable Education details
        public bool DisableEducationalDetails(int EducationalDetailid)
        {
            if (EducationalDetailid <= 0)
                throw new ArgumentNullException($"ID is not provided{EducationalDetailid}");


            try
            {

                return profileData.DisableEducationalDetails(EducationalDetailid) ? true : false;

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:Delete()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }

        //Adding Project details for a Profile
        public bool AddProjects(Projects project)
        {
            if (project == null) throw new ArgumentNullException($"Values cannot be null values are {project}");
            _profileValidate.ProjectDetailvalidation(project);
            try
            {
                project.IsActive = true;
                project.CreatedBy = project.ProfileId;
                project.CreatedOn = DateTime.Now;
                return profileData.AddProjects(project) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:AddProjects()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }


        }

        //Getting Project details of a Profile using Project Id
        public object GetProjectDetailsById(int Projectid)
        {
            if (Projectid <= 0)
                throw new ArgumentNullException($"ID is not provided{Projectid}");
            try
            {
                var getprojectdetails = profileData.GetProjectDetailsById(Projectid);
                return new
                {
                    projectid = getprojectdetails.ProjectId,
                    projectname = getprojectdetails.ProjectName,
                    projectdescription = getprojectdetails.ProjectDescription,
                    startingMonth = getprojectdetails.StartingMonth,
                    startingYear = getprojectdetails.StartingYear,
                    endingMonth = getprojectdetails.EndingMonth,
                    endingYear = getprojectdetails.EndingYear,
                    role = getprojectdetails.Designation,
                    toolsused = getprojectdetails.ToolsUsed,

                };
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetProjectDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting all Project details
        public IEnumerable<Projects> GetallProjectDetails()
        {
            try
            {

                return from projects in profileData.GetallProjectDetails() where projects.IsActive == true select projects;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetallProjectDetails()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting all the Project details of a Profile using Profile Id
        public IEnumerable<Object> GetAllProjectDetailsByProfileId(int Profileid)
        {
            if (Profileid <= 0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {

                var getallprojectdetailsbyprofileid = profileData.GetallProjectDetails().Where(item => item.ProfileId == Profileid && item.IsActive == true).Select(item =>
                 new
                 {

                     projectid = item.ProjectId,
                     projectname = item.ProjectName,
                     projectdescription = item.ProjectDescription,
                     startingMonth = item.StartingMonth,
                     startingYear = item.StartingYear,
                     endingMonth = item.EndingMonth,
                     endingYear = item.EndingYear,
                     role = item.Designation,
                     toolsused = item.ToolsUsed




                 }); return getallprojectdetailsbyprofileid;


            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetAllProjectDetailsByProfileId()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting Project details by Project Id
        public Projects GetProjectById(int ProjectId)
        {
            try
            {
                if (ProjectId <= 0)
                    throw new ArgumentNullException($"ProjectID is invalid{ProjectId}");
                Projects project = profileData.GetProjectDetailsById(ProjectId);
                return project;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetProjectById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }

        }

        //Updation of Project details
        public bool UpdateProjects(Projects projects)
        {
            if (projects == null) throw new ArgumentNullException($" ProfileService:UpdateProjects()-Project values not be null{projects}");
            _profileValidate.ProjectDetailvalidation(projects);
            try
            {
                var Profile = GetProjectById(projects.ProjectId);

                if (Profile.ProjectName != projects.ProjectName)
                    Profile.ProjectName = projects.ProjectName;
                if (Profile.ProjectDescription != projects.ProjectDescription)
                    Profile.ProjectDescription = projects.ProjectDescription;
                if (Profile.StartingMonth != projects.StartingMonth)
                    Profile.StartingMonth = projects.StartingMonth;
                if (Profile.StartingYear != projects.StartingYear)
                    Profile.StartingYear = projects.StartingYear;
                if (Profile.EndingMonth != projects.EndingMonth)
                    Profile.EndingMonth = projects.EndingMonth;
                if (Profile.EndingYear != projects.EndingYear)
                    Profile.EndingYear = projects.EndingYear;
                if (Profile.Designation != projects.Designation)
                    Profile.Designation = projects.Designation;
                if (Profile.ToolsUsed != projects.ToolsUsed)
                    Profile.ToolsUsed = projects.ToolsUsed;

                Profile.IsActive = projects.IsActive;
                Profile.UpdatedBy = projects.CreatedBy;
                Profile.UpdatedOn = DateTime.Now;
                return profileData.UpdateProjects(Profile);

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:UpdateProjects()-{exception.Message}\n{exception.StackTrace}");
                return false;

            }
        }

        //Disable Project details
        public bool DisableProjectDetails(int ProjectDetailid)
        {
            if (ProjectDetailid <= 0)
                throw new ArgumentNullException($"ID is not provided{ProjectDetailid}");


            try
            {

                return profileData.DisableProjectDetails(ProjectDetailid) ? true : false;

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:DisableProjectDetails()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }

        //Adding Skill details for a Profile
        public bool AddSkills(Skills skill)
        {
            if (skill == null) throw new ArgumentNullException($"Values cannot be null values are {skill}");
            _profileValidate.SkillDetailValidation(skill);
            try
            {
                skill.CreatedBy = skill.ProfileId;
                skill.CreatedOn = DateTime.Now;
                return profileData.AddSkills(skill) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:AddSkills()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }


        }

        //Getting Skill details of a Profile using Skill Id
        public object GetSkillDetailsById(int Skillid)
        {
            if (Skillid <= 0)
                throw new ArgumentNullException($"ID is not provided{Skillid}");
            try
            {
                var getskilldetails = profileData.GetSkillDetailsById(Skillid);
                return new
                {
                    skillid = getskilldetails.SkillId,
                    domainname = getskilldetails.domain!.DomainName,
                    technologyname = getskilldetails.technology!.TechnologyName,
                    domainId = getskilldetails.DomainId,
                    technologyId = getskilldetails.TechnologyId
                };
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetSkillDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting all Skill details
        public IEnumerable<Skills> GetallSkillDetails()
        {
            try
            {

                return from skills in profileData.GetallSkillDetails() where skills.IsActive == true select skills;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetallSkillDetails()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting all the Skill details of a Profile using Profile Id
        public IEnumerable<Object> GetAllSkillDetailsByProfileId(int Profileid)
        {
            if (Profileid <= 0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var getallskilldetailsbyprofileid = profileData.GetallSkillDetails().Where(item => item.ProfileId == Profileid && item.IsActive == true).Select(item =>
                new
                {
                    skillid = item.SkillId,
                    domainname = item.domain!.DomainName,
                    technologyname = item.technology!.TechnologyName
                }); return getallskilldetailsbyprofileid;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetAllSkillDetailsByProfileId()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting Skill details by Skill Id
        public Skills GetSkillById(int SkillId)
        {
            try
            {
                if (SkillId <= 0)
                    throw new ArgumentNullException($"SkillID is not provided{SkillId}");
                var skills = profileData.GetSkillDetailsById(SkillId);
                return skills;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetSkillById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }

        }

        //Updation of Skill details
        public bool UpdateSkills(Skills skill)
        {
            if (skill == null) throw new ArgumentNullException($" ProfileService:UpdateSkills()-skill values not be null{skill}");
            _profileValidate.SkillDetailValidation(skill);
            try
            {
                var skills = GetSkillById(skill.SkillId);

                if (skills.DomainId != skill.DomainId)
                    skills.DomainId = skill.DomainId;
                if (skills.TechnologyId != skill.TechnologyId)
                    skills.TechnologyId = skill.TechnologyId;
                skills.UpdatedBy = skill.CreatedBy;
                skills.UpdatedOn = DateTime.Now;

                return profileData.UpdateSkills(skills);
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:UpdateSkills()-{exception.Message}\n{exception.StackTrace}");
                return false;

            }
        }

        //Disable Skill details 
        public bool DisableSkillDetails(int SkillDetailid)
        {
            if (SkillDetailid <= 0)
                throw new ArgumentNullException($"ID is not provided{SkillDetailid}");


            try
            {

                return profileData.DisableSkillDetails(SkillDetailid) ? true : false;

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:DisableSkillDetails()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }

        //Adding Languages known for a Profile
        public bool AddLanguage(Language language)
        {
            if (language == null) throw new ArgumentNullException($"Values cannot be null values are {language}");
            _profileValidate.languageValidation(language);
            try
            {
                language.CreatedBy = language.PersonalDetailsId;
                language.CreatedOn = DateTime.Now;
                return profileData.AddLanguage(language) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:AddLanguage()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }


        }

        //Disable Langugages known
        public bool DisableLanguage(int Languageid)
        {
            if (Languageid <= 0)
                throw new ArgumentNullException($"ID is not provided{Languageid}");


            try
            {

                return profileData.DisableLanguage(Languageid) ? true : false;

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:DisableLanguage()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }

        //Adding Social Media details for a Profile
        public bool AddSocialMedia(SocialMedia media)
        {
            if (media == null) throw new ArgumentNullException($"Values cannot be null values are {media}");
            _profileValidate.SocialMediaDetailValidation(media);
            try
            {
                media.CreatedBy = media.PersonalDetailsId;
                media.CreatedOn = DateTime.Now;
                return profileData.AddSocialMedia(media) ? true : false;
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"ProfileController:AddSocialMedia()-{exception.Message}{exception.StackTrace}");
                throw;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:AddSocialMedia()-{exception.Message}\n{exception.StackTrace}");
                throw;
            }


        }

        //Disable Social Media details
        public bool DisableSocialMedia(int SocialMediaid)
        {
            if (SocialMediaid <= 0)
                throw new ArgumentNullException($"ID is not provided{SocialMediaid}");


            try
            {

                return profileData.DisableSocialMedia(SocialMediaid) ? true : false;

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:DisableSocialMedia()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }

        //Getting Technology by Technology Id
        public object GetTechnologyById(int Technologyid)
        {
            if (Technologyid <= 0)
                throw new ArgumentNullException($"ID is not provided{Technologyid}");
            try
            {
                var gettechnologydetails = profileData.GetTechnologyById(Technologyid);
                return new
                {
                    technologyname = gettechnologydetails.TechnologyName
                };
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetTechnologyById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting list of Technologies
        public IEnumerable<Technology> GetallTechnologies()
        {
            try
            {
                return from Technologies in profileData.GetallTechnologies() where Technologies.IsActive == true select Technologies;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetallTechnologies()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Adding Achievement details for a Profile
        public bool AddAchievements(Achievements achievement)
        {
            if (achievement == null) throw new ArgumentNullException($"Values cannot be null values are {achievement}");
            _profileValidate.AchievementValidation(achievement);
            try
            {
                string Imagedate = "";
                Imagedate = ImageService.Getbase64String(achievement.base64header!);
                achievement.base64header = ImageService.Getbase64Header(achievement.base64header!);
                achievement.AchievementImage = System.Convert.FromBase64String(Imagedate);


                achievement.CreatedOn = DateTime.Now;
                return profileData.AddAchievements(achievement) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:AddAchievements()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }


        }

        //Getting Achievement details of all Profiles
        public IEnumerable<Achievements> GetallAchievements()
        {
            try
            {
                return from achievements in profileData.GetallAchievements() where achievements.IsActive == true select achievements;
            }
            catch (Exception exception)
            {
                // Log Exception occured in DAL while fetching users
                _logger.LogError($"ProfileService:GetallAchievements()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting all the Achievement details of a Profile using Profile Id
        public IEnumerable<Object> GetAllAchievementDetailsByProfileId(int Profileid)
        {
            if (Profileid <= 0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var getachievementsbypersonalid = profileData.GetallAchievements().Where(item => item.ProfileId == Profileid && item.IsActive == true).Select(item =>
                 new
                 {
                     achievementid = item.AchievementId,
                     achievementtype = item.achievementtype!.AchievementTypeName,
                     achievementimage = item.AchievementImage

                 }); return getachievementsbypersonalid;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetAllAchievementDetailsByProfileId()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Disable Achievement details
        public bool DisableAchievement(int achievementId)
        {
            if (achievementId <= 0)
                throw new ArgumentNullException($"Achievement ID is not provided{achievementId}");


            try
            {

                return profileData.DisableAchievement(achievementId) ? true : false;

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"ProfileService:DisableAchievement()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }

        //Getting all Profile details
        public IEnumerable<Profile> GetallProfiles()
        {
            try
            {
                var result = from profile in profileData.GetallProfiles() where profile.IsActive == true select profile;
                return result;


            }
            catch (Exception exception)
            {

                _logger.LogError($"ProfileService:GetallProfiles()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting Status of a Profile using Profile Id
        public object GetProfileStatusByProfileId(int Profileid)
        {
            if (Profileid <= 0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                return profileData.GetProfileStatusByProfileId(Profileid);
            }
            catch (Exception exception)
            {

                _logger.LogError($"ProfileService:GetProfileStatusByProfileId()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting Profile details of a Profile using Profile Id
        public object GetProfileById(int Profileid)
        {
            if (Profileid <= 0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var getviewdetails =
                new
                {
                    personaldetails = GetPersonalDetailsByProfileId(Profileid),
                    educationdetails = GetAllEducationDetailsByProfileId(Profileid),
                    projectdetails = GetAllProjectDetailsByProfileId(Profileid),
                    skilldetails = GetAllSkillDetailsByProfileId(Profileid),
                    achievementdetails = GetAllAchievementDetailsByProfileId(Profileid),
                    profilestatus = GetProfileStatusByProfileId(Profileid),
                    // updateddate=profileData.GetProfileById(Profileid).UpdatedOn

                };
                //); 
                return getviewdetails;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetProfileById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting Specific user details of a Profile
        public object GetSpecificProfile()
        {

            try
            {
                var getprofile = profileData.GetallProfiles().Select(item =>
                new
                {
                    Status = item.profilestatus!.ProfileStatusName,
                    Name = item.personalDetails!.users!.Name,
                    Designation = item.personalDetails.users.designation!.DesignationName,
                    ReportingPerson = item.personalDetails.users.ReportingPersonUsername,



                }); return getprofile;

            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetSpecificProfile()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Getting Profile Id by the logged in user's User Id
        public object GetProfileIdByUserId(int Userid)
        {
            if (Userid <= 0)
                throw new ArgumentNullException($"ID is not provided{Userid}");
            try
            {
                var getprofile = profileData.GetProfileIdByUserId(Userid);
                if(getprofile==null){
                    return new
                    {
                        profileId = 0
                    };
                }
                if (getprofile.IsActive)
                {
                    return new
                    {
                        profilestatus = getprofile.profilestatus!.ProfileStatusName,
                        profileId = getprofile.ProfileId,
                        updateddate=getprofile.UpdatedOn
                    };
                }
                return getprofile;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetProfileIdByUserId()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }

        }

        //Getting Count of Profiles
        public object GetProfileCount(int currentdesignation)
        {
            try
            {
                var result = profileData.GetProfileCount(currentdesignation) ;
                return result;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetProfileCount()-{exception.Message}\n{exception.StackTrace}");

                throw exception;
            }

        }

        //Getting Profiles based on Filters applied
        public object GetFilteredProfile(string userName, int designationId, int domainID, int technologyId, int collegeId, int profileStatusId,int currentdesignation)
        {

            try
            {
                
                return profileData.GetFilteredProfile(userName,designationId, domainID, technologyId, collegeId, profileStatusId,currentdesignation)
                .Select(user => new
                {
                    profileId = user.profile!.ProfileId,
                    profileStatus = user.profile.profilestatus!.ProfileStatusName,
                    name = user.Name,
                    designation = user.designation!.DesignationName,
                    userId=user.UserId,
                    repotingPerson = user.ReportingPersonUsername,
                    image = user.personalDetails != null ? user.personalDetails.Image : null
                });
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService : GetFilteredProfile()-{exception.Message}\n{exception.StackTrace}");
                throw;
            }
        }

        //Accepting or Rejecting of a Profile
        public bool AcceptOrRejectProfile(int profileId, int response)
        {
            if (profileId <= 0)
                throw new ValidationException($"ProfileId cannot be negative:");

            try
            {
                return profileData.AcceptOrRejectProfile(profileId, response) ? true : false;
            }
            catch (ValidationException exception)
            {
                _logger.LogError($"ProfileService:AcceptOrRejectProfile()-{exception.Message}\n{exception.StackTrace}");
                throw;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:AcceptOrRejectProfile()-{exception.Message}\n{exception.StackTrace}");
                throw;
            }
        }

        //Updation of Profile Status to Waiting when Edit Profile is activated
        public bool updateProfileStatus(Profile profile)
        {
            if (profile == null)
                throw new ValidationException("profileId is Invalid");
            try
            {
                Profile result = profileData.GetProfile(profile.ProfileId);
                if (profile.UserId != result.UserId)
                    throw new ValidationException("User does not exist");

                result.ProfileStatusId = 2;
                result.UpdatedOn = DateTime.Now;

                return profileData.updateProfileStatus(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:updateProfileStatus()-{exception.Message}\n{exception.StackTrace}");
                throw;
            }
        }
    }
}