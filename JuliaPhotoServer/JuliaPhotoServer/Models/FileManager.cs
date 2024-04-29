using System.Drawing;
using System.IO;
using System;

namespace JuliaPhotoServer.Models
{
    public static class FileManager
    {
        public static void UploadPhoto(IFormFile file, string path, double? ResizeRatio = null) {
            Bitmap b;
            byte[] orientation = { 0, 0 };
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
                using (Image image = Image.FromStream(fs))
                {
                    if (ResizeRatio == null)
                    {
                        int max = Math.Max(image.Width, image.Height);
                        ResizeRatio = (max / 2000.0);
                    }
                    if (image.PropertyItems != null)
                    {
                        if (image.PropertyItems.FirstOrDefault(metadata => metadata.Id == 274) != null)
                        {
                            orientation = image.PropertyItems.FirstOrDefault(metadata => metadata.Id == 274).Value;
                        }
                    }
                    PhotoFormater photoFormater = new PhotoFormater();
                    Console.WriteLine(ResizeRatio);
                    b = photoFormater.ResizeImage(image, (int)(image.Width / ResizeRatio), (int)(image.Height / ResizeRatio));
                }
            }

            // Metadata has "orientation" key. It may has value something like "rotate 270deg" (in byte it is "60")
            // When I create new Bitmap "b = photoFormater.ResizeImage()" this metadata don`t save in new Bitmap 
            // so we need to rotate this image
            // orientation[0] == 6 means that image must be rotated 90deg. (orientation = "60")
            if (orientation[0] == 6)
            {
                b.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            if (orientation[0] == 8)
            {
                b.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            System.IO.File.Delete(path);
            b.Save(path, System.Drawing.Imaging.ImageFormat.Png);
        }

        public static void DeletePhoto(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The deletion failed: {0}", e.Message);
                }
            };
        }
    }
}
