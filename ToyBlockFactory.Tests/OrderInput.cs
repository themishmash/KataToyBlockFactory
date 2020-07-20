using System;
using System.Collections.Generic;
using KataToyBlockFactory;

namespace ToyBlockFactory.Tests
{
    public class OrderInput
    {
        public string Name { get; }
        public string Address { get; }
        public DateTime Date { get; }
        public int OrderNumber { get; }
        
        public readonly List<Block> BlockOrder = new List<Block>();

        static int count = 0;

        public OrderInput(string name, string address, string date, string blueSquare)
        {
            Name = name;
            Address = address;
            Date = GetDate(date);
            OrderNumber = GetOrderNumber();
            BlockOrder = GetBlueSquareOrder(blueSquare);
        }
        
        private DateTime GetDate(string date)
        {
            var dateTime = Convert.ToDateTime(date);
            return dateTime;
        }
        private int GetOrderNumber()
        {
            count++;
            return count;
        }
        
        private List<Block> GetBlueSquareOrder(string blueSquare)
        {
            var convertToInt = Int32.Parse(blueSquare);
            for (var i = 1; i <= convertToInt; i++)
            {
                var block = new Block();
                BlockOrder.Add(block);
            }
            return BlockOrder;
        }
        
        
    }
}