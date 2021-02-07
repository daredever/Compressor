using System;
using Compressor.Abstractions.Logging;

namespace Compressor.Tool
{
    internal sealed class ConsoleLogger : Logger
    {
        private readonly LogLevel _minimumLogLevel;
        private const string Format = "[{0:dd/MM/yyyy hh:mm:ss.fff} {1}] {2}.";

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