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
        private readonly int fps;
        private double lastFrameTime;

        private bool isShown = false;

        private StreamReader reader;
        private StreamWriter writer;
        private NamedPipeClientStream client;
        private StringBuilder renderBuffer = new StringBuilder();

        private readonly DrawingContext drawingContext;

        public GameWindow(string title, int width, int height, int fps)
        {
            this.title = title;
            this.width = width;
            this.height = height;
            this.fps = fps;

            this.renderBuffer.Append("GAME_RENDER");
            this.drawingContext = new DrawingContext(this.renderBuffer);
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
            this.lastFrameTime = GetCurrentTime();

            this.isShown = true;
        }

        public DrawingContext GetDrawingContext()
        {
            return this.drawingContext;
        }

        public void FlushFrame()
        {
            this.writer.WriteLine(this.renderBuffer.ToString());
            this.writer.Flush();
            this.renderBuffer.Clear();
            this.renderBuffer.Append("GAME_RENDER");

            double timeNow = GetCurrentTime();
            double diff = timeNow - this.lastFrameTime;
            double frameDuration = 1.0 / this.fps;
            double delay = frameDuration - diff;
            this.lastFrameTime = timeNow;
            int delayMillis = Math.Max(1, (int)(delay * 1000 + .5));

            System.Threading.Thread.Sleep(delayMillis);
        }
    }
}
