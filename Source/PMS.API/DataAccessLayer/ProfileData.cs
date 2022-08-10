using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace PMS_API
{
    public interface IProfileData
    {
        bool AddProfile(Profile profile);
        bool AddPersonalDetail(PersonalDetails personalDetails);
        List<PersonalDetails> GetAllPersonalDetails();
        PersonalDetails GetPersonalDetailsById(int Personalid);

        bool UpdatePersonalDetail(PersonalDetails personalDetails);
        bool DisablePersonalDetails(int PersonalDetailsid);

        bool AddEducation(Education education);
        List<Education> GetallEducationDetails();
        Education GetEducationDetailsById(int Educationid);
        bool UpdateEducation(Education education);
        bool DisableEducationalDetails(int Educationid);

        bool AddProjects(Projects project);
        List<Projects> GetallProjectDetails();
        Projects GetProjectDetailsById(int Projectid);
        bool UpdateProjects(Projects projects);
        bool DisableProjectDetails(int Projectid);

        bool AddSkills(Skills skill);
        List<Skills> GetallSkillDetails();
        Skills GetSkillDetailsById(int Skillid);
        bool UpdateSkills(Skills skill);
        bool DisableSkillDetails(int Skillid);

        bool AddAchievements(Achievements achievements);
        List<Achievements> GetallAchievements();

        bool DisableAchievement(int AchievementId);

        bool AddLanguage(Language language);
        bool DisableLanguage(int Languageid);

        bool AddSocialMedia(SocialMedia media);
        bool DisableSocialMedia(int SocialMediaid);


        Technology GetTechnologyById(int Technologyid);
        List<Technology> GetallTechnologies();


        public List<Profile> GetallProfiles();
        Profile GetProfileById(int ProfileId);
        public ProfileStatus GetProfileStatusByProfileId(int Profileid);
        public List<User> GetFilteredProfile(string userName, int designationId, int domainID, int technologyId, int collegeId, int profileStatusId, int currentdesignation);


    }

    public class ProfileData : IProfileData
    {
        private readonly Context _context;
        private readonly ILogger<ProfileService> _logger;
        private static ProfileValidation _profileValidate = ProfileDataFactory.GetProfileVaidationObject();


        
        public ProfileData(Context context, ILogger<ProfileService> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Adding a Profile
        public bool AddProfile(Profile profile)
        {


            if (profile == null)
                throw new ArgumentException("PersonalDetails object is not provided to DAL");

            try
            {
                _context.profile!.Add(profile);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                //log "unknown exception occured"
                _logger.LogError($"ProfileData-AddProfile()-{exception.Message}");
                _logger.LogInformation($"ProfileData-AddProfile()-{exception.StackTrace}");

                return false;
            }


        }

        //Getting Personal details of all Profiles
        public List<PersonalDetails> GetAllPersonalDetails()
        {

            try
            {
                return _context.personalDetails!.Include(s => s.language).Include(s => s.breakDuration).Include(s => s.socialmedia).ToList();


            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetallPersonalDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallPersonalDetails()-{exception.StackTrace}");
                throw;
            }
        }

        //Getting Personal detail of a Profile using Pesronal details Id
        public PersonalDetails GetPersonalDetailsById(int Personalid)
        {

            if (Personalid <= 0)

                throw new ValidationException("Profile Id is not provided to DAL");

            try
            {
                var personalDetails = GetAllPersonalDetails().FirstOrDefault(x => x.PersonalDetailsId == Personalid);
                if (personalDetails == null) throw new ArgumentNullException($"Id not found-{Personalid}");
                return personalDetails;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetPersonalDetailsById()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetPersonalDetailsById()-{exception.StackTrace}");
                throw;
            }
        }

        //Adding Personal details for a Profile
        public bool AddPersonalDetail(PersonalDetails personalDetails)
        {

            _profileValidate.PersonalDetailsvalidate(personalDetails);

            if (personalDetails == null)
                throw new ArgumentException("PersonalDetails object is not provided to DAL");

            try
            {
                personalDetails.IsActive = true;
                _context.personalDetails.Add(personalDetails);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                //log "unknown exception occured"
                _logger.LogError($"ProfileData-AddPersonalDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData-AddPersonalDetails()-{exception.StackTrace}");

                return false;
            }
        }

        //Updation of Personal details
        public bool UpdatePersonalDetail(PersonalDetails personalDetails)
        {
            _profileValidate.PersonalDetailsvalidate(personalDetails);
            if (personalDetails == null)
                throw new ValidationException("Profile's personal detail is not provided to DAL");

            try
            {
                _context.personalDetails!.Update(personalDetails);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-UpdatePersonalDetail()-{exception.Message}");
                _logger.LogInformation($"ProfileData-UpdatePersonalDetail()-{exception.StackTrace}");
                return false;
            }

        }

        //Disable Personal details
        public bool DisablePersonalDetails(int PersonalDetailsid)
        {
            if (PersonalDetailsid <= 0)
                throw new ValidationException("PersonalDetails Id is not provided to DAL");

            try
            {
                var personalDetails = _context.personalDetails!.Find(PersonalDetailsid);
                if (personalDetails == null) throw new ArgumentNullException($"PersonalDetails Id not found{PersonalDetailsid}");
                personalDetails.IsActive = false;
                _context.personalDetails.Update(personalDetails);
                _context.SaveChanges();
                return true;

            }


            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData-DisablePersonalDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData-DisablePersonalDetails()-{exception.StackTrace}");
                return false;
            }

        }

        //Getting Education details of all Profiles
        public List<Education> GetallEducationDetails()
        {

            try
            {

                return _context.educations!.Include("college").ToList();

            }

            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData-GetallEducationDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallEducationDetails()-{exception.StackTrace}");
                throw;
            }
        }

         //Getting Education details of a Profile using Education Id
        public Education GetEducationDetailsById(int Educationid)
        {
            if (Educationid <= 0)

                throw new ValidationException("Education Id is not provided to DAL");

            try
            {
                var education = GetallEducationDetails().First(x => x.EducationId == Educationid && x.IsActive);
                if (education == null) throw new ArgumentNullException($"Id not found-{Educationid}");
                return education;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetEducationDetailsById()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetEducationDetailsById()-{exception.StackTrace}");
                throw;
            }
        }

        //Adding Education details for a Profile
        public bool AddEducation(Education education)
        {

            _profileValidate.Educationdetailvalidation(education);
            if (education == null)
                throw new ArgumentException("Education detail object is not provided to DAL");


            try
            {               
                education.IsActive = true;
                _context.educations!.Add(education);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                //log "unknown exception occured"
                _logger.LogError($"ProfileData-AddEducation()-{exception.Message}");
                _logger.LogInformation($"ProfileData-AddEducation()-{exception.StackTrace}");
                throw;
            }
        }

        //Updation of Education details
        public bool UpdateEducation(Education education)
        {
            _profileValidate.Educationdetailvalidation(education);
            if (education == null)
                throw new ValidationException("Profile's education details are not provided to DAL");
            try
            {
                _context.educations!.Update(education);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                //log " exception occures"
                _logger.LogError($"ProfileData-UpdateEducation()-{exception.Message}");
                _logger.LogInformation($"ProfileData-UpdateEducaion()-{exception.StackTrace}");
                return false;
            }

        }

        //Disable Education details
        public bool DisableEducationalDetails(int Educationid)
        {
            if (Educationid <= 0)

                throw new ValidationException("Education Id is not provided to DAL");

            try
            {
                var education = _context.educations!.Find(Educationid);
                if (education == null) throw new ArgumentNullException($"Education Id not found{Educationid}");
                education.IsActive = false;
                _context.educations.Update(education);
                _context.SaveChanges();
                return true;

            }


            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-DisableEducationDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileDate.cs-DisableEducationDetails()-{exception.StackTrace}");
                return false;
            }

        }

        //Adding Project details for a Profile
        public bool AddProjects(Projects project)
        {
            if (project == null)
                throw new ArgumentException("project detail object is not provided to DAL");
            _profileValidate.ProjectDetailvalidation(project);
            try
            {
                project.IsActive = true;
                _context.projects!.Add(project);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-AddProjects()-{exception.Message}");
                _logger.LogInformation($"ProfileData-AddProjects()-{exception.StackTrace}");

                return false;
            }


        }

        //Getting all Project details
        public List<Projects> GetallProjectDetails()
        {

            try
            {

                return _context.projects!.ToList();

            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetallProjectDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallProjectDetails()-{exception.StackTrace}");
                throw;
            }
        }

        //Getting Project details of a Profile using Project Id
        public Projects GetProjectDetailsById(int Projectid)
        {
            if (Projectid <= 0)

                throw new ValidationException("Project Id is not provided to DAL");

            try
            {
                var project = GetallProjectDetails().First(x => x.ProjectId == Projectid && x.IsActive);
                if (project == null) throw new ArgumentNullException($"Id not found-{Projectid}");
                return project;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetProjectDetailsById()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetProjectDetailsById()-{exception.StackTrace}");
                throw;
            }
        }

        //Updation of Project details
        public bool UpdateProjects(Projects projects)
        {
            
            if (projects == null)
                throw new ValidationException("Profile's Project details are not provided to DAL");
            _profileValidate.ProjectDetailvalidation(projects);

            try
            {
                projects.IsActive = true;
                _context.projects!.Update(projects);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-UpdateProjects()-{exception.Message}");
                _logger.LogInformation($"ProfileData-UpdateProjects()-{exception.StackTrace}");
                return false;
            }

        }

        //Disable Project details
        public bool DisableProjectDetails(int Projectid)
        {
            if (Projectid <= 0)

                throw new ValidationException("Project Id is not provided to DAL");

            try
            {
                var projects = _context.projects!.Find(Projectid);
                if (projects == null)
                    throw new ArgumentNullException($"Project Id not found{Projectid}");

                projects.IsActive = false;
                _context.projects.Update(projects);
                _context.SaveChanges();
                return true;

            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-DisableProjectDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData-DisableProjectDetails()-{exception.StackTrace}");
                return false;
            }

        }

        //Adding Skill details for a Profile
        public bool AddSkills(Skills skill)
        {


            if (skill == null)
                throw new ArgumentException("Skill detail object is not provided to DAL");
            _profileValidate.SkillDetailValidation(skill);
            try
            {
                skill.IsActive = true;
                _context.skills!.Add(skill);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-AddSkills()-{exception.Message}");
                _logger.LogInformation($"ProfileData-AddSkills()-{exception.StackTrace}");

                return false;
            }


        }

        //Getting all Skill details
        public List<Skills> GetallSkillDetails()
        {

            try
            {

                return _context.skills!.Include("domain").Include("technology").ToList();

            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetallSkillDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallSkillDetails()-{exception.StackTrace}");
                throw;
            }
        }

        //Getting Skill details of a Profile using Skill Id
        public Skills GetSkillDetailsById(int Skillid)
        {
            if (Skillid <= 0)

                throw new ValidationException("Skill Id is not provided to DAL");

            try
            {
                var skills = GetallSkillDetails().First(x => x.SkillId == Skillid && x.IsActive);
                if (skills == null) throw new ArgumentNullException($"Id not found-{Skillid}");
                return skills;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetSkillDetailsById()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetSkillDetailsById()-{exception.StackTrace}");
                throw;
            }
        }

        //Updation of Skill details
        public bool UpdateSkills(Skills skill)
        {
            
            if (skill == null)
                throw new ValidationException("Profile's skilldetails are not provided to DAL");
            _profileValidate.SkillDetailValidation(skill);
            try
            {
                skill.IsActive = true;
                _context.skills!.Update(skill);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-UpdateSkill()-{exception.Message}");
                _logger.LogInformation($"ProfileData-UpdateSkill()-{exception.StackTrace}");
                return false;
            }
        }

        //Disable Skill details
        public bool DisableSkillDetails(int Skillid)
        {
            if (Skillid <= 0)

                throw new ValidationException("Skill Id is not provided to DAL");

            try
            {
                var skills = _context.skills!.Find(Skillid);
                if (skills == null) throw new ArgumentNullException($"Skill Id not found{Skillid}");
                skills.IsActive = false;
                _context.skills.Update(skills);
                _context.SaveChanges();
                return true;

            }


            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-DisableSkillDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData-DisableSkillDetails()-{exception.StackTrace}");
                return false;
            }

        }

        //Adding Languages known for a Profile
        public bool AddLanguage(Language language)
        {

            
            if (language == null)
                throw new ArgumentException("Language details object is not provided to DAL");
            _profileValidate.languageValidation(language);
            try
            {
                language.IsActive=true;
                _context.languages!.Add(language);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-AddLanguage()-{exception.Message}");
                _logger.LogInformation($"ProfileData-AddLanguage()-{exception.StackTrace}");

                return false;
            }


        }

        //Disable Langugages known
        public bool DisableLanguage(int Languageid)
        {
            if (Languageid <= 0)

                throw new ValidationException("Language Id is not provided to DAL");

            try
            {
                var languages = _context.languages!.Find(Languageid);
                if (languages == null) throw new ArgumentNullException($"Language Id not found{Languageid}");
                languages.IsActive = false;
                _context.languages.Update(languages);
                _context.SaveChanges();
                return true;

            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-DisableLanguage()-{exception.Message}");
                _logger.LogInformation($"ProfileData-DisableLanguage()-{exception.StackTrace}");
                return false;
            }

        }

        //Adding Social Media details for a Profile
        public bool AddSocialMedia(SocialMedia media)
        {

            if (media == null)
                throw new ArgumentException("social media details object is not provided to DAL");
            _profileValidate.SocialMediaDetailValidation(media);
            try
            {
                media.IsActive=true;
                _context.SocialMedias!.Add(media);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-AddSocialMedia()-{exception.Message}");
                _logger.LogInformation($"ProfileData-AddSocialMedia()-{exception.StackTrace}");

                return false;
            }
        }

        //Disable Social Media details
        public bool DisableSocialMedia(int SocialMediaid)
        {
            if (SocialMediaid <= 0)

                throw new ValidationException("SocialMedia Id is not provided to DAL");

            try
            {
                var SocialMedias = _context.SocialMedias!.Find(SocialMediaid);
                if (SocialMedias == null) throw new ArgumentNullException($"SocialMedia Id not found{SocialMediaid}");
                SocialMedias.IsActive = false;
                _context.SocialMedias.Update(SocialMedias);
                _context.SaveChanges();
                return true;

            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-DisableSocialMedia()-{exception.Message}");
                _logger.LogInformation($"ProfileData-DisableSocialMedia()-{exception.StackTrace}");
                return false;
            }

        }

        //Getting list of Technologies
        public List<Technology> GetallTechnologies()
        {

            try
            {

                return _context.Technologies!.ToList();

            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetallTechnologies()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallTechnologies()-{exception.StackTrace}");
                throw;
            }
        }

        //Getting Technology by Technology Id
        public Technology GetTechnologyById(int Technologyid)
        {
            if (Technologyid <= 0)

                throw new ValidationException("Technology Id is not provided to DAL");

            try
            {
                Technology technology = GetallTechnologies().First(x => x.TechnologyId == Technologyid && x.IsActive);
                if (technology == null) throw new ArgumentNullException($"Id not found-{technology}");
                return technology;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetTechnologyById()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetTechnologyById()-{exception.StackTrace}");
                throw;
            }
        }

        //Adding Achievement details for a Profile
        public bool AddAchievements(Achievements achievements)
        {
            if (achievements == null)
                throw new ArgumentException("Social media details object is not provided to DAL");
            _profileValidate.AchievementValidation(achievements);
            try
            {
                achievements.IsActive = true;
                _context.achievements!.Add(achievements);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {

                _logger.LogError($"ProfileData-AddAchievements()-{exception.Message}");
                _logger.LogInformation($"ProfileData-AddAchievements()-{exception.StackTrace}");

                return false;
            }
        }

        //Getting Achievement details of all Profiles
        public List<Achievements> GetallAchievements()
        {

            try
            {

                return _context.achievements!.Include("achievementtype").ToList();

            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetallAchievements()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallAchievements()-{exception.StackTrace}");
                throw;
            }
        }

        //Disable Achievement details
        public bool DisableAchievement(int AchievementId)
        {
            if (AchievementId <= 0)

                throw new ArgumentException("achievement Id is not provided to DAL");

            try
            {
                var achievement = _context.achievements!.Find(AchievementId);
                if (achievement == null) throw new ArgumentNullException($"SocialMedia Id not found{AchievementId}");
                achievement.IsActive = false;
                _context.achievements.Update(achievement);
                _context.SaveChanges();
                return true;

            }


            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-DisableAchievement()-{exception.Message}");
                _logger.LogInformation($"ProfileData-DisableAchievement()-{exception.StackTrace}");
                return false;
            }

        }

        //Getting all Profile details
        public List<Profile> GetallProfiles()
        {

            try
            {
                var result = _context.profile!.Include("personalDetails").Include("education").Include("projects").Include("skills").Include("achievements").Include(e => e.profilestatus).Include("user").ToList();
                return result;
            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetallProfile()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallProfile()-{exception.StackTrace}");
                throw;
            }
        }

        //Getting Status of a Profile using Profile Id
        public ProfileStatus GetProfileStatusByProfileId(int Profileid)
        {
            if (Profileid <= 0)

                throw new ValidationException("Profile id is not provided to DAL");
            try
            {

                return _context.profile!.Where(x => x.ProfileId == Profileid).Include(p => p.profilestatus).Select(p => p.profilestatus).First()!;
            }
            catch
            {
                System.Console.WriteLine("error");
                throw;
            }

        }

        //Getting Profile details of a Profile using Profile Id
        public Profile GetProfileById(int ProfileId)
        {
            if (ProfileId <= 0)

                throw new ArgumentException("Profile id is not provided to DAL");

            try
            {

                Profile profile = GetallProfiles().First(x => x.ProfileId == ProfileId && x.IsActive);
                if (profile == null) throw new ArgumentNullException($"Id not found-{ProfileId}");
                return profile;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetProfileById()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetProfileById()-{exception.StackTrace}");
                throw;
            }
        }

        //Getting Profile Id by the logged in user's User Id
        public Profile GetProfileIdByUserId(int Userid)
        {
            if (Userid <= 0)
                throw new ArgumentException("User id is not provided to DAL");
            try
            {
                Profile profile=_context.profile!.Include(e => e.profilestatus).FirstOrDefault(x => x.UserId == Userid)!;
                return profile;
            }
            catch (Exception)
            {
                System.Console.WriteLine("error");
                throw;
            }
        }

        //Getting Profiles based on Filters applied
        public List<User> GetFilteredProfile(string userName, int designationId, int domainID, int technologyId, int collegeId, int profileStatusId,int currentdesignation)
        {
            try
            {
                return _context.users!
                   .Include(e => e.designation)
                   .Include(e => e.profile)
                   .Include(e => e.profile!.personalDetails)
                   .Include(e => e.profile!.profilestatus)
                   .Where(user => user.profile != null && user.DesignationId > currentdesignation  && user.personalDetails != null)
                   .WhereIf(String.IsNullOrEmpty(userName) == false, users =>users.DesignationId > currentdesignation && users.Name!.Contains(userName) == true)
                   .WhereIf(designationId != 0,users => users.DesignationId > currentdesignation && users.DesignationId == designationId)
                   .WhereIf(domainID != 0, users => users.DesignationId > currentdesignation && users.profile!.skills!.Any(s => s.DomainId == domainID) == true)
                   .WhereIf(technologyId != 0, users => users.DesignationId > currentdesignation && users.profile!.skills!.Any(s => s.TechnologyId == technologyId) == true)
                   .WhereIf(collegeId != 0, users => users.DesignationId > currentdesignation && users.profile!.education!.Any(s => s.CollegeId == collegeId) == true)
                   .WhereIf(profileStatusId != 0, users => users.DesignationId > currentdesignation && users.profile!.ProfileStatusId == profileStatusId)
                   .ToList(); 
                
            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetFilteredProfile()-{exception.Message}");
                throw;
            }
        }

        //Accepting or Rejecting of a Profile
        public bool AcceptOrRejectProfile(int profileId, int response)
        {
            if (profileId <= 0)
                throw new ValidationException("Profile Id cannot be negative in DAL");

            try
            {
                Profile status = _context.profile!.Find(profileId)!;
                if (response == 2)
                    throw new ValidationException("Cannot change to waiting for approval");
                else if (status.ProfileStatusId.Equals(1) || status.ProfileStatusId.Equals(3))
                    throw new ValidationException("Profile Status already Updated");
                status.ProfileStatusId = response;
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-AcceptOrRejectProfile()-{exception.Message}");
                _logger.LogInformation($"ProfileData-AcceptOrRejectProfile()-{exception.StackTrace}");
                throw;
            }

        }

        //Getting a Profile using Profile Id
        public Profile GetProfile(int ProfileId)
        {

            if (ProfileId <= 0)

                throw new ArgumentException("Profile id is not provided to DAL");

            try
            {
                return _context.profile!.Find(ProfileId)!;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetProfile()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetProfile()-{exception.StackTrace}");
                throw;
            }
        }

        //Updation of Profile Status to Waiting when Edit Profile is activated
        public bool updateProfileStatus(Profile profile)
        {
            if (profile == null || profile.ProfileId <= 0 || profile.UserId <= 0)
                throw new ValidationException("profileId should not null");

            if (_context.profile!.Any(e => e.ProfileId.Equals(profile.ProfileId)))
                throw new ValidationException("Profile does not exists");
            try
            {
                _context.profile!.Update(profile);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-updateProfileStatus()-{exception.Message}");
                _logger.LogInformation($"ProfileData-updateProfileStatus()-{exception.StackTrace}");
                throw;
            }
        }

        //Getting Count of Profiles
        public object GetProfileCount(int currentdesignation)
        {
            try{
                var result=_context.profile;
                var Approved = result!.Where(p => p.ProfileStatusId == 1 && p.user!.DesignationId>currentdesignation).Count();
                var Rejected = result!.Where(p => p.ProfileStatusId == 3  && p.user!.DesignationId>currentdesignation).Count();
                var Waiting = result!.Where(p => p.ProfileStatusId == 2  && p.user!.DesignationId>currentdesignation).Count();
                var total = result!.Where(p => p.user!.DesignationId>currentdesignation).Count();
                var ans = new Dictionary<string, int>();
                ans.Add("ApprovedProfiles", Approved);
                ans.Add("RejectedProfiles", Rejected);
                ans.Add("WaitingProfiles", Waiting);
                ans.Add("TotalProfiles", total);
                return ans;

            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileService:GetProfileCount()-{exception.Message}\n{exception.StackTrace}");
                throw;
            }
        }

    }


}


