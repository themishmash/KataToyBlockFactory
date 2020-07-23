using System;
using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class Order
    {
        // public string Name { get; }
        // public OrderStatus OrderStatus { get; private set; }
        // public string Address { get; private set; }
        //
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
        //
        // public int OrderNumber { get; set; }
        //
        private DateTime _dueDate = DateTime.Today;
        //
        // private readonly IList <Block>_blocks = new List<Block>();
        //
        public Order(string name, string address)
        {
            Name = name;
            Address = address;
        }
        //
        // public void AddBlock(Shape shape, Color color)
        // {
        //     _blocks.Add(new Block(shape, color));
        // }
        //
        // public IList<Block> GetAllBlocks()
        // {
        //     return _blocks;
        // }


        public void AddBlock(Shape circle, Color blue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<char> Name { get; set; }
        public IEnumerable<char> Address { get; set; }
        public int OrderNumber { get; set; }

        public int CountShape(Shape circle)
        {
            throw new NotImplementedException();
        }

        public int CountColor(Color red)
        {
            throw new NotImplementedException();
        }
    }
}