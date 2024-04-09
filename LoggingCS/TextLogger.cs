using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TradingEngineServer.Logging.LoggingConfiguration;

namespace TradingEngineServer.Logging
{
    public class TextLogger : AbstractLogger, ITextLogger
    {
        private readonly LoggerConfiguration _loggingConfiguration;
        public TextLogger(IOptions<LoggerConfiguration> loggingConfiguration) : base()
        {
            _loggingConfiguration = loggingConfiguration.Value ?? throw new ArgumentException(nameof(loggingConfiguration));
        }

        protected override void Log(LogLevel logLevel, string module, string message)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}