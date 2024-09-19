using System;
using UnityEngine;

namespace Chartboost.Logging
{
    public static class LogController
    {
        internal static INativeLogger NativeLogger;

        private static LogLevel _logLevel = LogLevel.Info;
        
        public static LogLevel LoggingLevel {
            get
            {
                var nativeLogLevel = NativeLogger?.GetLogLevel() ?? _logLevel;

                if (_logLevel != nativeLogLevel)
                    Log($"LogLevel: {_logLevel} does not match NativeLogLevel: {nativeLogLevel}", LogLevel.Warning);
                return _logLevel;
            }
            set
            {
                _logLevel = value;
                NativeLogger?.SetLogLevel(value);
            }
        }

        public static bool UseUnityLogger { get; set; } = true;

        public static event Action<string, LogLevel> MessageLogged;

        public static event Action<string, LogLevel> WrapperMessageLogged;

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
            OnMessageLogged(message.ToString(), logLevel);
        }

        public static void LogException(Exception exception)
        {
            // always use Unity logger to Log exceptions
            Debug.LogException(exception);
            OnExceptionLogged(exception.Message);
        }

        internal static void OnMessageLogged(string message, LogLevel logLevel) 
            => MessageLogged?.Invoke(message, logLevel);

        internal static void OnExceptionLogged(string message) 
            => UnexpectedErrorOccurred?.Invoke(message);
        
        internal static void OnWrapperMessageLogged(string message, LogLevel logLevel) 
            => WrapperMessageLogged?.Invoke(message, logLevel);

        private const string EmptyMessageWarning = "Log messages should not be null or empty strings.";
    }
}
