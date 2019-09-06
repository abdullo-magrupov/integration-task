using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Synel.Web.Helpers
{
    public static class LogHelper
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Info(string message)
        {
            logger.Info(message);
        }

        public static void Error(string message)
        {
            logger.Error(message);
        }
    }
}