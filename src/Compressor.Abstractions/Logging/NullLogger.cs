namespace Compressor.Abstractions.Logging
{
    internal sealed class NullLogger : Logger
    {
        public override void Log(LogLevel logLevel, string message)
        {
            // do nothing
        }
    }
}