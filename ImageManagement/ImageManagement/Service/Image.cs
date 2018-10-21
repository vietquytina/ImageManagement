using ImageManagement.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManagement.Service
{
    public class Image
    {
        public static List<Pixel> GetImagePixels(string filePath)
        {
            List<Pixel> pixels = new List<Pixel>();
            Bitmap bitmap = new Bitmap(filePath);
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    pixels.Add(new Pixel()
                    {
                        PixelX = x,
                        PixelY = y,
                        PixelR = color.R,
                        PixelG = color.G,
                        PixelB = color.B
                    });
                }
            }
            bitmap.Dispose();
            return pixels;
        }
    }
}
