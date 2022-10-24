//using Microsoft.Extensions.Logging; Di hapus dulu
using NLog;
using Northwind.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            //throw new NotImplementedException();
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            //throw new NotImplementedException();
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            //throw new NotImplementedException();
            logger.Info(message);
        }

        public void LogWarning(string message)
        {
            //throw new NotImplementedException();
            logger.Warn(message);
        }
    }
}
