using StructureMap.Configuration.DSL;
using DataTier.Container;
using LogicTier.Container;

namespace LogicTier.Dependencies
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
