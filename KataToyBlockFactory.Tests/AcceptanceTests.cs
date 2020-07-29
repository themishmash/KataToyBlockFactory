using System;
using Xunit;

namespace KataToyBlockFactory.Tests
{
    //These tests are intended a happy path flow through the entire application
    public class AcceptanceTests
    {

        [Fact]
        public void Placing_An_Order_Will_Create_New_Order()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.DueDate = DateTime.Today;
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
            
            Assert.Equal("James", order.Name);
            Assert.Equal("123 Smith Street, Fitzroy", order.Address);
           // Assert.Equal(DateTime.Today, order.DueDate);
            Assert.Equal(1, order.OrderNumber);
            Assert.Equal(1, order.CountShape(Shape.Circle));
            Assert.Equal(1, order.CountColor(Color.Red));

            Assert.Equal(OrderStatus.New, toyBlockFactory.GetOrderStatus(1));
            Assert.Equal("James", toyBlockFactory.GetOrder(1).Name);
        }

        [Fact]
        public void Create_Cutting_Report_Will_Return_Number_Of_Shapes_For_Single_Order()
        {
            //Arrange
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            order.AddBlock(Shape.Triangle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
        
            toyBlockFactory.GetCuttingReport(1); 
            
            Assert.Equal(2, CuttingReport.GetShapeCount(Shape.Triangle));
            Assert.Equal(4, CuttingReport.GetShapeCount(Shape.Square));
            Assert.Equal(1, CuttingReport.GetShapeCount(Shape.Circle));
        }
        
        [Fact]
        public void Create_Cutting_Report_Will_Return_Number_Of_Shapes_For_Daily_Orders()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            
            var order2 = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order2.AddBlock(Shape.Triangle, Color.Blue);
            order2.AddBlock(Shape.Triangle, Color.Blue);
            order2.AddBlock(Shape.Triangle, Color.Yellow);
            order2.AddBlock(Shape.Square, Color.Yellow);
            order2.AddBlock(Shape.Square, Color.Red);
        
            toyBlockFactory.GetDailyCuttingReport();
            Assert.Equal(4, CuttingReport.GetShapeCount(Shape.Square));
        }
        
        [Fact]
        public void Create_Painting_Report_Will_Return_Number_For_Single_Order()
        {
            //Arrange
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            order.AddBlock(Shape.Triangle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
            
            toyBlockFactory.GetPaintingReport(1);
            
            Assert.Equal(1, PaintingReport.GetShapeColorCount(Shape.Triangle, Color.Yellow));
            Assert.Equal(2, PaintingReport.GetShapeColorCount(Shape.Square, Color.Red));
        }
        
        //todo duplicate the above test (for unit test) 
        
        

        [Fact]
        public void Create_Painting_Report_Will_Return_Number_For_Daily_Orders()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            
            var order2 = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order2.AddBlock(Shape.Triangle, Color.Blue);
            order2.AddBlock(Shape.Triangle, Color.Blue);
            order2.AddBlock(Shape.Triangle, Color.Yellow);
            order2.AddBlock(Shape.Square, Color.Yellow);
            order2.AddBlock(Shape.Square, Color.Red);

            toyBlockFactory.GetDailyPaintingReport();
            
            Assert.Equal(2, PaintingReport.GetShapeColorCount(Shape.Square, Color.Red));
            Assert.Equal(2, PaintingReport.GetShapeColorCount(Shape.Triangle, Color.Blue));
        }
        
       //todo acceptance test for price/invoice stuff
       [Fact]
       public void Create_Invoice_Report_Will_Return_Price_Of_Order()
       {
           var toyBlockFactory = new ToyBlockFactory();
           var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
           order.AddBlock(Shape.Circle, Color.Blue);
           order.AddBlock(Shape.Square, Color.Blue);
           order.AddBlock(Shape.Square, Color.Yellow);
           order.AddBlock(Shape.Triangle, Color.Red);
           
           var invoiceReport = toyBlockFactory.GetInvoiceReport();
           
           Assert.Equal(8, invoiceReport.GetPrice(order));
       }

    }
}