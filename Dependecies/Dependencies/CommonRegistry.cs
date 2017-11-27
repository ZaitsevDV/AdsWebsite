using DataTier.Container;
using LogicTier.Container;
using StructureMap.Configuration.DSL;

namespace Dependecies.Dependencies
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            Scan(scan => {
                scan.Assembly(typeof(DataRegistry).Assembly);
                scan.Assembly(typeof(LogicRegistry).Assembly);
                scan.WithDefaultConventions();
            });
        }
    }
}
