namespace KataToyBlockFactory
{
    public class Block
    {
        public Shape Shape { get; }
        public Color Color { get; }
        
        //public int Price { get; }
        
        public Block(Shape shape, Color color)
        {
            Shape = shape;
            Color = color;
            //Price = GetBlockPrice();
        }

     
    }
}