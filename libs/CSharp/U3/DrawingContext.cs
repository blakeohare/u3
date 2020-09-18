using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace U3
{
    public class DrawingContext
    {
        private StringBuilder buffer;

        internal DrawingContext(StringBuilder buffer)
        {
            this.buffer = buffer;
        }

        public void FillScreen(int red, int green, int blue)
        {
            red = Math.Max(0, Math.Min(255, red));
            green = Math.Max(0, Math.Min(255, green));
            blue = Math.Max(0, Math.Min(255, blue));
            this.buffer.Append(" F ");
            this.buffer.Append(red);
            this.buffer.Append(' ');
            this.buffer.Append(green);
            this.buffer.Append(' ');
            this.buffer.Append(blue);
        }

        public void DrawRectangle(int x, int y, int width, int height, int red, int green, int blue)
        {
            red = Math.Max(0, Math.Min(255, red));
            green = Math.Max(0, Math.Min(255, green));
            blue = Math.Max(0, Math.Min(255, blue));
            this.buffer.Append(" R ");
            this.buffer.Append(x);
            this.buffer.Append(' ');
            this.buffer.Append(y);
            this.buffer.Append(' ');
            this.buffer.Append(width);
            this.buffer.Append(' ');
            this.buffer.Append(height);
            this.buffer.Append(' ');
            this.buffer.Append(red);
            this.buffer.Append(' ');
            this.buffer.Append(green);
            this.buffer.Append(' ');
            this.buffer.Append(blue);
        }

    }
}
