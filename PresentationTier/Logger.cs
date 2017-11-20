using log4net;
using log4net.Config;

namespace PresentationTier
{
    ///
    /// Logger - shell for log4net logger
    ///
    public static class Logger
    {
        public static ILog Log { get; } = LogManager.GetLogger(typeof(Logger));

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}