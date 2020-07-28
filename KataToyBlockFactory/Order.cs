using System;
using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class Order
    {
        public string Name { get; }
        public OrderStatus OrderStatus { get; set; }
        public string Address { get; }
        
        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                if (value < DateTime.Today)
                    throw new ArgumentOutOfRangeException(nameof(DueDate), "Due date must be in future");
                else
                {
                    _dueDate = value.AddDays(7);
                }
                
            }
        }
        
        public int OrderNumber { get; set; }

        private DateTime _dueDate;
        
        private readonly IList <Block>_blocks = new List<Block>();
        
        public Order(string name, string address)
        {
            Name = name;
            Address = address;
        }
        
        public void AddBlock(Shape shape, Color color)
        {
            _blocks.Add(new Block(shape, color));
        }
        
        public int CountShape(Shape shape)
        {
            return _blocks.Count(block => block.Shape == shape);
        }

        public int CountColor(Color color)
        {
            return _blocks.Count(block => block.Color == color);
        }

        public int CountShapeAndColor(Shape shape, Color color)
        {
            return _blocks.Count(block => block.Shape == shape && block.Color == color);
        }

        public IEnumerable<Block> GetBlocks()
        {
            return _blocks;
        }
    
        
    }
}