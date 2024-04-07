using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TradingEngineServer.Logging
{
    public abstract class AbstractLogger : ILogger
    {
        protected AbstractLogger()
        {
            
        }

        void Debug(string module, string message) => Log(LogLevel.Debug, module, message);
        void Debug(string module, Exception exception) => Log(LogLevel.Debug, module, $"(exception)");
        void Information(string module, string message) => Log(LogLevel.Information, module, message);
        void Information(string module, Exception exception) => Log(LogLevel.Information, module, $"(exception)");
        void Warning(string module, string message) => Log(LogLevel.Warning, module, message);
        void Warning(string module, Exception exception) => Log(LogLevel.Warning, module, $"(exception)");
        void Error(string module, string message) => Log(LogLevel.Error, module, message);
        void Error(string module, Exception exception) => Log(LogLevel.Error, module, $"(exception)");

        protected abstract void Log(LogLevel logLevel, string module, string message);
    }
}