using System.Collections.Generic;
using System.Diagnostics;

namespace MyvarUI.Mudle
{
    public class MudleObject
    {
        public string Name { get; set; }
        public string Implments { get; set; }

        public Dictionary<string, MudlePropertie> Properties { get; set; } = new Dictionary<string, MudlePropertie>();

        public Dictionary<string, MudleObject> Children { get; set; } = new Dictionary<string, MudleObject>();

        public (int width, int height) CalualteBounds()
        {
            var width = 800;
            var height = 600;

            if (Properties.ContainsKey("width"))
            {
                width = int.Parse(Properties["width"].Value.Replace("px", ""));
            }

            if (Properties.ContainsKey("height"))
            {
                height = int.Parse(Properties["height"].Value.Replace("px", ""));
            }

            return (width, height);
        }

        public Color GetBackgroundColor()
        {
            var clr = "black";

            if (Properties.ContainsKey("background-color"))
            {
                clr = Properties["background-color"].Value;
            }

            return Color.Parse(clr);
        }
        
        public Color GetColor(string color)
        {
            var clr = "black";

            if (Properties.ContainsKey(color))
            {
                clr = Properties[color].Value;
            }

            return Color.Parse(clr);
        }

        public (int x, int y) CalualteLocation()
        {
            var x = 0;
            var y = 0;

            if (Properties.ContainsKey("x"))
            {
                x = int.Parse(Properties["x"].Value.Replace("px", ""));
            }

            if (Properties.ContainsKey("y"))
            {
                y = int.Parse(Properties["y"].Value.Replace("px", ""));
            }

            return (x, y);
        }
    }
}