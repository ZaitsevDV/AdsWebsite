using AW.Business.Authorization;
using AW.Business.Providers;
using StructureMap.Configuration.DSL;

namespace AW.Business.Container
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