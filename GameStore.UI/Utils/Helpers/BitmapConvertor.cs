using System.Drawing;
using System.IO;

namespace GameStore.UI.Utils.Helpers
{
    public static class BitmapConvertor
    {
        public static Image Convert(Stream stream, int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(Image.FromStream(stream), 0, 0, width, height);
            }

            return bitmap;
        }
    }
}