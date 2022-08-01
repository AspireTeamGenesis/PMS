using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_API;
namespace testing.Mock
{
    static class ProfileMock
    {
        public static Profile AddValidProfile()
        {
            return new Profile
            {
                ProfileId=1,
                ProfileStatusId=1,
                IsActive=true
            };
        }
        public static PersonalDetails AddValidPersonalDetails()
        {
            return new PersonalDetails
            {
                PersonalDetailsId=2,
                ProfileId=1,
                Objective="To secure a challenging position in a reputable organization to expand my learnings, knowledge, and skills.",
                DateOfBirth=new DateTime(2000-09-03),
                Nationality="Indian",
                DateOfJoining=new DateTime(2020-06-27),
                base64header="+MZRKgPsD/xr/9k=",
                Image=new byte[]{},
                CreatedOn=null,
                CreatedBy=4,
                UpdatedOn=null,
                UpdatedBy=null,
                UserId=4,
                IsActive=true
            };
        }
        public static List<PersonalDetails> GetValidateAllPersonalDetails()
        {
            return new List<PersonalDetails>()
            {
               new PersonalDetails(){
                PersonalDetailsId=2,
                ProfileId=1,
                Objective="To secure a challenging position in a reputable organization to expand my learnings, knowledge, and skills.",
                DateOfBirth=new DateTime(2001-09-11),
                Nationality="Indian",
                DateOfJoining=new DateTime(2020-06-27),
                base64header="+MZRKgPsD/xr/9k=",
                Image=new byte[]{},
                CreatedOn=null,
                CreatedBy=4,
                UpdatedOn=null,
                UpdatedBy=null,
                UserId=4,
                IsActive=true
               },
               new PersonalDetails(){
                PersonalDetailsId=3,
                ProfileId=2,
                Objective="To secure a challenging position in a reputable organization to expand my learnings, knowledge, and skills.",
                DateOfBirth=new DateTime(2000-09-11),
                Nationality="Indian",
                DateOfJoining=new DateTime(2021-09-21),
                base64header="+MZRKgPsD/xr/9k=",
                Image=new byte[]{},
                CreatedOn=null,
                CreatedBy=3,
                UpdatedOn=null,
                UpdatedBy=null,
                UserId=3,
                IsActive=true
               },
               new PersonalDetails(){
                PersonalDetailsId=4,
                ProfileId=3,
                Objective="To secure a challenging position in a reputable organization to expand my learnings, knowledge, and skills.",
                DateOfBirth=new DateTime(2000-01-15),
                Nationality="Indian",
                DateOfJoining=new DateTime(2019-06-10),
                base64header="+MZRKgPsD/xr/9k=",
                Image=new byte[]{},
                CreatedOn=null,
                CreatedBy=2,
                UpdatedOn=null,
                UpdatedBy=null,
                UserId=2,
                IsActive=true
               },
            };
        }
        public static PersonalDetails GetValidPersonalDetails()
        {
            return new PersonalDetails
            {
                PersonalDetailsId=2,
                ProfileId=1,
                Objective="To secure a challenging position in a reputable organization to expand my learnings, knowledge, and skills.",
                DateOfBirth=new DateTime(2000-09-03),
                Nationality="Indian",
                DateOfJoining=new DateTime(2020-06-27),
                base64header="+MZRKgPsD/xr/9k=",
                Image=new byte[]{},
                CreatedOn=null,
                CreatedBy=4,
                UpdatedOn=null,
                UpdatedBy=null,
                UserId=4,
                IsActive=true
            };
        }
        public static Education AddValidEducationalDetails()
        {
            return new Education
            {
                EducationId=1,
                ProfileId=1,
                Degree="BE",
                Course="ECE",
                CollegeId=1,
                Starting=2018,
                Ending=2022,
                Percentage=90,
                CreatedOn=null,
                CreatedBy=1,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
            };
        }
         public static List<Education> GetAllValidEducationDetails()
        {
            return new List<Education>()
            {
               new Education(){
                EducationId=1,
                ProfileId=1,
                Degree="BE",
                Course="ECE",
                CollegeId=1,
                Starting=2018,
                Ending=2022,
                Percentage=90,
                CreatedOn=null,
                CreatedBy=1,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
               },
               new Education(){
                EducationId=2,
                ProfileId=2,
                Degree="BE",
                Course="EEE",
                CollegeId=2,
                Starting=2018,
                Ending=2022,
                Percentage=90,
                CreatedOn=null,
                CreatedBy=2,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
               },
               new Education(){
                EducationId=3,
                ProfileId=3,
                Degree="BE",
                Course="CSE",
                CollegeId=1,
                Starting=2018,
                Ending=2022,
                Percentage=90,
                CreatedOn=null,
                CreatedBy=3,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
               },
            };
        }
        public static Education GetValidEducationDetails()
        {
            return new Education
            {
                EducationId=2,
                ProfileId=2,
                Degree="BE",
                Course="EEE",
                CollegeId=2,
                Starting=2018,
                Ending=2022,
                Percentage=90,
                CreatedOn=null,
                CreatedBy=2,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
            };
        }
        public static Projects AddValidProjectDetails()
        {
            return new Projects
            {
                ProjectId=1,
                ProfileId=1,
                ProjectName="PMS",
                ProjectDescription="Profile Management system",
                StartingMonth="March",
                StartingYear=2021,
                EndingMonth="July",
                EndingYear=2021,
                Designation="SSE",
                ToolsUsed="JIRA",
                CreatedOn=null,
                CreatedBy=1,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
            };
        }
        public static List<Projects> GetAllValidProjectDetails()
        {
            return new List<Projects>()
            {
               new Projects(){
                ProjectId=1,
                ProfileId=1,
                ProjectName="PMS",
                ProjectDescription="Profile Management system",
                StartingMonth="March",
                StartingYear=2021,
                EndingMonth="July",
                EndingYear=2021,
                Designation="SSE",
                ToolsUsed="JIRA",
                CreatedOn=null,
                CreatedBy=1,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
               },
               new Projects(){
                ProjectId=1,
                ProfileId=2,
                ProjectName="IMS",
                ProjectDescription="Interview Management system",
                StartingMonth="March",
                StartingYear=2021,
                EndingMonth="July",
                EndingYear=2021,
                Designation="TL",
                ToolsUsed="JIRA",
                CreatedOn=null,
                CreatedBy=2,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
               },
               new Projects(){
                ProjectId=1,
                ProfileId=3,
                ProjectName="TMS",
                ProjectDescription="Ticket Management system",
                StartingMonth="March",
                StartingYear=2021,
                EndingMonth="July",
                EndingYear=2021,
                Designation="SE",
                ToolsUsed="JIRA",
                CreatedOn=null,
                CreatedBy=3,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
               },
            };
        }
        public static Projects GetValidProjectDetails()
        {
            return new Projects
            {
                ProjectId=1,
                ProfileId=3,
                ProjectName="TMS",
                ProjectDescription="Ticket Management system",
                StartingMonth="March",
                StartingYear=2021,
                EndingMonth="July",
                EndingYear=2021,
                Designation="SE",
                ToolsUsed="JIRA",
                CreatedOn=null,
                CreatedBy=3,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
            };
        }
        public static Skills AddValidSkillDetails()
        {
            return new Skills
            {
                SkillId=1,
                ProfileId=1,
                TechnologyId=3,
                DomainId=2,
                CreatedOn=null,
                CreatedBy=1,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
            };
        }
        public static List<Skills> GetAllValidSkillDetails(){
            return new List<Skills>{
                new Skills(){
                  SkillId=1,
                  ProfileId=1,
                  TechnologyId=3,
                  DomainId=2,
                  CreatedOn=null,
                  CreatedBy=1,
                  UpdatedOn=null,
                  UpdatedBy=null,
                  IsActive=true
                },
                new Skills(){
                  SkillId=2,
                  ProfileId=2,
                  TechnologyId=1,
                  DomainId=3,
                  CreatedOn=null,
                  CreatedBy=2,
                  UpdatedOn=null,
                  UpdatedBy=null,
                  IsActive=true
                },
                new Skills(){
                  SkillId=3,
                  ProfileId=2,
                  TechnologyId=1,
                  DomainId=1,
                  CreatedOn=null,
                  CreatedBy=2,
                  UpdatedOn=null,
                  UpdatedBy=null,
                  IsActive=true
                },
            };
        }
        public static Skills GetValidSkillDetails()
        {
            return new Skills
            {
                  SkillId=1,
                  ProfileId=1,
                  TechnologyId=3,
                  DomainId=2,
                  CreatedOn=null,
                  CreatedBy=1,
                  UpdatedOn=null,
                  UpdatedBy=null,
                  IsActive=true
            };
        }
        public static Achievements AddValidAchievementDetails()
        {
            return new Achievements
            {
                AchievementId=1,
                ProfileId=1,
                AchievementTypeId=2,
                base64header="+MZRKgPsD/xr/9k=",
                AchievementImage=null,
                CreatedOn=null,
                CreatedBy=1,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
            };
        }
        public static List<Achievements> GetAllValidAchievementDetails(){
            return new List<Achievements>{
                new Achievements(){
                  AchievementId=1,
                  ProfileId=1,
                  AchievementTypeId=2,
                  base64header="+MZRKgPsD/xr/9k=",
                  AchievementImage=null,
                  CreatedOn=null,
                  CreatedBy=1,
                  UpdatedOn=null,
                  UpdatedBy=null,
                  IsActive=true
                },
                new Achievements(){
                  AchievementId=2,
                  ProfileId=1,
                  AchievementTypeId=1,
                  base64header="+MZRKgPsD/xr/9k=",
                  AchievementImage=null,
                  CreatedOn=null,
                  CreatedBy=1,
                  UpdatedOn=null,
                  UpdatedBy=null,
                  IsActive=true
                },
                new Achievements(){
                  AchievementId=3,
                  ProfileId=2,
                  AchievementTypeId=1,
                  base64header="+MZRKgPsD/xr/9k=",
                  AchievementImage=null,
                  CreatedOn=null,
                  CreatedBy=2,
                  UpdatedOn=null,
                  UpdatedBy=null,
                  IsActive=true
                },
            };
        }
        public static Achievements GetValidAchievementDetails()
        {
            return new Achievements
            {
                  AchievementId=3,
                  ProfileId=2,
                  AchievementTypeId=1,
                  base64header="+MZRKgPsD/xr/9k=",
                  AchievementImage=null,
                  CreatedOn=null,
                  CreatedBy=2,
                  UpdatedOn=null,
                  UpdatedBy=null,
                  IsActive=true
            };
        }
        public static BreakDuration AddValidBreakDuration()
        {
            return new BreakDuration
            {
                BreakDuration_Id=1,
                PersonalDetailsId=2,
                StartingDuration=new DateTime(2021-01-03),
                EndingDuration=new DateTime(2021-09-03),
                CreatedOn=null,
                CreatedBy=2,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
            };
        }
        public static Language AddValidLanguage()
        {
            return new Language
            {
                LanguageId=1,
                LanguageName="English",
                Read=true,
                Write=true,
                Speak=true,
                PersonalDetailsId=2,
                CreatedOn=null,
                CreatedBy=2,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
            };
        }
        public static SocialMedia AddValidSocialMedia()
        {
            return new SocialMedia
            {
                SocialMedia_Id=1,
                SocialMedia_Name="LinkedIn",
                SocialMedia_Link="www.linkedin.com",
                PersonalDetailsId=2,
                CreatedOn=null,
                CreatedBy=2,
                UpdatedOn=null,
                UpdatedBy=null,
                IsActive=true
            };
        }
        public static ProfileHistory AddValidProfileHistory()
        {
            return new ProfileHistory
            {
                ProfileHistoryId=1,
                ProfileId=1,
                ApprovedDate=new DateTime(2022-09-03),
                IsActive=true
            };
        }
        public static List<ProfileHistory> GetAllValidProfileHistories(){
            return new List<ProfileHistory>{
                new ProfileHistory(){
                  ProfileHistoryId=1,
                  ProfileId=1,
                  ApprovedDate=new DateTime(2022-09-03),
                  IsActive=true
                },
                new ProfileHistory(){
                  ProfileHistoryId=2,
                  ProfileId=1,
                  ApprovedDate=new DateTime(2022-02-03),
                  IsActive=true
                },
                new ProfileHistory(){
                  ProfileHistoryId=3,
                  ProfileId=1,
                  ApprovedDate=new DateTime(2021-12-03),
                  IsActive=true
                },
            };
        }
    }
}