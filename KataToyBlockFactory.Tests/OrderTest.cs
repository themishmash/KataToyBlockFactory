using Xunit;

namespace KataToyBlockFactory.Tests
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

        // [Fact]
        // public void OrdersHaveAllNecessaryFields()
        // {
        //    //  var order = new Order("James", "123 Smith Street, Fitzroy", "20 October 2020", 1);
        //    //
        //    //  Assert.Equal(OrderStatus.New, order.OrderStatus);
        //    //  Assert.Equal("James", order.Name);
        //    //  Assert.Equal("123 Smith Street, Fitzroy", order.Address);
        //    // // Assert.Equal("20 October 2020", order.Date);
        //    //  Assert.Equal(1, order.OrderNumber);
        //    //  Assert.Equal(1, order.GetBlockQuantity());
        // }
        
        
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
        [Fact]
        public void CanCreateOrder()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy", "10/10/20", "5", "2", "1" );
            var expectedDate = order.Date;
            
            Assert.Equal(OrderStatus.New, order.OrderStatus);
            Assert.Equal("James", order.Name);
            Assert.Equal("123 Smith Street, Fitzroy", order.Address);
            Assert.Equal(expectedDate, order.Date);
            Assert.Equal(1, order.OrderNumber);
            Assert.Equal(8, order.TotalBlocksOrder());
            Assert.Equal(1, toyBlockFactory.GetTotalOrders());
        }

        [Fact]
        public void CanCreateOrderWithIncreasingOrderNumber()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy", "10/10/20", "5", "2", "1" );
            var order2 = toyBlockFactory.CreateOrder("Joe", "123 Coding Road", "10/10/20", "4", "2", "3");
            
            Assert.Equal(1, order.OrderNumber);
            Assert.Equal(2, order2.OrderNumber);
            Assert.Equal(2, toyBlockFactory.GetTotalOrders());
        }

        [Fact]
        public void CanCreatePaintingReport()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy", "10/10/20", "5", "2", "1");
          //  var painting = toyBlockFactory.CreatePaintingReport(order);
            
           // Assert.Equal(5, painting.GetRedSquaresToBePainted());

        }
    }
}