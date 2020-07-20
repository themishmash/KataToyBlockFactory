using System;
using KataToyBlockFactory;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class OrderTest
    {
        // [Fact]
        // public void NewOrdersHaveOrderStatusOfNew()
        // {
        //     var order = new Order("James", "123 Smith Street, Fitzroy");
        //     // var paintingReport = new PaintingReport();
        //     // var cuttingReport = new CuttingReport();
        //     // var priceCalculator = new PriceCalculator();
        //     // var toyBlockFactory = new ToyBlockFactory(order, paintingReport, cuttingReport, priceCalculator);
        //     //
        //     // Assert.Equal(1, toyBlockFactory.GetNumberOfBlocksToBePainted());
        //     Assert.Equal(OrderStatus.New, order.OrderStatus);
        // }

        [Fact]
        public void OrdersHaveAllNecessaryFields()
        {
           //  var order = new Order("James", "123 Smith Street, Fitzroy", "20 October 2020", 1);
           //
           //  Assert.Equal(OrderStatus.New, order.OrderStatus);
           //  Assert.Equal("James", order.Name);
           //  Assert.Equal("123 Smith Street, Fitzroy", order.Address);
           // // Assert.Equal("20 October 2020", order.Date);
           //  Assert.Equal(1, order.OrderNumber);
           //  Assert.Equal(1, order.GetBlockQuantity());
        }
        
        [Fact]
        public void OrdersHaveInput()
        {
            var orderInput = new OrderInput("James", "123 Smith Street, Fitzroy", "10/10/2020", "5");
            var order = new Order(orderInput.Name, orderInput.Address, orderInput.Date, orderInput.OrderNumber, orderInput.BlockOrder);
            var expectedDate = orderInput.Date;
            
            Assert.Equal(OrderStatus.New, order.OrderStatus);
            Assert.Equal("James", order.Name);
            Assert.Equal("123 Smith Street, Fitzroy", order.Address);
            Assert.Equal(expectedDate, order.Date);
            Assert.Equal(1, order.OrderNumber);
            Assert.Equal(5, order.Blocks.Count);
        }
    }
}