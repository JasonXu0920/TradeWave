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

        void ILogger.Debug(string module, string message) => Log(LogLevel.Debug, module, message);
        void ILogger.Debug(string module, Exception exception) => Log(LogLevel.Debug, module, $"(exception)");
        void ILogger.Information(string module, string message) => Log(LogLevel.Information, module, message);
        void ILogger.Information(string module, Exception exception) => Log(LogLevel.Information, module, $"(exception)");
        void ILogger.Warning(string module, string message) => Log(LogLevel.Warning, module, message);
        void ILogger.Warning(string module, Exception exception) => Log(LogLevel.Warning, module, $"(exception)");
        void ILogger.Error(string module, string message) => Log(LogLevel.Error, module, message);
        void ILogger.Error(string module, Exception exception) => Log(LogLevel.Error, module, $"(exception)");

        protected abstract void Log(LogLevel logLevel, string module, string message);

        
    }
}