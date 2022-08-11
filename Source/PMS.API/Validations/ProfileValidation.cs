using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PMS_API
{
    public class ProfileValidation
    {

        public bool PersonalDetailsvalidate(PersonalDetails personalDetails)
        {

            if (string.IsNullOrEmpty(personalDetails.Objective))
                throw new ValidationException($"Objective not be null user supplied Nationality as \"{personalDetails.Objective}\"");
             else if (!Regex.IsMatch(personalDetails.Objective, @"[a-zA-Z .,\-]{3,500}$"))
                throw new ValidationException($"Objective is invalid and user supplied Objective as \"{personalDetails.Objective}\"");

            //nationality validations              
            if (string.IsNullOrEmpty(personalDetails.Nationality))
                throw new ValidationException($"Nationality not be null and user supplied Nationality as \"{personalDetails.Nationality}\"");
            else if (!Regex.IsMatch(personalDetails.Nationality, @"[a-zA-Z]{3,40}$"))
                throw new ValidationException($"Nationality is invalid and user supplied Nationality as \"{personalDetails.Nationality}\"");

            //Date of Birth Validations
            if (string.IsNullOrEmpty((personalDetails.DateOfBirth).ToString()))
                throw new ValidationException($"DateOfBirth not be null and user supplied DateOfBirth as \"{personalDetails.DateOfBirth}\"");
            else if (personalDetails.DateOfBirth.Equals(""))
                throw new ValidationException($"DateOfBirth not be null and user supplied DateOfBirth as \"{personalDetails.DateOfBirth}\"");
            else if (personalDetails.DateOfBirth.Equals(DateTime.Today) || (personalDetails.DateOfBirth > DateTime.Today))
                throw new ValidationException($"DateOfBirth is Invalid and user supplied DateOfBirth as \"{personalDetails.DateOfBirth}\"");
            else if (!DateOfBirthAgeValidate(personalDetails.DateOfBirth))
                throw new ValidationException($"age is less than 18 and user supplied DateOfBirth as \"{personalDetails.DateOfBirth}\"");

            //date of joining validations
            if (string.IsNullOrEmpty((personalDetails.DateOfJoining).ToString()))//check Date of joinig is null
                throw new ValidationException($"DateOfJoin not be null and user supplied DateOfJoin as \"{personalDetails.DateOfJoining}\"");
            if (personalDetails.DateOfJoining > DateTime.Today ) //check DateOfJoining is a future date
                throw new ValidationException($"DateOfJoin not be futureDate and user supplied DateOfJoin as \"{personalDetails.DateOfJoining}\"");
            if (personalDetails.DateOfJoining <= personalDetails.DateOfBirth ) //check DateOfJoining is before Date of Birth
                throw new ValidationException($"DateOfJoin is invalid and user supplied DateOfJoin as \"{personalDetails.DateOfJoining}\"");
                
            //base64 validations
            if (String.IsNullOrEmpty(personalDetails.base64header))
                throw new ValidationException($"base64header should not be empty and user supplied base64header as \"{personalDetails.base64header}\"");
            return true;
        }
        public bool Educationdetailvalidation(Education education)
        {
            //Degree Validations
            if (string.IsNullOrEmpty(education.Degree))//to check string is null or empty
                throw new ValidationException($"Degree not be null and user supplied Degree as \"{education.Degree}\"");
            // to check degree has letter only
            else if ((!Regex.IsMatch(education.Degree, "^[a-zA-Z ]{2,30}$")))//Regex.IsMatch(education.Degree, "^(?=.*\\d)(?=.*[-+_!@#$%^&*., ?]).+$") 
                throw new ValidationException($"Degree is invalid and user supplied Degree as \"{education.Degree}\"");

            //course validations
            if (string.IsNullOrEmpty(education.Course))//to check course is null or empty 
                throw new ValidationException($"Course not be null and user supplied Course as \"{education.Course}\"");
            else if (!Regex.IsMatch(education.Course, "^[A-Za-z ]{2,50}$"))// to check course has string with minimum 2 characters
                throw new ValidationException($"course should not contain specialcharacters,numbers and user supplied Course as \"{education.Course}\"");

            if ((education.CollegeId.Equals(0)))
                throw new ValidationException($"CollegeId not be null and user supplied CollegeId as \"{education.CollegeId}\"");

            //starting year validation
            if (string.IsNullOrEmpty((education.Starting).ToString()) || (education.Starting).Equals(0))//check starting year is null or empty
                throw new ValidationException($"StartingYear not be empty and user supplied StartingYear as \"{education.Starting}\"");
            if (!Regex.IsMatch(education.Starting.ToString()!, "^[0-9]{4}$"))
                throw new ValidationException($"Starting year is Invalid\"{education.Starting}\"");
            if (education.Starting.Equals(DateTime.Today.Year) || (education.Starting > (DateTime.Today.Year)))//check starting year is not this year and future year
                throw new ValidationException($"StartingYear should not be this year,future Year and user supplied StartingYear as \"{education.Starting}\"");

            //ending year validation
            if (string.IsNullOrEmpty((education.Ending).ToString()) || (education.Ending).Equals(0))//check ending year is null or empty
                throw new ValidationException($"EndingYear not be empty and user supplied EndingYear as \"{education.Ending}\"");
            else if (education.Ending > (DateTime.Today.Year))//check ending year is not this year and future year
                throw new ValidationException($"endingYear should not be future Year and user supplied endingYear as \"{education.Starting}\"");
            else if (education.Ending <= education.Starting)//check ending year less than or equal to starting year
                throw new ValidationException($"endingYear should not be less than starting year and user supplied endingYear as \"{education.Starting}\"");

            //percentage validation
            if (education.Percentage.Equals("") || education.Percentage.Equals(0))//check if percentage is null or empty
                throw new ValidationException($"Percentage not be empty  and user supplied Percentage as \"{education.Percentage}\"");
            else if (1 >= education.Percentage || education.Percentage > 100)//check if percentage lies in the range of(1, 100) 
                throw new ValidationException($"Percentage should be between 1 to 100  and user supplied Percentage as \"{education.Percentage}\"");
            else if (Regex.IsMatch(education.Percentage.ToString(), "[A-Za-z]+[\\W]"))
                throw new ValidationException("Percentage sholud be in decimals");
            return true;

        }
        public bool SkillDetailValidation(Skills skill)
        {
            if (skill.DomainId.Equals(0) || string.IsNullOrEmpty((skill.DomainId).ToString()))
                throw new ValidationException($"Domain not be null and user supplied Domain as \"{skill.DomainId}\"");
            if (skill.TechnologyId.Equals(0) || string.IsNullOrEmpty((skill.TechnologyId).ToString()))
                throw new ValidationException($"Technology not be null and user supplied Technology as \"{skill.TechnologyId}\"");
            return true;
        }
        public bool ProjectDetailvalidation(Projects project)
        {
            //ProjectName validation
            if (string.IsNullOrEmpty(project.ProjectName))//check project name is null or empty
                throw new ValidationException($"ProjectName not be null and user supplied ProjectName as \"{project.ProjectName}\"");
            if (!Regex.IsMatch(project.ProjectName, "^[A-Za-z ]{3,100}$"))//check project name contains special characters only
                throw new ValidationException($"ProjectName not contain SpecialCharacters, numbers and user supplied ProjectName as \"{project.ProjectName}\"");

            //project description
            if (string.IsNullOrEmpty(project.ProjectDescription))//check project description is null or empty
                throw new ValidationException($"project_Description should not be null and user supplied project_Description as \"{project.ProjectDescription}\"");
            if (!Regex.IsMatch(project.ProjectDescription,@"^[A-Za-z0-9 .,\'\-\(\)\[\]]{3,500}$"))//check project description is null or empty
                throw new ValidationException($"project_Description is invalid and user supplied project_Description as \"{project.ProjectDescription}\"");

            //project Designation
            // if (Regex.IsMatch(project.Designation, "^[1-9]+$"))//check project Designation only contains numbers
            //     throw new ValidationException($"Designation should not be numbers alone and user supplied Designation as \"{project.Designation}\"");
            // if (Regex.IsMatch(project.Designation, "^[^\\w]+$"))//check Designation only contains specialcharacters
            //     throw new ValidationException($"Designation should not be specialcharacters and user supplied Designation as \"{project.Designation}\"");
            if (!Regex.IsMatch(project.Designation!, "^[A-Za-z ]{2,100}$"))//check Designation only contains specialcharacters
                throw new ValidationException($"Designation should not contain special characters, numbers and user supplied Designation as \"{project.Designation}\"");


            //tool used
            if (string.IsNullOrEmpty(project.ToolsUsed))
                throw new ValidationException($"ToolsUsed not be null and user supplied ToolsUsed as \"{project.ToolsUsed}\"");
            if (!Regex.IsMatch(project.ToolsUsed, "^[a-zA-Z, ]{2,600}$"))//check Toolsused only contains string only
                throw new ValidationException($"Tools should not be special characters and user supplied Designation as \"{project.ToolsUsed}\"");

            //Project starting month
            if (string.IsNullOrEmpty((project.StartingMonth!).ToString()))
                throw new ValidationException($"StartingMonth not be empty and user supplied StartingMonth as \"{project.StartingMonth}\"");
            if (!Regex.IsMatch(project.StartingMonth, "^[A-Za-z]{3,9}$"))
                throw new ValidationException($"Starting month is Invalid \"{project.StartingMonth}\"");


            //Project Ending Month
            if (string.IsNullOrEmpty((project.EndingMonth!).ToString()))
                throw new ValidationException($"EndingMonth not be empty and user supplied EndingMonth as \"{project.EndingMonth}\"");
            if (!Regex.IsMatch(project.EndingMonth, "^[A-Za-z]{3,9}$"))
                throw new ValidationException($"Ending month is Invalid \"{project.EndingMonth}\"");
            
            //project StartingYear validation
            if (string.IsNullOrEmpty((project.StartingYear).ToString())||(project.StartingYear.Equals(0)))
                throw new ValidationException($"StartingYear not be empty and user supplied StartingYear as \"{project.StartingYear}\"");
            if (project.StartingYear.Equals(DateTime.Today.Year) || project.StartingYear > DateTime.Today.Year)
                throw new ValidationException($"StartingYear should not be this year,future year and user supplied StartingYear as \"{project.StartingYear}\"");

            //project Ending year validation
            if ((project.EndingYear > DateTime.Today.Year) || (project.EndingYear < project.StartingYear))
                throw new ValidationException($"EndingYear not be empty and user supplied EndingYear as \"{project.EndingYear}\"");

            return true;
        }
        public bool SocialMediaDetailValidation(SocialMedia socialmedia)
        {
            if (string.IsNullOrEmpty(socialmedia.SocialMedia_Name))
                throw new ValidationException($"SocialMedia_Name not be null and user supplied SocialMedia_Name as \"{socialmedia.SocialMedia_Name}\"");
            if (!Regex.IsMatch(socialmedia.SocialMedia_Name, "^[A-Za-z ]{3,40}$"))
                throw new ValidationException($"Social Media name is Invalid \"{socialmedia.SocialMedia_Name}\"");
            if (string.IsNullOrEmpty(socialmedia.SocialMedia_Link))
                throw new ValidationException($"SocialMedia_Link not be null and user supplied SocialMedia_Link as \"{socialmedia.SocialMedia_Link}\"");
            return true;
        }
        
        public bool languageValidation(Language language)
        {
            if (string.IsNullOrEmpty(language.LanguageName))
                throw new ValidationException($"LanguageName Should not be null and user supplied language as \"{language.LanguageName}\"");
            else if (!Regex.IsMatch(language.LanguageName, "^[A-Za-z]{3,15}"))// to check language contains String alone untill 11 characters
                throw new ValidationException($"LanguageName is Invalid and user spplied language as \"{language.LanguageName}\"");

            if (string.IsNullOrEmpty(language.Read.ToString()))
                throw new ValidationException($"Read Should not be null and user supplied Read as \"{language.Read}\"");
            if (string.IsNullOrEmpty(language.Write.ToString()))
                throw new ValidationException($"write Should not be null and user supplied Write as \"{language.Write}\"");
            if (string.IsNullOrEmpty(language.Speak.ToString()))
                throw new ValidationException($"Speak Should not be null and user supplied Speak as \"{language.Speak}\"");
            return true;
        }
        public bool AchievementValidation(Achievements achievement)
        {
            if (string.IsNullOrEmpty(achievement.AchievementTypeId.ToString()) || achievement.AchievementTypeId.Equals(0) || achievement.AchievementTypeId.Equals(""))
                throw new ValidationException($"AchievementTypeId Should not be null and user supplied achievementType as \"{achievement.AchievementId}\"");
            return true;
        }
        private bool DateOfBirthAgeValidate(DateTime DateOfBirth)// to check (age<18) 
        {
            var age = DateTime.Now.AddYears(-DateOfBirth.Year).Year;
            if (age >= 18 && age <=65)
                return true;
            return false;
        }
       
    }
}