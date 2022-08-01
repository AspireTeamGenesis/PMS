using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PMS_API
{
    public class PasswordValidation
    {
        public static bool IsValidPassword(string NewPassword,string ConfirmPassword)
        {
            
            if(!Regex.IsMatch(NewPassword, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"))
                throw new ValidationException($"Enter a valid Password. Password must contain Minimum eight characters, at least one letter, one number and one special character and user supplied Password is {NewPassword}");
            if(!Regex.IsMatch(ConfirmPassword, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"))
                throw new ValidationException($"Enter a valid Password. Password must contain Minimum eight characters, at least one letter, one number and one special character and user supplied Password is {ConfirmPassword}");
            return true;
        }
    }
}