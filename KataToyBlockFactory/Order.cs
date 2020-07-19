using System.Collections.Generic;
namespace KataToyBlockFactory
{
    public class Order
    {
        public string Name { get; }
        public OrderStatus OrderStatus { get; private set; }
        public string Address { get; private set; }
        public string Date { get; private set; }
        public int OrderNumber { get; private set; }
        
        private readonly List<Block> _blocks = new List<Block>(); 

        public Order(string name, string address, string date, int orderNumber, OrderStatus orderStatus = 
        OrderStatus.New)
        {
            Name = name;
            Address = address;
            Date = date;
            OrderNumber = orderNumber;
            OrderStatus = orderStatus;
        }
        


        public int GetBlockQuantity()
        {
            var block = new Block(); //this will eventually match the input of user
            _blocks.Add(block);
            return _blocks.Count;
        }
    }
    
}