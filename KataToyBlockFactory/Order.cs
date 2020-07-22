using System;
using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class Order
    {
        public string Name { get; }
        public OrderStatus OrderStatus { get; private set; }
        public string Address { get; private set; }

        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                if (value < DateTime.Today)
                    throw new ArgumentOutOfRangeException(nameof(DueDate), "Due date must be in future");
                _dueDate = value;
            }
        }

        public int OrderNumber { get; set; }

        private DateTime _dueDate = DateTime.Today;
        
        private readonly IList <Block>_blocks = new List<Block>();
        
        public Order(string name, string address)
        {
            Name = name;
            Address = address;
            OrderNumber = 0;
        }
        
        public void AddBlock(Shape shape, Color color)
        {
            _blocks.Add(new Block(shape, color));
        }

        public int GetRedSquares()
        {
            return _blocks.Count(block => block.Shape == Shape.Square && block.Color == Color.Red);
        }
        

      
    }
}