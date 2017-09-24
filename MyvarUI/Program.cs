using System;
using System.Diagnostics;
using System.IO;
using MyvarUI.CairoLib;
using MyvarUI.Mudle;

namespace MyvarUI
{
    unsafe class Program
    {
        static void Main(string[] args)
        {
            var root = MudleParser.Parse(File.ReadAllText("test.mudle"));

            var re = new RenderEngine();
            re.Render(root);

            re.SaveToPng("image.png");
            
            //Test_Cairo();
        }

        static void Test_Cairo()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var surface = Cairo.cairo_image_surface_create(CairoFormat.CairoFormatArgb32, 800, 600);
            var cr = Cairo.cairo_create(surface);

            Cairo.cairo_set_source_rgb(cr, 0, 0, 0);
            Cairo.cairo_select_font_face(cr, "Sans", CairoFontSlant.CairoFontSlantNormal,
                CairoFontWeight.CairoFontWeightNormal);
            Cairo.cairo_set_font_size(cr, 40.0);

            Cairo.cairo_move_to(cr, 10.0, 50.0);
            Cairo.cairo_show_text(cr, "Myvar");

            //we will use thos for now later we can implment the opengl stuff
            Cairo.cairo_surface_write_to_png(surface, "image.png");

            //Cairo.cairo_surface_flush(cr);
            //var data = Cairo.cairo_image_surface_get_data(surface);
            //load into texture using
            //glTexImage2D(GL_TEXTURE_2D, 0, 4, tex_w,tex_h, 0,GL_BGRA, GL_UNSIGNED_BYTE, data);
            //when you create the texture. Use glTexSubImage2D(...) to update th texture when the image content changes
            //. For speed set the filters for the texture to GL_NEAREST

            Cairo.cairo_destroy(cr);
            Cairo.cairo_surface_destroy(surface);

            sw.Stop();
            Console.WriteLine($"Time: {sw.Elapsed}");
        }
    }
}