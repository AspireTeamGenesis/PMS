using System;
using System.ComponentModel.DataAnnotations;
using PMS_API.API.UtilityFunctions;

namespace PMS_API
{


    public class UserServices : IUserServices
    {
        private readonly  UserData userData;

        private readonly ILogger<UserServices> _logger;

        public UserServices(ILogger<UserServices> logger)
        {
            _logger = logger;
            userData = UserDataFactory.GetUserObject(logger);
        }
        private readonly UserValidation _validation = UserDataFactory.GetValidationObject();
        public object GetallUsers(int profilestatusId, int designationId)
        {
            try
            {
                return (from user in userData.GetallForCard(profilestatusId, designationId) where user.IsActive == true select user).Select(
                    user => new
                    {
                        UserId = user.UserId,
                        Name = user.Name,
                        UserDesignation = user.designation!.DesignationName,
                        ReportingPerson = user.ReportingPersonUsername,
                        UserProfileStatus = user.profile!.profilestatus!.ProfileStatusName,
                        UserProfileImage = user.personalDetails != null ? user.personalDetails!.Image : null,
                        UserProfileId = user.profile.ProfileId
                    }
                );
            }
            catch (Exception exception)
            {
                _logger.LogError($"UserServices:GetallUsers()-{exception.Message}\n{exception.StackTrace}");
                throw;
            }
        }

        //Getting Specific user details of an User
        public Object GetSpecificUserDetails()
        {
            try
            {
                return (from user in userData.GetallUsers() where user.IsActive== true select user).ToList()
                .Select(var => new
                {
                    Name = var.Name,
                    UserId = var.UserId,
                    Designation = var.designation!.DesignationName,
                    ReportingPerson = var.ReportingPersonUsername
                }
                );
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"User Service : GetSpecificUserDetails() : {exception.Message} : {exception.StackTrace}");
                throw;
            }
        }

        //Getting the logged in user's Profile
        public object GetUser(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException($"ID is not provided{id}");
            try
            {
                var getuser = userData.GetUser(id);
                if (getuser.IsActive == true)
                {
                    return new
                    {
                        userid = getuser.UserId,
                        name = getuser.Name,
                        email = getuser.Email,
                        username = getuser.UserName,
                        password = getuser.Password,
                        genderId = getuser.GenderId,
                        gender = getuser.gender!.GenderName,
                        CountryCodeId = getuser.CountryCodeId,
                        countryCode = getuser.countrycode!.CountryCodeName,
                        mobilenumber = getuser.MobileNumber,
                        designationId = getuser.DesignationId,
                        designation = getuser.designation!.DesignationName,
                        reportingpersonUsername = getuser.ReportingPersonUsername,
                        organisationId = getuser.OrganisationId,
                        organisation = getuser.organisation!.OrganisationName,
                        image=getuser.personalDetails != null ? getuser.personalDetails.Image : null

                    };
                }
                else
                {
                    throw new ValidationException("User not found");
                }
            }
            catch (Exception exception)
            {
                _logger.LogError($"UserServices:GetUser()-{exception.Message}\n{exception.StackTrace}");
                throw;
            }
        }

        //Adding User details
        public bool AddUser(User item, int userId)

        {
            if (item == null)
                throw new ArgumentNullException($"UserServices:AddUser()-user values should not be null{item}");
            _validation.userValidate(item);
            try
            {
                item.CreatedBy = userId;
                item.CreatedOn = DateTime.Now;
                item.IsActive = true;
                return userData.AddUser(item) ? true : false;              //Ternary operator

            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"UserServices:AddUser()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogInformation($"UserServices:AddUser()-{exception.Message}\n{exception.StackTrace}");
                throw;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"UserServices:AddUser()-{exception.Message}\n{exception.StackTrace}");
                return false;

            }
        }

        //Disable User
        public bool Disable(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException($"ID is not provided{id}");


            try
            {

                return userData.Disable(id) ? true : false;

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"UserServices:Disable()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }

        //Updation of User details
        public bool UpdateUser(User item)
        {

            if (item == null) throw new ArgumentNullException($" UserServices:UpdateUser()-user values not be null{item}");
            _validation.userValidate(item);
            try
            {

                item.UpdatedBy = item.UserId;
                item.UpdatedOn = DateTime.Now;
                return userData.UpdateUser(item) ? true : false;

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"UserServices:UpdateUser()-{exception.Message}\n{exception.StackTrace}");
                return false;

            }
        }

        //Changing the Password for an User
        public bool ChangePassword(string OldPassword, string NewPassword, string ConfirmPassword, int currentUser)

        {

            PasswordValidation.IsValidPassword(NewPassword, ConfirmPassword);




            try
            {
                if (NewPassword != ConfirmPassword)
                    throw new ValidationException($"The confirm password should be the same as new password : {ConfirmPassword}");
                else
                {
                    return userData.EditPassword(OldPassword, NewPassword, ConfirmPassword, currentUser) ? true : false;
                }

            }

            catch (ArgumentException exception)

            {

                _logger.LogInformation($"User service : ChangePassword(string OldPassword,string NewPassword,string ConfirmPassword) : {exception.Message}");

                return false;

            }

            catch (ValidationException passwordNotValid)

            {

                _logger.LogInformation($"User service :ChangePassword(string OldPassword,string NewPassword,string ConfirmPassword): {passwordNotValid.Message}");

                throw;

            }

            catch (Exception exception)

            {

                _logger.LogInformation($"User service :ChangePassword(string OldPassword,string NewPassword,string ConfirmPassword):{exception.Message}");

                return false;

            }

        }

        //Save
        public bool Save()
        {
            return userData.save();
        }

        //Getting all users by the logged in user's Designation 
        public object GetAllUsersByDesignation(int designationId)
        {
            try
            {
                return (from user in userData.GetAllUsersByDesignation(designationId) where user.IsActive == true select user).Select(
                    user => new
                    {
                        UserId = user.UserId,
                        Name = user.Name,
                        UserDesignation = user.designation!.DesignationName,
                        ReportingPerson = user.ReportingPersonUsername,
                        UserProfileStatus = user.profile!.profilestatus!.ProfileStatusName,
                        UserProfileImage = user.personalDetails != null ? user.personalDetails!.Image : null,
                        UserProfileId = user.profile.ProfileId
                    }
                );
            }
            catch (Exception exception)
            {
                _logger.LogError($"UserServices:GetAllUsersByDesignation()-{exception.Message}\n{exception.StackTrace}");
                throw;
            }
        }
    }
}