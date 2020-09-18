using U3;

namespace U3CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 1024;
            int height = width * 9 / 16;
            int fps = 60;

            GameWindow window = new GameWindow("Test Game", width, height, fps);
            DrawingContext draw = window.GetDrawingContext();

            window.Show();

            int animX = 0;
            int animY = 0;

            while (true)
            {
                animX += 2;
                animY += 1;

                if (animX > width) animX = -50;
                if (animY > height) animY = -50;

                draw.FillScreen(0, 128, 255);
                draw.DrawRectangle(animX, animY, 50, 50, 255, 0, 0);

                window.FlushFrame();
            }
        }
    }
}
