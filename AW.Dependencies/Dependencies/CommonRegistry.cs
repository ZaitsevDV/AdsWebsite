using AW.Business.Container;
using AW.Data.Container;
using StructureMap.Configuration.DSL;

namespace AW.Dependencies.Dependencies
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            Scan(scan =>
            {
                scan.Assembly(typeof(DataRegistry).Assembly);
                scan.Assembly(typeof(LogicRegistry).Assembly);
                scan.WithDefaultConventions();
            });
        }
    }
}