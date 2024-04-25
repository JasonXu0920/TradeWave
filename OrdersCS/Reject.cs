using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingEngineServer.Orders;

namespace TradingEngineServer.Rejects
{
    public class Reject : IOrderCore
    {
        public Reject(IOrderCore rejectedOrder, RejectReason rejectionReason)
        {
            // PROPERTIES //
            RejectionReason = rejectionReason;

            // FIELDS //
            _orderCore = rejectedOrder;
        }

        // PROPERTIES // 
        public RejectReason RejectionReason { get; private set; }
        public long OrderId => _orderCore.OrderId;
        public string Username => _orderCore.Username;
        public int SecurityId => _orderCore.SecurityId;

        // FIELDS //
        private readonly IOrderCore _orderCore;
    }
}