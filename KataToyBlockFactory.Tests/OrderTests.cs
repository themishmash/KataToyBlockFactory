using System;
using System.Linq;
using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class OrderTests
    {

        [Fact]
        public void Can_Retrieve_Order()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
        
            Assert.Equal("James", toyBlockFactory.GetOrder(1).Name);
        }

        [Fact]
        public void Has_Default_Due_Date_One_Week()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith St");
            //order.DueDate = DateTime.Today;

            Assert.Equal(DateTime.Today.AddDays(7), order.DueDate);
        }
        
        //todo set another test to show can't set date to past
        [Fact]
        public void Due_Date_Can_Only_Be_Set_To_Future_Date()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street");

            Assert.Throws<ArgumentOutOfRangeException>(() => order.DueDate = new DateTime(2018, 7, 24));
            
        }
    }
}