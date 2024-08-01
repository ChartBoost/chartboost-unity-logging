using System;
using UnityEngine;

namespace Chartboost.Logging
{
    public static class LogController
    {
        public static LogLevel LoggingLevel { get; set; } = LogLevel.Info;

        public static bool UseUnityLogger { get; set; } = true;

        public static event Action<string, LogLevel> MessageLogged;

        public static event Action<string> UnexpectedErrorOccurred;

        public static void Log(object message, LogLevel logLevel)
        {
            // Don't log if Logging disabled
            if (LoggingLevel == LogLevel.Disabled)
                return;
            
            if (logLevel > LoggingLevel) 
                return;
        
            if (message == null || string.IsNullOrEmpty(message.ToString()))
            {
                Debug.LogWarning(EmptyMessageWarning);
                return;
            }

            if (!UseUnityLogger)
            {
                Console.Write(message);
                return;
            }

            switch (logLevel)
            {
                case LogLevel.Error:
                    Debug.LogError(message);
                    break;
                case LogLevel.Warning:
                    Debug.LogWarning(message);
                    break;
                case LogLevel.Info:
                case LogLevel.Debug:
                case LogLevel.Verbose:
                    Debug.Log(message);
                    break;
            }
            MessageLogged?.Invoke(message.ToString(), logLevel);
        }

        public static void LogException(Exception exception)
        {
            // always use Unity logger to Log exceptions
            Debug.LogException(exception);
            UnexpectedErrorOccurred?.Invoke(exception.Message);
        }

        private const string EmptyMessageWarning = "Log messages should not be null or empty strings.";
    }
}
