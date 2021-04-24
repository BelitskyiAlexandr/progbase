using System;
using System.Drawing;

namespace ProgbaseLab.ImageEditor.Pixel
{
    public class Class1 : ProgbaseLab.ImageEditor.Common.IRedatctingImage
    {
        public Bitmap Crop(Bitmap bmp, Rectangle rec)
        {
            if (rec.Left < 0 || rec.Left >= bmp.Width)
            {
                throw new Exception("Invalid left");
            }
            if (rec.Right >= bmp.Width)
            {
                throw new Exception("Invalid right");
            }
            if (rec.Top < 0 || rec.Top >= bmp.Height)
            {
                throw new Exception("Invalid right");
            }
            if (rec.Bottom >= bmp.Height)
            {
                throw new Exception("Invalid right");
            }
            Bitmap cropImage = new Bitmap(rec.Width, rec.Height);
            for (int y = 0; y < cropImage.Height; y++)
            {
                for (int x = 0; x < cropImage.Width; x++)
                {
                    Color color = bmp.GetPixel(x + rec.Left, y + rec.Top);
                    cropImage.SetPixel(x, y, color);
                }
            }
            return cropImage;
        }

        public Bitmap Blur(Bitmap bmp) // operation factor
        {
            double[,] filter = new double[,] {
                {1/16.0, 2/16.0, 1/16.0},
                {2/16.0, 4/16.0, 2/16.0},
                {1/16.0, 2/16.0, 1/16.0}
                };

            Bitmap result = new Bitmap(bmp.Width, bmp.Height);

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color originalColor = bmp.GetPixel(x, y);
                    Color newColor = ApplyFilter(bmp, x, y, filter);
                    result.SetPixel(x, y, newColor);
                }
            }
            return result;

        }

        private static Color ApplyFilter(
            Bitmap image,
            int x,
            int y,
            double[,] filter)
        {
            double red = 0.0;
            double green = 0.0;
            double blue = 0.0;

            int filterSize = filter.GetLength(0);
            int radius = filterSize / 2;

            int w = image.Width;
            int h = image.Height;

            for (int filterX = -radius; filterX <= radius; filterX++)
            {
                for (int filterY = -radius; filterY <= radius; filterY++)
                {
                    double filterValue = filter[filterX + radius, filterY + radius];

                    int imageX = (x + filterX + w) % w;
                    int imageY = (y + filterY + h) % h;

                    Color imageColor = image.GetPixel(imageX, imageY);

                    red += imageColor.R * filterValue;
                    green += imageColor.G * filterValue;
                    blue += imageColor.B * filterValue;
                }
            }

            int r = Math.Min(Math.Max((int)(red), 0), 255);
            int g = Math.Min(Math.Max((int)(green), 0), 255);
            int b = Math.Min(Math.Max((int)(blue), 0), 255);

            return Color.FromArgb(r, g, b);
        }


        public Bitmap FlipVertical(Bitmap bitmap)
        {
            Bitmap flippedBMP = new Bitmap(bitmap.Width, bitmap.Height);
            for (int x = bitmap.Width; x > 0; x--)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x - 1, y);
                    flippedBMP.SetPixel(bitmap.Width - x, y, color);
                }
            }
            return flippedBMP;
        }

        public Bitmap GrayScale(Bitmap bitmap)
        {
            Bitmap grayBMP = new Bitmap(bitmap.Width, bitmap.Height);
            for (int x = bitmap.Width; x > 0; x--)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x - 1, y);
                    int linear = (int)(0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B);
                    Color newColor = Color.FromArgb(255, linear, linear, linear);
                    grayBMP.SetPixel(x - 1, y, newColor);
                }
            }
            return grayBMP;
        }

        public Bitmap RemoveRed(Bitmap bitmap)
        {
            Bitmap noRedBMP = new Bitmap(bitmap.Width, bitmap.Height);
            for (int x = bitmap.Width; x > 0; x--)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x - 1, y);
                    Color newColor = Color.FromArgb(255, 0, color.G, color.B);
                    noRedBMP.SetPixel(x - 1, y, newColor);
                }
            }
            return noRedBMP;
        }
    }
}
