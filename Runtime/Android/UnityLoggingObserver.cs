using UnityEngine;
using UnityEngine.Scripting;

namespace Chartboost.Logging.Android
{
    internal class UnityLoggingObserver : AndroidJavaProxy
    {
        // ReSharper disable once InconsistentNaming
        private const string ClassUnityLoggingObserver = "com.chartboost.mediation.unity.logging.UnityLoggingObserver";

        public UnityLoggingObserver() : base(ClassUnityLoggingObserver) { }

        [Preserve]
        // ReSharper disable once InconsistentNaming
        private void onBridgeLog(string message, int logLevel) 
            => MainThreadDispatcher.Post(_ => LogController.OnWrapperMessageLogged(message,  (LogLevel)logLevel));

        [Preserve]
        // ReSharper disable once InconsistentNaming
        private void onBridgeException(string exception) 
            => MainThreadDispatcher.Post(_ => LogController.OnExceptionLogged(exception));
    }
}
