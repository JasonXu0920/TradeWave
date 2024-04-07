using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Logging
{
    public class TextLogger : AbstractLogger, ITextLogger
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        protected override void Log(LogLevel logLevel, string module, string message)
        {
            throw new NotImplementedException();
        }
    }
}