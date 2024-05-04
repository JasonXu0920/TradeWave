using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using TradingEngineServer.Instrument;
using TradingEngineServer.Orders;

namespace TradingEngineServer.Orderbook
{
    public class Orderbook : IRetrievalOrderbook
    {
        // PRIVATE FIELDS//
        private readonly Security _instrument;
        public Orderbook(Security instrument)
        {
            _instrument = instrument;
        }
        public int Count => throw new NotImplementedException();

        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void ChangeOrder(ModifyOrder modifyOrder)
        {
            throw new NotImplementedException();
        }

        public bool ContainsOrder(long orderId)
        {
            throw new NotImplementedException();
        }

        public List<OrderBookEntry> GetAskOrders()
        {
            throw new NotImplementedException();
        }

        public List<OrderBookEntry> GetBidOrders()
        {
            throw new NotImplementedException();
        }

        public OrderbookSpread GetSpread()
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(CancelOrder cancelOrder)
        {
            throw new NotImplementedException();
        }
    }
}