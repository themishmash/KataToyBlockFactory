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
        //public string Date { get; private set; }
        
        public DateTime Date { get; }
        public int OrderNumber { get; private set; }
        
        public readonly List<Block> Blocks = new List<Block>();
        
        // public Order(string name, string address, string date, int orderNumber, OrderStatus orderStatus = 
        // OrderStatus.New)
        // {
        //     Name = name;
        //     Address = address;
        //     Date = date;
        //     OrderNumber = orderNumber;
        //     OrderStatus = orderStatus;
        // }


        public Order(string name, string address, DateTime date, int orderNumber, List<Block> blocks)
        {
            
            Name = name;
            Address = address;
            Date = date;
            OrderNumber = orderNumber;
            Blocks = blocks;
        }

        // public int GetBlockQuantity()
        // {
        //     var block = new Block(); //this will eventually match the input of user
        //     _blocks.Add(block);
        //     return _blocks.Count;
        // }
    }
    
}