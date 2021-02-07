using System;
using Compressor.Logging;

namespace Compressor.Tool
{
    internal sealed class ConsoleLogger : Logger
    {
        private const string Format = "[{0:dd/MM/yyyy hh:mm:ss.fff} {1}] {2}.";
        private readonly LogLevel _minimumLogLevel;

        public ConsoleLogger(LogLevel minimumLogLevel = LogLevel.Info)
        {
            _minimumLogLevel = minimumLogLevel;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            Console.WriteLine(Format, DateTime.Now, logLevel, message);
        }

        private bool IsEnabled(LogLevel logLevel) => logLevel >= _minimumLogLevel;
    }
}