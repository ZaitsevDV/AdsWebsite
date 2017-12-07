using LogicTier.Providers;
using LogicTier.Service;
using StructureMap.Configuration.DSL;

namespace LogicTier.Container
{
    public class LogicRegistry : Registry
    {
        public LogicRegistry()
        {
            For<IAdProvider>().Use<AdProvider>();
            For<IUserProvider>().Use<UserProvider>();
            For<ILoginService>().Use<LoginService>();
        }
    }
}
