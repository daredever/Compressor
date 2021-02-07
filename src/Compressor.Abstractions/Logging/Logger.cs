namespace Compressor.Logging
{
    public abstract class Logger
    {
        public abstract void Log(LogLevel logLevel, string message);
    }
}