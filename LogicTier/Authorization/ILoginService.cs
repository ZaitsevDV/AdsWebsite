using Common.Enums;

namespace LogicTier.Authorization
{
    public interface ILoginService
    {
        LoginResult Login(string userName, string password);
        void Logout();
    }
}