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
            var baseLimit = new Limit(order.Price);
            AddOrder(order, baseLimit, order.IsBuySide? _bidLimits : _askLimits, _orders);
        }

        private static void AddOrder(Order order, Limit baseLimit, SortedSet<Limit> limitLevels, Dictionary<long, OrderBookEntry> internalOrderbook)
        {
            if (limitLevels.TryGetValue(baseLimit, out Limit limit))
            {
                OrderBookEntry orderBookEntry = new OrderBookEntry(order, baseLimit);
                if (limit.Head == null)
                {
                    limit.Head = orderBookEntry;
                    limit.Tail = orderBookEntry;
                }
                else 
                {
                    OrderBookEntry tailPointer = limit.Tail;
                    tailPointer.Next = orderBookEntry;
                    orderBookEntry.Previous = tailPointer;
                    limit.Tail = orderBookEntry;
                }
                internalOrderbook.Add(order.OrderId, orderBookEntry);
            }
            else 
            {
                limitLevels.Add(baseLimit);
                OrderBookEntry orderBookEntry = new OrderBookEntry(order, baseLimit);
                baseLimit.Head = orderBookEntry;
                baseLimit.Tail = orderBookEntry;
                internalOrderbook.Add(order.OrderId, orderBookEntry);
            }
        }

        public void ChangeOrder(ModifyOrder modifyOrder)
        {
            if (_orders.TryGetValue(modifyOrder.OrderId, out OrderBookEntry obe))
            {
                RemoveOrder(modifyOrder.ToCancelOrder());
                AddOrder(modifyOrder.ToNewOrder(), obe.ParentLimit, modifyOrder.IsBuySide? _bidLimits: _askLimits, _orders);
            }
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
            if (_orders.TryGetValue(cancelOrder.OrderId, out var obe))
            {
                RemoveOrder(cancelOrder.OrderId, obe, _orders);
            }
        }

        private static void RemoveOrder(long orderId, OrderBookEntry obe, Dictionary<long, OrderBookEntry> internalBook)
        {
            // dealing the position of orderbook entry within the linked list
            if (obe.Previous != null && obe.Next != null)
            {
                obe.Next.Previous = obe.Previous;
                obe.Previous.Next = obe.Next;   
            }
            else if (obe.Previous != null)
            {
                obe.Previous.Next = null;
            }
            else if (obe.Next != null)
            {
                obe.Next.Previous = null;
            }

            // deal with orderbook entry on limit-level
            if (obe.ParentLimit.Head == obe && obe.ParentLimit.Tail == obe)
            {
                // one order on this level
                obe.ParentLimit.Head = null;
                obe.ParentLimit.Tail = null;
            }
            else if (obe.ParentLimit.Head == obe)
            {
                // more than one order, but obe is the first order
                obe.ParentLimit.Head = obe.Next;
            }
            else if (obe.ParentLimit.Tail == obe)
            {
                // more than one order, but obe is the last order on level
                obe.ParentLimit.Tail = obe.Previous;
            }

            internalBook.Remove(orderId);
        }
    }
}