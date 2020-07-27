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
        public void HasDueDateOfOneWeek()
        {
            //show default due date to be one week
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith St");

            Assert.Equal(DateTime.Today.AddDays(7), order.DueDate.Date);
        }
        
        //todo set another test to show can't set date to past
        
        
    }
}