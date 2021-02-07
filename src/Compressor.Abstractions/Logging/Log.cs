using System;

namespace Compressor.Abstractions.Logging
{
    public static class Log
    {
        public static Logger Logger { get; set; } = new NullLogger();

        public static void Trace(string message)
        {
            Logger.Log(LogLevel.Trace, message);
        }

        public static void Debug(string message)
        {
            Logger.Log(LogLevel.Debug, message);
        }

        public static void Info(string message)
        {
            Logger.Log(LogLevel.Info, message);
        }

        public static void Warn(string message)
        {
            Logger.Log(LogLevel.Warn, message);
        }

        public static void Error(string message)
        {
            Logger.Log(LogLevel.Error, message);
        }
        
        public static void Error(Exception exception)
        {
            Logger.Log(LogLevel.Error, exception.ToString());
        }
    }
}