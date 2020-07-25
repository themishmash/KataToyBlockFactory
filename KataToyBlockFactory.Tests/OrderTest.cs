using System;
using System.Linq;
using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class OrderTest
    {

        [Fact]
        public void CanRetrieveOrder()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.DueDate = order.DueDate.AddDays(7);
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
        
            Assert.Equal("James", toyBlockFactory.GetOrder(1).Name);
        }

        [Fact]
        public void HasDueDate()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith St");

            Assert.Equal(DateTime.Today.AddDays(7), order.DueDate.Date);
        }
        

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
    }
}