using System;
using System.Collections.Generic;
namespace KataToyBlockFactory
{
    public class Order
    {
        //private readonly int _orderNumber;

        public string Name { get; }
        public OrderStatus OrderStatus { get; private set; }
        public string Address { get; private set; }

        public DateTime Date { get; }
        public int OrderNumber { get; private set; }
        
        public readonly List<Block> Blocks = new List<Block>();
        
        //List<Block> blocks
        // public Order(string name, string address, string date, int orderNumber, string blockNumber)
        // {
        //     Name = name;
        //     Address = address;
        //     Date = AskDate(date);
        //     OrderNumber = orderNumber;
        //     Blocks = GetBlueSquareOrder(blockNumber);
        // }

        public Order(string name, string address, string date, string blockNumber)
        {
            Name = name;
            Address = address;
            Date = AskDate(date);
            OrderNumber = GetOrderNumber();
            Blocks = GetBlueSquareOrder(blockNumber);
        }


        private DateTime AskDate(string question)
        {
            var dateTime = Convert.ToDateTime(question);
            return dateTime;
        }

        private int GetOrderNumber()
        { 
            var count = 0;
            count++;
            return count;
        }

        private List<Block> GetBlueSquareOrder(string blueSquare)
        {
            var numberOfBlueSquares = int.Parse(blueSquare);
            for (var i = 1; i <= numberOfBlueSquares; i++)
            {
                var block = new Block(Shape.Square, Color.Blue);
                Blocks.Add(block);
            }

            return Blocks;
        }

        public int TotalBlocks()
        {
            return Blocks.Count;
        }
        
        // public Order(string name, string address, string date, int orderNumber, OrderStatus orderStatus = 
        // OrderStatus.New)
        // {
        //     Name = name;
        //     Address = address;
        //     Date = date;
        //     OrderNumber = orderNumber;
        //     OrderStatus = orderStatus;
        // }
        
    }
    
}