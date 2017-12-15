using AW.Data.Business;
using AW.Data.Clients;
using AW.Data.Repositories;
using StructureMap.Configuration.DSL;

namespace AW.Data.Container
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IClient>().Use<Client>();
            For<IConvert>().Use<Convert>();
            For<IAdService>().Use<AdService>();
            For<IUserService>().Use<UserService>();
        }
    }
}