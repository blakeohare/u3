using U3;

namespace U3CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(
                title: "Test Game",
                width: 640,
                height: 480,
                fps: 60);

            int animX = 0;
            int animY = 0;

            window.Show();

            while (true)
            {
                animX += 2;
                animY += 1;

                window.FillScreen(0, 128, 255);
                window.DrawRectangle(animX, animY, 50, 50, 255, 0, 0);

                window.FlushFrame();
            }
        }
    }
}
