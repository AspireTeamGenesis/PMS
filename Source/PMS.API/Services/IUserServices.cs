using PMS_API;

namespace PMS_API
{
    public interface IUserServices
    {
        bool AddUser(User item,int userId);
        bool Disable(int id);
        object GetallUsers(int profilestatusId,int designationId);
        object GetUser(int id);
        bool Save();
        bool UpdateUser(User item);
        object GetSpecificUserDetails();
        bool ChangePassword(string OldPassword,string NewPassword,string ConfirmPassword,int currentUser);
        object GetAllUsersByDesignation(int designationId);
    }
}