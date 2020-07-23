using System;
using System.Linq;
using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class OrderTest
    {


        /*
             * new block factory
             * factory . create order( )   return new Order
             * order . add block (shape, colour)
             *
             * assert order.Name ==
             * Assert order.TotalBlocks = 39
             *
             *
             * assert factory . TotalOrders == 2
             *
             *
             *
             * factory.getInvoice (order)
             *
             *
             * factory . getpaitingreport()
             *
             * 
             */

        //create new toy block factory
        //will need inputoutput interface
       
        
        // [Fact]
        // public void CanRetrieveOrder()
        // {
        //     var toyBlockFactory = new ToyBlockFactory();
        //     var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
        //     order.DueDate = order.DueDate.AddDays(7);
        //     order.AddBlock(Shape.Circle, Color.Blue);
        //     order.AddBlock(Shape.Triangle, Color.Yellow);
        //     order.AddBlock(Shape.Square, Color.Red);
        //
        //     Assert.Equal("James", toyBlockFactory.GetOrder(1).Name);
        // }
        //
        // [Fact]
        // public void GetBlocksFromOrder()
        // {
        //     var toyBlockFactory = new ToyBlockFactory();
        //     var order = toyBlockFactory.CreateOrder("James", "12 Smith street");
        //     order.AddBlock(Shape.Square, Color.Blue);
        //     order.AddBlock(Shape.Triangle, Color.Red);
        //     order.AddBlock(Shape.Triangle, Color.Blue);
        //
        //     var result = toyBlockFactory.GetBlocksFromOrder(); //put into list. create cuting report is list of all blocks
        //     
        //     Assert.Equal(1, result.Count(x => x.Shape == Shape.Square));
        //     Assert.Equal(2, result.Count(x => x.Shape == Shape.Triangle));
        //     Assert.Equal(2, result.Count(x=> x.Color == Color.Blue));
        //     Assert.Equal(1, result.Count(x=>x.Color == Color.Red));
        //    
        // }

        
        

        // [Fact]
        // public void CanCreateOrderWithIncreasingOrderNumber()
        // {
        //     var toyBlockFactory = new ToyBlockFactory();
        //     //var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy", "10/10/20", 5, 2, 1 );
        //     //var order2 = toyBlockFactory.CreateOrder("Joe", "123 Coding Road", "10/10/20", 4, 2, 3);
        //     
        //     Assert.Equal(1, order.OrderNumber);
        //     Assert.Equal(2, order2.OrderNumber);
        //     Assert.Equal(2, toyBlockFactory.GetTotalOrders());
        // }

        // [Fact]
        // public void CanTotalBlocksByShapeAndColor()
        // {
        //     var toyBlockFactory = new ToyBlockFactory();
        //     toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy", "10/10/20", 5, 2, 1);
        //     toyBlockFactory.CreateOrder("Jimbo", "12 Smith Street, Fitzroy", "10/10/20", 5, 2, 1);
        //
        //     Assert.Equal(10, toyBlockFactory.GetTotalRedSquares());
        //     Assert.Equal(4, toyBlockFactory.GetTotalBlueSquares());
        //     Assert.Equal(2, toyBlockFactory.GetTotalYellowSquares());
        //    
        //    //todo create method in toyblock factory to add blocks to be painted? eg find all that are square red, square blue, square yellow etc. 
        //    //todo find redsquares in order class
        // }

        //[Fact]
        // public void CanTotalBlocksByShape()
        // {
        //     var toyBlockFactory = new ToyBlockFactory();
        //     toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy", "10/10/20", 5, 2, 1, 2, 2, 2, 1, 1, 1);
        //     toyBlockFactory.CreateOrder("Jimbo", "12 Smith Street, Fitzroy", "10/10/20", 5, 2, 1, 1, 0, 1, 1, 1, 1);
        //     
        //     Assert.Equal(16, toyBlockFactory.GetTotalSquares());
        //     Assert.Equal(8, toyBlockFactory.GetTotalTriangles());
        //     Assert.Equal(6, toyBlockFactory.GetTotalCircles());
        // }

        // [Fact]
        // public void OrdersCanHavePrice()
        // {
        //     var toyBlockFactory = new ToyBlockFactory();
        //     var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy", "10/10/20", 1,1,1,1,1,1,1,1,1);
        //     var priceCalculator = new PriceCalculator(order);
        //     
        //     Assert.Equal();
        // }
        
    }
}