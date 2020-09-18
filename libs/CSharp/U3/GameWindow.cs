using System;
using System.IO;
using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace U3
{
    public class GameWindow
    {
        private string title;
        private int width;
        private int height;
        private int fps;
        private double lastFrameTime;

        private bool isShown = false;

        private StreamReader reader;
        private StreamWriter writer;
        private NamedPipeClientStream client;
        private StringBuilder renderBuffer = new StringBuilder();

        public GameWindow(string title, int width, int height, int fps)
        {
            this.title = title;
            this.width = width;
            this.height = height;
        }

        private static double GetCurrentTime()
        {
            long now = DateTime.Now.Ticks;
            return now / 10000000.0;
        }

        public void Show()
        {
            if (this.isShown) return;

            this.client = new NamedPipeClientStream("u3pipe");
            this.client.Connect();
            this.reader = new StreamReader(client);
            this.writer = new StreamWriter(client);
            this.renderBuffer.Append("GAME_RENDER");
            this.lastFrameTime = GetCurrentTime();

            this.isShown = true;
        }

        public void FillScreen(int red, int green, int blue)
        {
            red = Math.Max(0, Math.Min(255, red));
            green = Math.Max(0, Math.Min(255, green));
            blue = Math.Max(0, Math.Min(255, blue));
            this.renderBuffer.Append(" F ");
            this.renderBuffer.Append(red);
            this.renderBuffer.Append(' ');
            this.renderBuffer.Append(green);
            this.renderBuffer.Append(' ');
            this.renderBuffer.Append(blue);
        }

        public void DrawRectangle(int x, int y, int width, int height, int red, int green, int blue)
        {
            red = Math.Max(0, Math.Min(255, red));
            green = Math.Max(0, Math.Min(255, green));
            blue = Math.Max(0, Math.Min(255, blue));
            this.renderBuffer.Append(" R ");
            this.renderBuffer.Append(x);
            this.renderBuffer.Append(' ');
            this.renderBuffer.Append(y);
            this.renderBuffer.Append(' ');
            this.renderBuffer.Append(width);
            this.renderBuffer.Append(' ');
            this.renderBuffer.Append(height);
            this.renderBuffer.Append(' ');
            this.renderBuffer.Append(red);
            this.renderBuffer.Append(' ');
            this.renderBuffer.Append(green);
            this.renderBuffer.Append(' ');
            this.renderBuffer.Append(blue);
        }

        public void FlushFrame()
        {
            this.writer.WriteLine(this.renderBuffer.ToString());
            this.writer.Flush();
            this.renderBuffer.Clear();
            this.renderBuffer.Append("GAME_RENDER");

            double timeNow = GetCurrentTime();
            double diff = timeNow - this.lastFrameTime;
            double frameDuration = 1 / 60.0;
            double delay = frameDuration - diff;
            this.lastFrameTime = timeNow;
            int delayMillis = Math.Max(1, (int)(delay * 1000 + .5));

            System.Threading.Thread.Sleep(delayMillis);
        }
    }
}
