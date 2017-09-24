using System;
using MyvarUI.CairoLib;

namespace MyvarUI.Mudle
{
    public class RenderEngine
    {
        public IntPtr Surface { get; set; }
        public IntPtr Cr { get; set; }

        public void Render(MudleObject root)
        {
            var (width, height) = root.CalualteBounds();
            Surface = Cairo.cairo_image_surface_create(CairoFormat.CairoFormatArgb32, width, height);
            Cr = Cairo.cairo_create(Surface);


            Internalrender(root, Cr, 0, 0);
        }

        private void Internalrender(MudleObject root, IntPtr cr, int x, int y)
        {
            var (width, height) = root.CalualteBounds();

            Cairo.cairo_move_to(cr, x, y);

            //apply bg color
            var color = root.GetBackgroundColor();
            Cairo.cairo_set_source_rgb(Cr, color.R, color.G, color.B);

            //drawbg
            switch (root.Implments)
            {
                case "rectangle":
                    Cairo.cairo_rectangle(cr, x, y, width, height);
                    Cairo.cairo_fill(cr);

                    break;
                case "text":
                    var fgcolor = root.GetColor("foreground-color");
                    Cairo.cairo_set_source_rgb(Cr, fgcolor.R, fgcolor.G, fgcolor.B);
                    Cairo.cairo_select_font_face(cr, "Sans", CairoFontSlant.CairoFontSlantNormal,
                        CairoFontWeight.CairoFontWeightNormal);
                    Cairo.cairo_set_font_size(cr, 10.0);
                    Cairo.cairo_show_text(cr, root.Properties["value"].Value.Trim('"').Trim('"'));


                    break;
            }


            foreach (var mudleObject in root.Children)
            {
                var (x1, y1) = mudleObject.Value.CalualteLocation();
                Internalrender(mudleObject.Value, cr, x1, y1);
            }
        }

        public void SaveToPng(string png)
        {
            Cairo.cairo_surface_write_to_png(Surface, png);
            Cairo.cairo_destroy(Cr);
            Cairo.cairo_surface_destroy(Surface);
        }
    }
}