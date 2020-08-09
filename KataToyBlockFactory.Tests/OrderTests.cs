using System;
using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class OrderTests
    {
        private readonly ToyBlockFactory _toyBlockFactory;
        public OrderTests()
        {
            var toyBlockFactory = new ToyBlockFactory(new NullInputOutput());
            _toyBlockFactory = toyBlockFactory;
        }

        [Fact]
        public void Can_Retrieve_Order()
        {
            var order = _toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
        
            Assert.Equal("James", _toyBlockFactory.GetOrder(1).Name);
        }
        
        [Fact]
        public void Can_Set_Due_Date()
        {
            var order = _toyBlockFactory.CreateOrder("James", "123 Smith st");
            order.DueDate = new DateTime(2020, 10, 10);
            
            Assert.Equal(DateTime.Parse("October 10 2020"), order.DueDate);
        }

        [Fact]
        public void Has_Default_Due_Date_One_Week()
        {
            var order = _toyBlockFactory.CreateOrder("James", "123 Smith St");

            Assert.Equal(DateTime.Today.AddDays(7), order.DueDate);
        }
        
        [Fact]
        public void Due_Date_Can_Only_Be_Set_To_Future_Date()
        {
            var order = _toyBlockFactory.CreateOrder("James", "123 Smith Street");

            Assert.Throws<ArgumentOutOfRangeException>(() => order.DueDate = new DateTime(2018, 7, 24));
            
        }
        
    }
}