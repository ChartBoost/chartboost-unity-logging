using System.Runtime.InteropServices;
using AOT;
using Chartboost.Constants;
using UnityEngine;

namespace Chartboost.Logging.iOS
{
    internal class UnityLoggingBridge : INativeLogger
    {
        private delegate void ExternChartboostLoggingBridgeMessageLogged(string message, int logLevel);

        private delegate void ExternChartboostLoggingExceptionLogged(string exception);
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void RegisterInstance()
        {
            if (Application.isEditor)
                return;
            
            _CBLSetUnityLoggingCallbacks(OnWrapperMessageLogged, OnExceptionLogged);
            LogController.NativeLogger = new UnityLoggingBridge();
        }
        
        public void SetLogLevel(LogLevel logLevel) 
            => _CBLSetLogLevel((int)logLevel);

        public LogLevel GetLogLevel() 
            => (LogLevel)_CBLGetLogLevel();

        [DllImport(SharedIOSConstants.DLLImport)] private static extern void _CBLSetUnityLoggingCallbacks(ExternChartboostLoggingBridgeMessageLogged bridgeMessageLoggedCallback, ExternChartboostLoggingExceptionLogged exceptionLoggedCallback);
        [DllImport(SharedIOSConstants.DLLImport)] private static extern void _CBLSetLogLevel(int logLevel);
        [DllImport(SharedIOSConstants.DLLImport)] private static extern int _CBLGetLogLevel();
        
        [MonoPInvokeCallback(typeof(ExternChartboostLoggingBridgeMessageLogged))]
        private static void OnWrapperMessageLogged(string message, int logLevel) 
            => MainThreadDispatcher.Post(_ => LogController.OnWrapperMessageLogged(message, (LogLevel)logLevel));

        [MonoPInvokeCallback(typeof(ExternChartboostLoggingExceptionLogged))]
        private static void OnExceptionLogged(string exception) 
            => MainThreadDispatcher.Post(_ => LogController.OnExceptionLogged(exception));
    }
}
