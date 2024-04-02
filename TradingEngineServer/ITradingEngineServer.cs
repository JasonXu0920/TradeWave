using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Core
{
    interface ITradingEngineServer
    {
        Task Run(CancellationToken token);
    }
}