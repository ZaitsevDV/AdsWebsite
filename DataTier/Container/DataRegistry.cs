using DataTier.Business;
using DataTier.Clients;
using DataTier.Repositories;
using StructureMap.Configuration.DSL;

namespace DataTier.Container
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<IAdClient>().Use<AdClient>();
            For<IConvert>().Use<Convert>();
            For<IDataService>().Use<DataService>();
        }
    }
}
