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
        

        // private readonly List<Block> _squares = new List<Block>();
        // private readonly List<Block> _triangles = new List<Block>();
        // private readonly List<Block> _circles = new List<Block>();
       

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
        

        // public Order(string name, string address, string date, int redSquare, int blueSquare, int yellowSquare,
        //     OrderStatus orderStatus = OrderStatus.New)
        // {
        //     Name = name;
        //     Address = address;
        //     DueDate = AskDate(date);
        //     OrderStatus = orderStatus;
        //     //OrderNumber = 0;
        //     //_squares = GetSquareOrder(redSquare, blueSquare, yellowSquare);
        // }

        // public Order(string name, string address, string date, int redSquare, int blueSquare, int yellowSquare, int
        //         redTriangle, int blueTriangle, int yellowTriangle, int redCircle, int blueCircle, int yellowCircle,
        //     OrderStatus orderStatus = OrderStatus.New)
        // {
        //     Name = name;
        //     Address = address;
        //     DueDate = AskDate(date);
        //     OrderStatus = orderStatus;
        //     //OrderNumber = 0;
        //    // _squares = GetSquareOrder(redSquare, blueSquare, yellowSquare);
        //     //_triangles = GetTriangleOrder(redTriangle, blueTriangle, yellowTriangle);
        //     //_circles = GetCircleOrder(redCircle, blueCircle, yellowCircle);
        // }


        // private static DateTime AskDate(string question)
        // {
        //     var dateTime = Convert.ToDateTime(question);
        //     return dateTime;
        // }

        // private List<Block> GetSquareOrder(int redSquare, int blueSquare, int yellowSquare)
        // {
        //     for (var i = 1; i <= redSquare; i++)
        //     {
        //         var block = new Block(Shape.Square, Color.Red);
        //         //_squares.Add(block);
        //     }
        //
        //     for (var i = 1; i <= blueSquare; i++)
        //     {
        //         var block = new Block(Shape.Square, Color.Blue);
        //         //_squares.Add(block);
        //     }
        //
        //     for (var i = 1; i <= yellowSquare; i++)
        //     {
        //         var block = new Block(Shape.Square, Color.Yellow);
        //         //_squares.Add(block);
        //     }
        //
        //     return _squares;
        // }

        // private List<Block> GetTriangleOrder(int redTriangle, int blueTriangle, int yellowTriangle)
        // {
        //     for (var i = 1; i <= redTriangle; i++)
        //     {
        //         var block = new Block(Shape.Triangle, Color.Red);
        //         _triangles.Add(block);
        //     }
        //
        //     for (var i = 1; i <= blueTriangle; i++)
        //     {
        //         var block = new Block(Shape.Triangle, Color.Blue);
        //         _triangles.Add(block);
        //     }
        //
        //     for (var i = 1; i <= yellowTriangle; i++)
        //     {
        //         var block = new Block(Shape.Triangle, Color.Yellow);
        //         _triangles.Add(block);
        //     }
        //
        //     return _triangles;
        // }
        //
        // private List<Block> GetCircleOrder(int redCircle, int blueCircle, int yellowCircle)
        // {
        //     for (var i = 1; i <= redCircle; i++)
        //     {
        //         var block = new Block(Shape.Circle, Color.Red);
        //         _circles.Add(block);
        //     }
        //
        //     for (var i = 1; i <= blueCircle; i++)
        //     {
        //         var block = new Block(Shape.Circle, Color.Blue);
        //         _circles.Add(block);
        //     }
        //
        //     for (var i = 1; i <= yellowCircle; i++)
        //     {
        //         var block = new Block(Shape.Circle, Color.Yellow);
        //         _circles.Add(block);
        //     }
        //
        //     return _circles;
        // }

        // public int TotalBlocksOrder()
        // {
        //     return GetSquares() + GetTriangles() + GetCircles();
        // }

        // public int GetSquares()
        // {
        //     return _squares.Count;
        // }
        //
        // public int GetTriangles()
        // {
        //     return _triangles.Count;
        // }
        //
        // public int GetCircles()
        // {
        //     return _circles.Count;
        // }
        //
        // public int GetRedSquares()
        // {
        //     return _squares.Count(x => x.Shape == Shape.Square && x.Color == Color.Red);
        // }
        //
        // public int GetBlueSquares()
        // {
        //     return _squares.Count(x => x.Shape == Shape.Square && x.Color == Color.Blue);
        // }
        //
        // public int GetYellowSquares()
        // {
        //     return _squares.Count(x => x.Shape == Shape.Square && x.Color == Color.Yellow);
        // }
        //
        // public int GetRedTriangles()
        // {
        //     return _triangles.Count(x => x.Shape == Shape.Triangle && x.Color == Color.Red);
        // }
        //
        // public int GetBlueTriangles()
        // {
        //     return _triangles.Count(x => x.Shape == Shape.Triangle && x.Color == Color.Blue);
        // }
        //
        // public int GetYellowTriangles()
        // {
        //     return _triangles.Count(x => x.Shape == Shape.Triangle && x.Color == Color.Yellow);
        // }
        //
        // public int GetRedCircles()
        // {
        //     return _circles.Count(x => x.Shape == Shape.Circle && x.Color == Color.Red);
        // }
        //
        // public int GetBlueCircles()
        // {
        //     return _circles.Count(x => x.Shape == Shape.Circle && x.Color == Color.Blue);
        // }
        //
        // public int GetYellowCircles()
        // {
        //     return _circles.Count(x => x.Shape == Shape.Circle && x.Color == Color.Yellow);
        // }
        //

      
    }
}