using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingEngineServer.Rejects;

namespace TradingEngineServer.Rejects
{
    public sealed class RejectCreator
    {
        public static Reject GenerationOrderCoreRejection(IOrderCore rejectedOrder, RejectReason rejectionReason)
        {
            return new Reject(rejectedOrder, rejectionReason);
        }
    }
}