using System;
using System.Configuration;
using System.ServiceProcess;
using log4net;

namespace BlankService
{
    static class Program
    {
       // public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static int intervals = Convert.ToInt32(GetConfigValue("intervals"));

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new BlankService()
            };
            ServiceBase.Run(ServicesToRun);
        }
        private static string GetConfigValue(string key)
        {
            string value = string.Empty;
            try
            {
                value  = ConfigurationManager.AppSettings[key];

                //if (value == null) throw new ConfigurationException(string.Format("Could not find key {0} in the configuration file.", key));
                log.Info("============ BlankService stopped ============");

            }
            catch (Exception)
            {
                //throw new ConfigurationException(string.Format("Could not find key {0} in the configuration file.", key));
                log.Info("============ BlankService stopped ============");
            }
            return value;
        }
    }
}
