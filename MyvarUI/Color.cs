namespace MyvarUI
{
    public class Color
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static Color Parse(string s)
        {
            switch (s)
            {
                case "red":
                    return new Color(255, 0, 0);
                case "green":
                    return new Color(0, 255, 0);
                case "blue":
                    return new Color(0, 0, 255);

                default:
                    return new Color(0, 0, 0);
            }
        }
    }
}