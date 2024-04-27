using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    public class Limit
    {
        public long Price { get; set; }
        public OrderBookEntry Head { get; set; }
        public OrderBookEntry Tail { get; set; }
        public uint GetLevelOrderCount()
        {
            uint orderCount = 0;
            OrderBookEntry headPointer = Head;
            while (headPointer != null)
            {
                if(headPointer.CurrentOrder.CurrentQuantity != 0)
                   orderCount++;
                headPointer = headPointer.Next;
            }
            return orderCount;
        }
        public uint GetLevelOrderQuantity()
        {
            uint orderQuantity = 0;
            OrderBookEntry headPointer = Head;
            while(headPointer != null)
            {
                orderQuantity += headPointer.CurrentOrder.CurrentQuantity;
                headPointer = headPointer.Next;
            }
            return orderQuantity;
        }
        public bool IsEmpty
        {
            get
            {
                return Head == null && Tail == null;        
            }
        }
        public Side side
        {
            get
            {
                if(IsEmpty)
                   return Side.Unknown;
                else
                {
                    return Head.CurrentOrder.IsBuySide ? Side.Bid : Side.Ask;
                }

            }
        }

    }
}