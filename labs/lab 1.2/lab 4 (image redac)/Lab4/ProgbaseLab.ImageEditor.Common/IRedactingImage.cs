using System.Drawing;

namespace ProgbaseLab.ImageEditor.Common
{
    public interface IRedatctingImage
    {
        Bitmap Crop(Bitmap bmp, Rectangle rec);
        Bitmap FlipVertical(Bitmap bitmap);
        Bitmap RemoveRed(Bitmap bitmap);
        Bitmap GrayScale(Bitmap bitmap);
        Bitmap Blur (Bitmap bitmap);
    }
    
    
}
