using System;
using Xunit;

namespace KataToyBlockFactory.Tests
{
    //These tests are intended a happy path flow through the entire application
    public class AcceptanceTests
    {
        private readonly ToyBlockFactory _toyBlockFactory;
        public AcceptanceTests()
        {
            var toyBlockFactory = new ToyBlockFactory(new NullInputOutput());
            _toyBlockFactory = toyBlockFactory;
        }
        [Fact]
        public void Placing_An_Order_Will_Create_New_Order()
        {
            var order = _toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
            
            Assert.Equal("James", order.Name);
            Assert.Equal("123 Smith Street, Fitzroy", order.Address);
           Assert.Equal(DateTime.Today.AddDays(7), order.DueDate);
            Assert.Equal(1, order.OrderNumber);
            Assert.Equal(1, order.CountShape(Shape.Circle));
            Assert.Equal(1, order.CountColor(Color.Red));

            Assert.Equal(OrderStatus.New, _toyBlockFactory.GetOrderStatus(1));
            Assert.Equal("James", _toyBlockFactory.GetOrder(1).Name);
        }

        [Fact]
        public void Create_Cutting_Report_Will_Return_Number_Of_Shapes_For_Single_Order()
        {
            //Arrange
            var order = _toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            order.AddBlock(Shape.Triangle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
        
            var cuttingReport = _toyBlockFactory.GetCuttingReport(1); 
            
            Assert.Equal(2, cuttingReport.GetShapeCount(Shape.Triangle));
            Assert.Equal(4, cuttingReport.GetShapeCount(Shape.Square));
            Assert.Equal(1, cuttingReport.GetShapeCount(Shape.Circle));
        }
        
        [Fact]
        public void Create_Cutting_Report_Will_Return_Number_Of_Shapes_For_Daily_Orders()
        {
            var order = _toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            
            var order2 = _toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order2.AddBlock(Shape.Triangle, Color.Blue);
            order2.AddBlock(Shape.Triangle, Color.Blue);
            order2.AddBlock(Shape.Triangle, Color.Yellow);
            order2.AddBlock(Shape.Square, Color.Yellow);
            order2.AddBlock(Shape.Square, Color.Red);
        
            var cuttingReport = _toyBlockFactory.GetDailyCuttingReport();
            Assert.Equal(4, cuttingReport.GetShapeCount(Shape.Square));
        }
        
        [Fact]
        public void Create_Painting_Report_Will_Return_Number_For_Single_Order()
        {
            //Arrange
            var order = _toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            order.AddBlock(Shape.Triangle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
            
            var paintingReport = _toyBlockFactory.GetPaintingReport(1);
            
            Assert.Equal(1, paintingReport.GetShapeColorCount(Shape.Triangle, Color.Yellow));
            Assert.Equal(2, paintingReport.GetShapeColorCount(Shape.Square, Color.Red));
        }
        
        [Fact]
        public void Create_Painting_Report_Will_Return_Number_For_Daily_Orders()
        {
            var order = _toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            
            var order2 = _toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order2.AddBlock(Shape.Triangle, Color.Blue);
            order2.AddBlock(Shape.Triangle, Color.Blue);
            order2.AddBlock(Shape.Triangle, Color.Yellow);
            order2.AddBlock(Shape.Square, Color.Yellow);
            order2.AddBlock(Shape.Square, Color.Red);

            var paintingReport = _toyBlockFactory.GetDailyPaintingReport();
            
            Assert.Equal(2, paintingReport.GetShapeColorCount(Shape.Square, Color.Red));
            Assert.Equal(2, paintingReport.GetShapeColorCount(Shape.Triangle, Color.Blue));
        }
        
       [Fact]
       public void Create_Invoice_Report_Will_Return_Price_Of_Order()
       {
           var order = _toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
           order.AddBlock(Shape.Circle, Color.Blue);
           order.AddBlock(Shape.Square, Color.Blue);
           order.AddBlock(Shape.Square, Color.Yellow);
           order.AddBlock(Shape.Triangle, Color.Red);
           
           var invoiceReport = _toyBlockFactory.GetInvoiceReport(1);
           
           Assert.Equal(8, invoiceReport.GetCostTotal());
       }
       
       [Fact]
       public void Create_Invoice_Report_Will_Return_Price_For_Daily_Orders()
       {
           var order = _toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
           order.AddBlock(Shape.Circle, Color.Blue);
           order.AddBlock(Shape.Square, Color.Blue);
           order.AddBlock(Shape.Square, Color.Red);
            
           var order2 = _toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
           order2.AddBlock(Shape.Triangle, Color.Blue);
           order2.AddBlock(Shape.Triangle, Color.Blue);
           order2.AddBlock(Shape.Triangle, Color.Yellow);
           order2.AddBlock(Shape.Square, Color.Yellow);
           order2.AddBlock(Shape.Square, Color.Red);

           var invoiceReport = _toyBlockFactory.GetDailyInvoiceReport();
            
           Assert.Equal(15, invoiceReport.GetCostTotal());
       }
       
    }
}