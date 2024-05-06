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
        private readonly Dictionary<long, OrderBookEntry> _orders = new Dictionary<long, OrderBookEntry>();
        private readonly SortedSet<Limit> _askLimits = new SortedSet<Limit>(AskLimitComparer.Comparer);
        private readonly SortedSet<Limit> _bidLimits = new SortedSet<Limit>(BidLimitComparer.Comparer);  

        public Orderbook(Security instrument)
        {
            _instrument = instrument;
        }
        public int Count => _orders.Count;

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
            return _orders.ContainsKey(orderId);
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