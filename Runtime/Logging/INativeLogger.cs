namespace Chartboost.Logging
{
    public interface INativeLogger
    {
        void SetLogLevel(LogLevel logLevel);

        LogLevel GetLogLevel();
    }
}
