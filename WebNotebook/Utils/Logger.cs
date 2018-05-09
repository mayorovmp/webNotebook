using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using log4net.Config;
using System.Web;

namespace WebNotebook.Utils
{
    public static class Logger
    {
        private static ILog log = LogManager.GetLogger("LOGGER");


        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}