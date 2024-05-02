using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingEngineServer.Orders;

namespace TradingEngineServer.Orderbook
{
    public interface IRetrievalOrderbook : IOrderEntryOrderbook
    {
        List<OrderBookEntry> GetAskOrders();
        List<OrderBookEntry> GetBidOrders();
    }
}