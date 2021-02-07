using System;
using Compressor.Abstractions.Logging;

namespace Compressor.Tool
{
    internal sealed class ConsoleLogger : Logger
    {
        private readonly LogLevel _minimumLogLevel;
        private const string Format = "[{0:dd/MM/yyyy hh:mm:ss.fff} {1}] {2}";

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

            var current = DateTime.Now;
            switch (logLevel)
            {
                case LogLevel.Trace:
                    Console.WriteLine(Format, current, nameof(LogLevel.Trace), message);
                    break;
                case LogLevel.Debug:
                    Console.WriteLine(Format, current, nameof(LogLevel.Debug), message);
                    break;
                case LogLevel.Info:
                    Console.WriteLine(Format, current, nameof(LogLevel.Info), message);
                    break;
                case LogLevel.Warn:
                    Console.WriteLine(Format, current, nameof(LogLevel.Warn), message);
                    break;
                case LogLevel.Error:
                    Console.WriteLine(Format, current, nameof(LogLevel.Error), message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }

        private bool IsEnabled(LogLevel logLevel) => logLevel >= _minimumLogLevel;
    }
}