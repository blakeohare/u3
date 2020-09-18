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

        public void FillScreen(Color color)
        {
            this.buffer.Append(" F ");
            this.buffer.Append(color.Red);
            this.buffer.Append(' ');
            this.buffer.Append(color.Green);
            this.buffer.Append(' ');
            this.buffer.Append(color.Blue);
        }

        public void DrawRectangle(int x, int y, int width, int height, Color color)
        {
            this.buffer.Append(" R ");
            this.buffer.Append(x);
            this.buffer.Append(' ');
            this.buffer.Append(y);
            this.buffer.Append(' ');
            this.buffer.Append(width);
            this.buffer.Append(' ');
            this.buffer.Append(height);
            this.buffer.Append(' ');
            this.buffer.Append(color.Red);
            this.buffer.Append(' ');
            this.buffer.Append(color.Green);
            this.buffer.Append(' ');
            this.buffer.Append(color.Blue);
        }
    }
}
