using AW.Common.Enums;

namespace AW.Business.Authorization
{
    public interface ILoginService
    {
        LoginResult Login(string userName, string password);
        void Logout();
    }
}