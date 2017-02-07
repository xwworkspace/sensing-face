using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SING.Data.Logger
{
    public class Logger
    {
        private static log4net.ILog fileLogger = null;
        private static log4net.ILog TransferLogger = null;

        private static void InitializaLogger()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                fileLogger = log4net.LogManager.GetLogger("File");
            }
            catch (Exception exc)
            {
                System.Diagnostics.EventLog.WriteEntry("FACE", "Unable to initialize logger.\n" + exc.ToString(), System.Diagnostics.EventLogEntryType.Error);
                fileLogger = null;
            }

            try
            {
                TransferLogger = log4net.LogManager.GetLogger("TransferLog");
            }
            catch (Exception ex)
            {

                System.Diagnostics.EventLog.WriteEntry("FACE", "Unable to initialize logger.\n" + ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                TransferLogger = null;
            }
        }
        /// <summary>
        /// Log error message.
        /// </summary>
        /// <param name="message">Error message.</param>
        public static void Error(String message)
        {
            Error(message, null);
        }
        /// <summary>
        /// Log exception.
        /// </summary>
        /// <param name="message">Message that should contain information about functinality that cause this exception.</param>
        /// <param name="exception">Instance of <c>Exception</c>.</param>
        public static void Error(String message, Exception exception)
        {
            if (message == null)
            {
                return;
            }
            if (fileLogger == null)
            {
                InitializaLogger();
            }
            if (exception != null)
            {
                if (fileLogger != null) // if initialization do not fail
                {
                    fileLogger.Error(message, exception);
                }
            }
            else
            {
                if (fileLogger != null) // if initialization do not fail
                {
                    fileLogger.Error(message);
                }
            }
        }

        /// <summary>
        /// Log information.
        /// </summary>
        /// <param name="message">Information message.</param>
        public static void Info(String message)
        {
            if (message == null)
            {
                return;
            }
            if (fileLogger == null)
            {
                InitializaLogger();
            }
            if (fileLogger != null)
            {
                fileLogger.Info(message);
            }
        }
    }
}
