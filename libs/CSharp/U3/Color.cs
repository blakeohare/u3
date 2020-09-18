using System;
using System.Collections.Generic;
using System.Text;

namespace U3
{
    public class Color
    {
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public Color(int red, int green, int blue)
        {
            this.Red = Math.Max(0, Math.Min(255, red));
            this.Green = Math.Max(0, Math.Min(255, green));
            this.Blue = Math.Max(0, Math.Min(255, blue));
        }

        public static readonly Color BLACK = new Color(0, 0, 0);
        public static readonly Color WHITE = new Color(255, 255, 255);
        public static readonly Color GRAY = new Color(128, 128, 128);
        public static readonly Color LIGHT_GRAY = new Color(192, 192, 192);
        public static readonly Color DARK_GRAY = new Color(64, 64, 64);
        public static readonly Color RED = new Color(255, 0, 0);
        public static readonly Color GREEN = new Color(0, 128, 0);
        public static readonly Color BLUE = new Color(0, 0, 255);
        public static readonly Color YELLOW = new Color(255, 255, 0);
        public static readonly Color PURPLE = new Color(128, 0, 128);
        public static readonly Color ORANGE = new Color(255, 128, 0);
        public static readonly Color BROWN = new Color(128, 64, 0);
        public static readonly Color SKY_BLUE = new Color(100, 200, 255);
    }
}
