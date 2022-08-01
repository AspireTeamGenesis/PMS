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

        public ProfileData(Context context, ILogger<ProfileService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public bool AddProfile(Profile profile)
        {
            profile.IsActive = true;


            if (profile == null)
                throw new ArgumentNullException("PersonalDetails object is not provided to DAL");

            try
            {
                profile.IsActive = true;
                _context.profile.Add(profile);
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
        public List<PersonalDetails> GetAllPersonalDetails()
        {

            try
            {
                return _context.personalDetails.Include(s => s.language).Include(s => s.breakDuration).Include(s => s.socialmedia).ToList();


            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetallPersonalDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallPersonalDetails()-{exception.StackTrace}");
                throw exception;
            }
        }
        public PersonalDetails GetPersonalDetailsById(int Personalid)
        {

            if (Personalid <= 0)

                throw new ValidationException("Profile Id is not provided to DAL");

            try
            {
                var personalDetails = GetAllPersonalDetails().Where(x => x.PersonalDetailsId == Personalid).FirstOrDefault();
                if (personalDetails == null) throw new Exception($"Id not found-{Personalid}");
                return personalDetails;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetPersonalDetailsById()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetPersonalDetailsById()-{exception.StackTrace}");
                throw exception;
            }
        }

        public bool AddPersonalDetail(PersonalDetails personalDetails)
        {


            if (personalDetails == null)
                throw new ArgumentNullException("PersonalDetails object is not provided to DAL");

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
        public bool UpdatePersonalDetail(PersonalDetails personalDetails)
        {
            if (personalDetails == null)
                throw new ValidationException("Profile's personal detail is not provided to DAL");

            try
            {
                _context.personalDetails.Update(personalDetails);
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

        public bool DisablePersonalDetails(int PersonalDetailsid)
        {
            if (PersonalDetailsid <= 0)
                throw new ValidationException("PersonalDetails Id is not provided to DAL");

            try
            {
                var personalDetails = _context.personalDetails.Find(PersonalDetailsid);
                if (personalDetails == null) throw new NullReferenceException($"PersonalDetails Id not found{PersonalDetailsid}");
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
        public List<Education> GetallEducationDetails()
        {

            try
            {

                return _context.educations.Include("college").ToList();

            }

            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData-GetallEducationDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallEducationDetails()-{exception.StackTrace}");
                throw exception;
            }
        }
        public Education GetEducationDetailsById(int Educationid)
        {
            if (Educationid <= 0)

                throw new ValidationException("Education Id is not provided to DAL");

            try
            {
                var education = GetallEducationDetails().Where(x => x.EducationId == Educationid && x.IsActive).First();
                if (education == null) throw new NullReferenceException($"Id not found-{Educationid}");
                return education;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetEducationDetailsById()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetEducationDetailsById()-{exception.StackTrace}");
                throw exception;
            }
        }

        public bool AddEducation(Education education)
        {


            if (education == null)
                throw new ArgumentNullException("Education detail object is not provided to DAL");


            try
            {               
                education.IsActive = true;
                _context.educations.Add(education);
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
        public bool UpdateEducation(Education education)
        {
            if (education == null)
                throw new ValidationException("Profile's education details are not provided to DAL");
            try
            {
                _context.educations.Update(education);
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


        public bool DisableEducationalDetails(int Educationid)
        {
            if (Educationid <= 0)

                throw new ValidationException("Education Id is not provided to DAL");

            try
            {
                var education = _context.educations.Find(Educationid);
                if (education == null) throw new NullReferenceException($"Education Id not found{Educationid}");
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
        public bool AddProjects(Projects project)
        {


            if (project == null)
                throw new ArgumentNullException("project detail object is not provided to DAL");

            try
            {
                project.IsActive = true;
                _context.projects.Add(project);
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
        public List<Projects> GetallProjectDetails()
        {

            try
            {

                return _context.projects.ToList();

            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetallProjectDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallProjectDetails()-{exception.StackTrace}");
                throw exception;
            }
        }
        public Projects GetProjectDetailsById(int Projectid)
        {
            if (Projectid <= 0)

                throw new ValidationException("Project Id is not provided to DAL");

            try
            {
                var project = GetallProjectDetails().Where(x => x.ProjectId == Projectid && x.IsActive).First();
                if (project == null) throw new NullReferenceException($"Id not found-{Projectid}");
                return project;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetProjectDetailsById()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetProjectDetailsById()-{exception.StackTrace}");
                throw exception;
            }
        }
        public bool UpdateProjects(Projects projects)
        {
            if (projects == null)
                throw new ValidationException("Profile's Project details are not provided to DAL");


            try
            {
                projects.IsActive = true;
                _context.projects.Update(projects);
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
        public bool DisableProjectDetails(int Projectid)
        {
            if (Projectid <= 0)

                throw new ValidationException("Project Id is not provided to DAL");

            try
            {
                var projects = _context.projects.Find(Projectid);
                if (projects == null)
                    throw new NullReferenceException($"Project Id not found{Projectid}");

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
        public bool AddSkills(Skills skill)
        {


            if (skill == null)
                throw new ArgumentNullException("Skill detail object is not provided to DAL");

            try
            {
                skill.IsActive = true;
                _context.skills.Add(skill);
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
        public List<Skills> GetallSkillDetails()
        {

            try
            {

                return _context.skills.Include("domain").Include("technology").ToList();

            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetallSkillDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallSkillDetails()-{exception.StackTrace}");
                throw exception;
            }
        }
        public Skills GetSkillDetailsById(int Skillid)
        {
            if (Skillid <= 0)

                throw new ValidationException("Skill Id is not provided to DAL");

            try
            {
                var skills = GetallSkillDetails().Where(x => x.SkillId == Skillid && x.IsActive).First();
                if (skills == null) throw new NullReferenceException($"Id not found-{Skillid}");
                return skills;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetSkillDetailsById()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetSkillDetailsById()-{exception.StackTrace}");
                throw exception;
            }
        }
        public bool UpdateSkills(Skills skill)
        {
            if (skill == null)
                throw new ValidationException("Profile's skilldetails are not provided to DAL");
            try
            {
                skill.IsActive = true;
                _context.skills.Update(skill);
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
        public bool DisableSkillDetails(int Skillid)
        {
            if (Skillid <= 0)

                throw new ValidationException("Skill Id is not provided to DAL");

            try
            {
                var skills = _context.skills.Find(Skillid);
                if (skills == null) throw new NullReferenceException($"Skill Id not found{Skillid}");
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
        public bool AddLanguage(Language language)
        {


            if (language == null)
                throw new ArgumentNullException("Language details object is not provided to DAL");

            try
            {
                language.IsActive=true;
                _context.languages.Add(language);
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
        public bool DisableLanguage(int Languageid)
        {
            if (Languageid <= 0)

                throw new ValidationException("Language Id is not provided to DAL");

            try
            {
                var languages = _context.languages.Find(Languageid);
                if (languages == null) throw new NullReferenceException($"Language Id not found{Languageid}");
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
        public bool AddSocialMedia(SocialMedia media)
        {
            if (media == null)
                throw new ArgumentNullException("social media details object is not provided to DAL");
            try
            {
                media.IsActive=true;
                _context.SocialMedias.Add(media);
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
        public bool DisableSocialMedia(int SocialMediaid)
        {
            if (SocialMediaid <= 0)

                throw new ValidationException("SocialMedia Id is not provided to DAL");

            try
            {
                var SocialMedias = _context.SocialMedias.Find(SocialMediaid);
                if (SocialMedias == null) throw new NullReferenceException($"SocialMedia Id not found{SocialMediaid}");
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
        public List<Technology> GetallTechnologies()
        {

            try
            {

                return _context.Technologies.ToList();

            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetallTechnologies()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallTechnologies()-{exception.StackTrace}");
                throw exception;
            }
        }

        public Technology GetTechnologyById(int Technologyid)
        {
            if (Technologyid <= 0)

                throw new ValidationException("Technology Id is not provided to DAL");

            try
            {
                Technology technology = GetallTechnologies().Where(x => x.TechnologyId == Technologyid && x.IsActive).First();
                if (technology == null) throw new NullReferenceException($"Id not found-{technology}");
                return technology;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetTechnologyById()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetTechnologyById()-{exception.StackTrace}");
                throw exception;
            }
        }
        public bool AddAchievements(Achievements achievements)
        {
            if (achievements == null)
                throw new ArgumentNullException("Social media details object is not provided to DAL");
            try
            {
                achievements.IsActive = true;
                _context.achievements.Add(achievements);
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
        public List<Achievements> GetallAchievements()
        {

            try
            {

                return _context.achievements.Include("achievementtype").ToList();

            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetallAchievements()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallAchievements()-{exception.StackTrace}");
                throw exception;
            }
        }
        public bool DisableAchievement(int AchievementId)
        {
            if (AchievementId <= 0)

                throw new ArgumentNullException("achievement Id is not provided to DAL");

            try
            {
                var achievement = _context.achievements.Find(AchievementId);
                if (achievement == null) throw new NullReferenceException($"SocialMedia Id not found{AchievementId}");
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
        public List<Profile> GetallProfiles()
        {

            try
            {
                var result = _context.profile.Include("personalDetails").Include("education").Include("projects").Include("skills").Include("achievements").Include(e => e.profilestatus).Include("user").ToList();
                return result;
            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetallProfile()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetallProfile()-{exception.StackTrace}");
                throw exception;
            }
        }
        public ProfileStatus GetProfileStatusByProfileId(int Profileid)
        {
            if (Profileid <= 0)

                throw new ValidationException("Profile id is not provided to DAL");
            try
            {

                return _context.profile.Where(x => x.ProfileId == Profileid).Include(p => p.profilestatus).Select(p => p.profilestatus).First();
            }
            catch
            {
                System.Console.WriteLine("error");
                throw;
            }

        }
        public Profile GetProfileById(int ProfileId)
        {
            if (ProfileId <= 0)

                throw new ArgumentNullException("Profile id is not provided to DAL");

            try
            {

                Profile profile = GetallProfiles().Where(x => x.ProfileId == ProfileId && x.IsActive).First();
                if (profile == null) throw new NullReferenceException($"Id not found-{ProfileId}");
                return profile;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetProfileById()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetProfileById()-{exception.StackTrace}");
                throw exception;
            }
        }

        public Profile GetProfileIdByUserId(int Userid)
        {
            if (Userid <= 0)
                throw new ArgumentNullException("User id is not provided to DAL");
            try
            {
                Profile profile=_context.profile.Include(e => e.profilestatus).Where(x => x.UserId == Userid).FirstOrDefault();
                return profile;
            }
            catch (Exception exception)
            {
                System.Console.WriteLine("error");
                throw;
            }
        }
        public List<User> GetFilteredProfile(string userName, int designationId, int domainID, int technologyId, int collegeId, int profileStatusId,int currentdesignation)
        {
            try
            {
                return _context.users
                   .Include(e => e.designation)
                   .Include(e => e.profile)
                   .Include(e => e.profile.personalDetails)
                   .Include(e => e.profile.profilestatus)
                   .Where(user => user.profile != null && user.DesignationId > currentdesignation  && user.personalDetails != null)
                   .WhereIf(String.IsNullOrEmpty(userName) == false, users =>users.DesignationId > currentdesignation && users.Name.Contains(userName) == true)
                   .WhereIf(designationId != 0,users => users.DesignationId > currentdesignation && users.DesignationId == designationId)
                   .WhereIf(domainID != 0, users => users.DesignationId > currentdesignation && users.profile.skills.Any(s => s.DomainId == domainID) == true)
                   .WhereIf(technologyId != 0, users => users.DesignationId > currentdesignation && users.profile.skills.Any(s => s.TechnologyId == technologyId) == true)
                   .WhereIf(collegeId != 0, users => users.DesignationId > currentdesignation && users.profile.education.Any(s => s.CollegeId == collegeId) == true)
                   .WhereIf(profileStatusId != 0, users => users.DesignationId > currentdesignation && users.profile.ProfileStatusId == profileStatusId)
                   .ToList(); 
                
            }

            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetFilteredProfile()-{exception.Message}");
                throw;
            }
        }
        public bool AcceptOrRejectProfile(int profileId, int response)
        {
            if (profileId <= 0)
                throw new ValidationException("Profile Id cannot be negative in DAL");

            try
            {
                Profile status = _context.profile.Find(profileId);
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
                throw exception;
            }

        }
        public Profile GetProfile(int ProfileId)
        {

            if (ProfileId <= 0)

                throw new ArgumentNullException("Profile id is not provided to DAL");

            try
            {
                return _context.profile.Find(ProfileId);
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-GetProfile()-{exception.Message}");
                _logger.LogInformation($"ProfileData-GetProfile()-{exception.StackTrace}");
                throw exception;
            }
        }
        public bool updateProfileStatus(Profile profile)
        {
            if (profile == null || profile.ProfileId <= 0 || profile.UserId <= 0)
                throw new ValidationException("profileId should not null");

            if (!_context.profile.Any(e => e.ProfileId.Equals(profile.ProfileId)))
                throw new ValidationException("Profile does not exists");
            try
            {
                _context.profile.Update(profile);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData-updateProfileStatus()-{exception.Message}");
                _logger.LogInformation($"ProfileData-updateProfileStatus()-{exception.StackTrace}");
                throw exception;
            }
        }
        public object GetProfileCount(int currentdesignation)
        {
            try{
                var result=_context.profile;
                var Approved = result.Where(p => p.ProfileStatusId == 1 && p.user.DesignationId>currentdesignation).Count();
                var Rejected = result.Where(p => p.ProfileStatusId == 3  && p.user.DesignationId>currentdesignation).Count();
                var Waiting = result.Where(p => p.ProfileStatusId == 2  && p.user.DesignationId>currentdesignation).Count();
                var total = result.Where(p => p.user.DesignationId>currentdesignation).Count();
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

                throw exception;
            }
        }

    }


}


