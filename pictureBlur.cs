using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace pictureBlur
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bm1 = new Bitmap("T:\\BitmapsPNG\\nature.jpg");
            Bitmap bm2 = new Bitmap(bm1);
            Stopwatch sw = new Stopwatch();


            /*int r_Mwert = 0;
            int g_Mwert = 0;
            int b_Mwert = 0;*/
            int dx;
            int dy;
            Console.WriteLine("Mit welchem Namen soll die Datei gespeichert werden: ");
            Console.Write("Bitte geben sie den vertikalen Streckungsgrad an:");
            dx = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.Write("Bitte geben sie den horizontalen Streckungsgrad an:");
            dy = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            sw.Start();

            for (int x = 0; x < bm1.Width; x++)
                for (int y = 0; y < bm1.Height; y++)
                {

                    try
                    {
                        int xmin = Math.Max(0, x - dx);
                        int ymin = Math.Max(0, y - dy);
                        int xmax = Math.Min(bm1.Width, x + dx);
                        int ymax = Math.Min(bm1.Height, y + dy);

                        int r = 0;
                        int g = 0;
                        int b = 0;

                        for (int x2 = xmin; x2 < xmax; x2++)
                            for (int y2 = ymin; y2 < ymax; y2++)
                            {
                                Color col2 = bm1.GetPixel(x2, y2);
                                r += col2.R;
                                g += col2.G;
                                b += col2.B;
                            }
                        int anz = (xmax - xmin) * (ymax - ymin);
                        r = r / anz;
                        g = g / anz;
                        b = b / anz;
                        Color col3 = Color.FromArgb(255, r, g, b);
                        bm2.SetPixel(x, y, col3);



                        /*Color right = bm2.GetPixel(x + 1, y);
                                    Color left = bm2.GetPixel(x - 1, y);
                                    Color top = bm2.GetPixel(x, y + 1);
                                    Color bot = bm2.GetPixel(x, y - 1);

                                    r_Mwert = (right.R + left.R + top.R + bot.R) / 4;
                                    g_Mwert = (right.G + left.G + top.G + bot.G) / 4;
                                    b_Mwert = (right.B + left.B + top.B + bot.B) / 4;


                                    bm2.SetPixel(x, y, Color.FromArgb(255, r_Mwert, g_Mwert, b_Mwert));
                                    */
                        /*progress = pixel / 100;
                        Console.WriteLine(progress + "%");*/
                        if (x == 1 && y == 1)
                        {
                            Console.WriteLine("Bild wird verzerrt, Bitte schließen sie nicht das Programm!");
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            sw.Stop();
            Console.WriteLine(sw.Elapsed.Seconds + "s");
            bm2.Save("T:\\BitmapsPNG\\Bitmaps2\\naturepix");
            Console.WriteLine("Bild wurde erfolgreich verzerrt!");
            Console.ReadKey();

        }
    }
}
