using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.Prism.Logging;

namespace PrismFourAuto
{
    public class EnterpriseLibraryLoggerAdapter : ILoggerFacade
    {
        static EnterpriseLibraryLoggerAdapter()
        {
            IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
            LogWriterFactory logWriterFactory = new LogWriterFactory(configurationSource);
            Logger.Write(logWriterFactory.Create());
        }

        public EnterpriseLibraryLoggerAdapter()
        {
            //Logger.SetLogWriter(new LogWriter(new LoggingConfiguration()));
        }

        #region ILoggerFacade Members

        public void Log(string message, Category category, Priority priority)
        {
            Logger.Write(message, category.ToString(), (int)priority);
        }

        public void Log(LogEntry logEntry)
        {
            Logger.Write(logEntry);
        }

        #endregion

    }
}
