using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Rejects
{
    public enum RejectionReason
    {
        Unknown,
        OrderNotFound,
        InstrumentNotFound,
        AttemptingToModifyWrongSide,
    }
}