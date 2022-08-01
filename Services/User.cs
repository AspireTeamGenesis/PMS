class UserDetails
{

}
class User
{
    public bool Login(string Username,string Password){}
    public bool forgotpassword(string email){}
    public bool Changepassword(string Currentpassword,string Newpassword,string Confirmpassword){}
    public bool CreateUser(UserDetails userdetails){}
    public bool UpdateUser(UserDetails userdetails){}
    public UserDetails GetUserById(string user_id){}
    public bool Signout(){}

}
