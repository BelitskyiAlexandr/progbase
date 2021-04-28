using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ProgbaseLab.ImageEditor.Fast
{
    public class Class1 : ProgbaseLab.ImageEditor.Common.IRedatctingImage
    {
        public Bitmap Blur(Bitmap image, Int32 blurSize)  // код взятий із відкритих джерел, бо не знайшов способу через System.Drawing
        {
            return Blur(image, new Rectangle(0, 0, image.Width, image.Height), blurSize);
        }

        private unsafe static Bitmap Blur(Bitmap image, Rectangle rectangle, Int32 blurSize)
        {
            Bitmap blurred = new Bitmap(image.Width, image.Height);

            // make an exact copy of the bitmap provided
            using (Graphics graphics = Graphics.FromImage(blurred))
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);

            // Lock the bitmap's bits
            BitmapData blurredData = blurred.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, blurred.PixelFormat);

            // Get bits per pixel for current PixelFormat
            int bitsPerPixel = Image.GetPixelFormatSize(blurred.PixelFormat);

            // Get pointer to first line
            byte* scan0 = (byte*)blurredData.Scan0.ToPointer();

            // look at every pixel in the blur rectangle
            for (int xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
            {
                for (int yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;

                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (int x = xx; (x < xx + blurSize && x < image.Width); x++)
                    {
                        for (int y = yy; (y < yy + blurSize && y < image.Height); y++)
                        {
                            // Get pointer to RGB
                            byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;

                            avgB += data[0]; // Blue
                            avgG += data[1]; // Green
                            avgR += data[2]; // Red

                            blurPixelCount++;
                        }
                    }

                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;

                    // now that we know the average for the blur size, set each pixel to that color
                    for (int x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++)
                    {
                        for (int y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++)
                        {
                            // Get pointer to RGB
                            byte* data = scan0 + y * blurredData.Stride + x * bitsPerPixel / 8;

                            // Change values
                            data[0] = (byte)avgB;
                            data[1] = (byte)avgG;
                            data[2] = (byte)avgR;
                        }
                    }
                }
            }

            // Unlock the bits
            blurred.UnlockBits(blurredData);

            return blurred;
        }

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
            bmp = bmp.Clone(rec, System.Drawing.Imaging.PixelFormat.DontCare);
            return bmp;
        }

        public Bitmap FlipVertical(Bitmap bitmap)
        {
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
            return bitmap;
        }

        public Bitmap GrayScale(Bitmap bitmap)
        {
            Bitmap newBMP = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics g = Graphics.FromImage(newBMP);
            ColorMatrix TempMatrix = new ColorMatrix(
            new float[][]
            {
                new float[] {.3f, .3f, .3f,0,0},
                new float[] {.59f, .59f, .59f,0,0},
                new float[] {.11f, .11f, .11f,0,0},
                new float[] {0, 0, 0,1,0},
                new float[] {0, 0, 0,0,1}
            });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(TempMatrix);
            g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, attributes);
            g.Dispose();
            return newBMP;
        }

        public Bitmap RemoveRed(Bitmap bitmap)      //OpenCvSharp не працює, а інших способів я не знайшов, тому аналогічна реалізація, як у Pixel 
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
