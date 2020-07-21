using System;
using System.Collections.Generic;
using System.Linq;

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

        public string RedSquare;
        public string BlueSquare;
        public string YellowSquare;

        public readonly List<Block> Squares = new List<Block>();
        
        public Order(string name, string address, string date, int redSquare, int blueSquare, int yellowSquare, 
        OrderStatus 
        orderStatus = 
        OrderStatus.New)
        {
            Name = name;
            Address = address;
            Date = AskDate(date);
            OrderStatus = orderStatus;
            OrderNumber = 0;
            // RedSquare = redSquare;
            // BlueSquare = blueSquare;
            // YellowSquare = yellowSquare;
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

        private List<Block> GetSquareOrder(int redSquare, int blueSquare, int yellowSquare)
        {
           // var redSquare = int.Parse(redSquare);
            //var blueSquare = int.Parse(blueSquare);
            //var numberOfYellowSquares = int.Parse(yellowSquare);
            for (var i = 1; i <= redSquare; i++)
            {
                var block = new Block(Shape.Square, Color.Red);
                Squares.Add(block);
            }
            
            for (var i = 1; i <= blueSquare; i++)
            {
                var block = new Block(Shape.Square, Color.Blue);
                Squares.Add(block);
            }
            
            for (var i = 1; i <= yellowSquare; i++)
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

        public int GetRedSquares()
        {
            return Squares.Count(x => x.Shape == Shape.Square && x.Color == Color.Red);
        }


        public int GetBlueSquares()
        {
            return Squares.Count(x => x.Shape == Shape.Square && x.Color == Color.Blue);
        }

        public int GetYellowSquares()
        {
            return Squares.Count(x => x.Shape == Shape.Square && x.Color == Color.Yellow);
        }
    }
    
}