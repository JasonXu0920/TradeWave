using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Logging
{
    public      abstract class AbstractLogger : ILogger
    {
        protected AbstractLogger()
        {
            
        }

        void Debug(string module, string message) => Log(logLevel.Debug, module, message);
        void Debug(string module, Exception exception) => Log(logLevel.Debug, module, $"(exception)");
        void Information(string module, string message) => Log(logLevel.Information, module, message);
        void Information(string module, Exception exception) => Log(logLevel.Information, module, $"(exception)");
        void Warning(string module, string message) => Log(logLevel.Warning, module, message);
        void Warning(string module, Exception exception) => Log(logLevel.Warning, module, $"(exception)");
        void Error(string module, string message) => Log(logLevel.Error, module, message);
        void Error(string module, Exception exception) => Log(logLevel.Error, module, $"(exception)");

        protected abstract void Log(LogLevel logLevel, string module, string message);
    }
}