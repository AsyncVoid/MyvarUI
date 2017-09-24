using System;
using System.Runtime.InteropServices;

namespace MyvarUI.CairoLib
{
    public unsafe class Cairo
    {
        public const string Cairo_DLL = "cairo.so"; //use parsual class to make this cross platform

        [DllImport(Cairo_DLL)]
        public static extern IntPtr cairo_image_surface_create(CairoFormat format, int width, int height);

        [DllImport(Cairo_DLL)]
        public static extern IntPtr cairo_create(IntPtr surface);

        [DllImport(Cairo_DLL)]
        public static extern void cairo_set_source_rgb(IntPtr cr, double red, double green, double blue);

        [DllImport(Cairo_DLL)]
        public static extern void cairo_select_font_face(IntPtr cr, string family, CairoFontSlant slant,
            CairoFontWeight weight);

        [DllImport(Cairo_DLL)]
        public static extern void cairo_set_font_size(IntPtr cr, double size);

        [DllImport(Cairo_DLL)]
        public static extern void cairo_move_to(IntPtr cr, double x, double y);

        [DllImport(Cairo_DLL)]
        public static extern void cairo_show_text(IntPtr cr, string utf8);

        [DllImport(Cairo_DLL)]
        public static extern IntPtr cairo_surface_write_to_png(IntPtr surface, string filename);

        [DllImport(Cairo_DLL)]
        public static extern IntPtr cairo_destroy(IntPtr cr);

        [DllImport(Cairo_DLL)]
        public static extern IntPtr cairo_surface_destroy(IntPtr surface);

        [DllImport(Cairo_DLL)]
        public static extern IntPtr cairo_surface_flush(IntPtr surface);

        [DllImport(Cairo_DLL)]
        public static extern IntPtr cairo_image_surface_get_data(IntPtr surface);

        [DllImport(Cairo_DLL)]
        public static extern void cairo_rectangle(IntPtr cr, double x, double y, double width, double height);

        [DllImport(Cairo_DLL)]
        public static extern IntPtr cairo_fill(IntPtr surface);

        [DllImport(Cairo_DLL)]
        public static extern IntPtr cairo_stroke(IntPtr surface);

        [DllImport(Cairo_DLL)]
        public static extern void cairo_text_path(IntPtr cr, string utf8);

        [DllImport(Cairo_DLL)]
        public static extern IntPtr cairo_paint(IntPtr surface);
    }
}