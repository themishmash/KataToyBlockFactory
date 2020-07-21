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
        public int OrderNumber { get; set; }

        private readonly List<Block> Squares = new List<Block>();
        
        public Order(string name, string address, string date, string redSquare, string blueSquare, string yellowSquare, OrderStatus 
        orderStatus = 
        OrderStatus.New)
        {
            Name = name;
            Address = address;
            Date = AskDate(date);
            OrderStatus = orderStatus;
            OrderNumber = 0;
            Squares = GetSquareOrder(redSquare, blueSquare, yellowSquare);
        }
        
        private static DateTime AskDate(string question)
        {
            var dateTime = Convert.ToDateTime(question);
            return dateTime;
        }

        // private int GetOrderNumber()
        // { 
        //     var count = 0;
        //     count++;
        //     return count;
        // }

        private List<Block> GetSquareOrder(string redSquare, string blueSquare, string yellowSquare)
        {
            var numberOfRedSquares = int.Parse(redSquare);
            var numberOfBlueSquares = int.Parse(blueSquare);
            var numberOfYellowSquares = int.Parse(yellowSquare);
            for (var i = 1; i <= numberOfRedSquares; i++)
            {
                var block = new Block(Shape.Square, Color.Red);
                Squares.Add(block);
            }
            
            for (var i = 1; i <= numberOfBlueSquares; i++)
            {
                var block = new Block(Shape.Square, Color.Blue);
                Squares.Add(block);
            }
            
            for (var i = 1; i <= numberOfYellowSquares; i++)
            {
                var block = new Block(Shape.Square, Color.Yellow);
                Squares.Add(block);
            }
            
            return Squares;
        }

        public int TotalBlocksOrder()
        {
            return Squares.Count;
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