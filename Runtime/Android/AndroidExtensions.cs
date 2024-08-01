using UnityEngine;

namespace Chartboost.Logging.Android
{
    public static class AndroidExtensions
    {
        private const string LogLevelCompanion = "com.chartboost.heliumsdk.utils.LogController$LogLevel$Companion";
        private const string FunctionFromInt = "fromInt";
        
        public static AndroidJavaObject ToNativeLogLevel(this LogLevel logLevel)
        {
            var logLevelCompanionClass = new AndroidJavaClass(LogLevelCompanion);
            return logLevelCompanionClass.CallStatic<AndroidJavaObject>(FunctionFromInt, (int)logLevel);
        }
    }
}
