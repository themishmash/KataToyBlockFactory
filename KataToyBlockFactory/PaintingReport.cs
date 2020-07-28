using System;
using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class PaintingReport
    {
        
        private static List<Block> _blocks;

        private PaintingReport(List<Block> blocks)
        {
            _blocks = blocks;
        }

        public static void CreatePaintingReport(Order order)
        {
            _blocks = new List<Block>();
            var blocks = order.GetBlocks();
            _blocks = blocks.OrderBy(block => block.Shape).ThenBy(block => block.Color).ToList();
            
        }

        public static int GetShapeColorCount(Shape shape, Color color)
        {
            return _blocks.Count(block => block.Shape == shape && block.Color == color);
        }
    }
    
}