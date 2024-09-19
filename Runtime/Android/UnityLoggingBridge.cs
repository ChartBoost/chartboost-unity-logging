using Chartboost.Constants;
using UnityEngine;

namespace Chartboost.Logging.Android
{
    internal class UnityLoggingBridge : INativeLogger
    {
        // ReSharper disable once InconsistentNaming
        private const string ClassUnityLoggingBridge = "com.chartboost.mediation.unity.logging.UnityLoggingBridge";
        private const string FunctionSetUnityLoggingObserver = "setUnityLoggingObserver";
        
        private static readonly UnityLoggingObserver UnityLoggingObserver = new();
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void RegisterInstance()
        {
            if (Application.isEditor)
                return;
            using var unityLoggingBridge = new AndroidJavaClass(ClassUnityLoggingBridge);
            unityLoggingBridge.CallStatic(FunctionSetUnityLoggingObserver, UnityLoggingObserver);
            LogController.NativeLogger = new UnityLoggingBridge();
        }
        
        public void SetLogLevel(LogLevel logLevel)
        {
            using var unityLoggingBridge = new AndroidJavaClass(ClassUnityLoggingBridge);
            unityLoggingBridge.CallStatic(SharedAndroidConstants.FunctionSetLogLevel, (int)logLevel);
        }

        public LogLevel GetLogLevel()
        {
            using var unityLoggingBridge = new AndroidJavaClass(ClassUnityLoggingBridge);
            return (LogLevel)unityLoggingBridge.CallStatic<int>(SharedAndroidConstants.FunctionGetLogLevel);
        }
    }
}
