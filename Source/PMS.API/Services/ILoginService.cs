namespace PMS_API{
    public interface ILoginService
    {
        public object AuthLogin(string UserName, string Password);
    }
}