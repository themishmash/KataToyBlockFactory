using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class InvoiceReportTests
    {
        [Fact]
        public void Total_Price_Based_On_Order_Number()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Yellow);
            order.AddBlock(Shape.Triangle, Color.Red);
            
            var invoiceReport = toyBlockFactory.GetInvoiceReport(1);
            
            Assert.Equal(7, invoiceReport.GetCostTotal());
        }
        
        [Fact]
        public void Daily_Total_Price()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Yellow);

            var order2 = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order2.AddBlock(Shape.Circle, Color.Blue);
            order2.AddBlock(Shape.Square, Color.Yellow);

            var invoiceReport = toyBlockFactory.GetDailyInvoiceReport();
            
            Assert.Equal(8, invoiceReport.GetCostTotal());
        }

        [Fact]
        public void No_Orders_Price_Is_0()
        {
            var toyBlockFactory = new ToyBlockFactory();
            toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");

            var invoiceReport = toyBlockFactory.GetInvoiceReport(1);

            Assert.Equal(0, invoiceReport.GetCostTotal());
        }
        
        [Fact]
        public void No_Orders_Price_Is_0_In_Daily_Total()
        {
            var toyBlockFactory = new ToyBlockFactory();
            toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");

            var invoiceReport = toyBlockFactory.GetDailyInvoiceReport();

            Assert.Equal(0, invoiceReport.GetCostTotal());
        }
        
        
    }
}