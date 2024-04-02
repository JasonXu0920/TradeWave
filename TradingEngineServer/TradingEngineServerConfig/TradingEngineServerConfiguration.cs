using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Core.TradingEngineServerConfig
{
    class TradingEngineServerConfiguration
    {
        public TradingEngineServerSettings TradingEngineServerSettings {get; set;}
    }

    class TradingEngineServerSettings
    {
        public int Port {get; set;}
    }
}