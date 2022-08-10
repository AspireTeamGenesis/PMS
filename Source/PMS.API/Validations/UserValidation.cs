using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PMS_API
{
    public class UserValidation
    {
        public bool userValidate(User user){
            if(string.IsNullOrEmpty(user.Name))
                throw new ValidationException($"Name should not be null and user supplied name as {user.Name}");
            if(!Regex.IsMatch(user.Name, @"^(?!.*([ ])\1)(?!.*([A-Za-z])\2{2})\w[a-zA-Z\s]{4,15}$"))
                throw new ValidationException($"Name must not contain any special character,numbers or no more repeated character more than 2 times and Length should be minimum4 and maximum 15. User supplied name as {user.Name}");
            // if(user.Name.Length<4)
            //     throw new ValidationException($"Length cannot less than 4 and user supplied name as {user.Name}");
            // if(user.Name.Length>15)
            //     throw new ValidationException($"Length cannot greater than 15 and user supplied name as {user.Name}");
            if(string.IsNullOrEmpty(user.Email))
                throw new ValidationException($"Email should not be null and user supplied Email as {user.Email}");
            if(!Regex.IsMatch(user.Email,@"^([0-9a-zA-Z.]){3,}@[a-zA-z]{3,}(.[a-zA-Z]{2,}[a-zA-Z]*){0,}$"))
                throw new ValidationException($"Enter valid Email address and user supplied Email as {user.Email}");
            if(string.IsNullOrEmpty(user.UserName))
                throw new ValidationException($"UserName should not be null and user supplied UserName as {user.UserName}");
            if(!Regex.IsMatch(user.UserName, @"^[A-Z]{1}[a-z]{2,10}\.[a-z]{5,15}$"))
                throw new ValidationException($"Enter valid UserName and user supplied UserName as {user.UserName}");
            if(string.IsNullOrEmpty(user.Password))
                throw new ValidationException($"Password should not be null and user supplied Password as {user.Password}");
            if(!Regex.IsMatch(user.Password, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"))
                throw new ValidationException($"Enter a valid Password. Password must contain Minimum eight characters, at least one letter, one number and one special character and user supplied Password as {user.Password}");
            // if(string.IsNullOrEmpty(user.Gender))
            //     throw new ValidationException($"Gender not be null and user supplied Gender is{user.Gender}");
            if(string.IsNullOrEmpty(user.MobileNumber))
                throw new ValidationException($"Mobile Number not be null and user supplied Mobile number is {user.MobileNumber}");
            if(!Regex.IsMatch(user.MobileNumber,@"^(\+\d{1,3}[- ]?)?\d{10}$"))
                throw new ValidationException($"Enter a valid Mobile number and user supplied Mobile number is  {user.MobileNumber}");
            // if(user.OrganisationName==0)
            //     throw new ValidationException($"Organization not be null and user supplied Organization is {user.OrganisationId}");
            // if(user.DesignationId==0)
            //     throw new ValidationException($"Designation not be null and user supplied Designation is {user.DesignationId}");
            if(string.IsNullOrEmpty(user.ReportingPersonUsername))
                throw new ValidationException($"Reporting Person should not be null and user supplied Reporting Person as {user.ReportingPersonUsername}");
            if(!Regex.IsMatch(user.ReportingPersonUsername, @"^[A-Z]{1}[a-z]{2,10}\.[a-z]{5,15}$"))
                throw new ValidationException($"Enter valid Reporting Person's UserName and user supplied Reporting Person as {user.ReportingPersonUsername}");
            return true;

        }
    }
}