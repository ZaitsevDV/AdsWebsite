using DataTier.Business;
using DataTier.Clients;
using StructureMap.Configuration.DSL;
using DataTier.Repositories;

namespace DataTier.Container
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IAdsRepository>().Use<AdsRepository>();
            For<IAdClient>().Use<AdClient>();
            For<IConvert>().Use<Convert>();
        }
    }
}
