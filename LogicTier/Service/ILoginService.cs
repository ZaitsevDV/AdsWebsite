using Common.Enums;

namespace LogicTier.Service
{
    public interface ILoginService
    {
        LoginResult Login(string userName, string password);
        void Logout();
    }
}