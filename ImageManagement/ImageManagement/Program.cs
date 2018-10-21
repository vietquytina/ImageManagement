using ImageManagement.Database;
using ImageManagement.Repository;
using ImageManagement.Service;
using System;
using System.IO;

namespace ImageManagement
{
    class Program
    {
        private const string URL = "";

        private const string ACCESS_KEY_ID = "";

        private const string SECRET_ACCESS_KEY = "";

        private const string BUCKET = "";

        private static string GetImageFolderPath()
        {
            string imgFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            if (!Directory.Exists(imgFolderPath))
            {
                Directory.CreateDirectory(imgFolderPath);
            }
            return imgFolderPath;
        }

        static void Main(string[] args)
        {
            string imgFolderPath = GetImageFolderPath();
            IImageFileRepository repository = new ImageFileRepository(new ImageContext());
            Connection connection = new Connection(ACCESS_KEY_ID, SECRET_ACCESS_KEY, URL);
            var imageFiles = connection.GetItems(BUCKET);
            repository.Clear();
            repository.SaveChanges();
            foreach (var image in imageFiles)
            {
                string imgFilePath = Path.Combine(imgFolderPath, image.FileName);
                connection.DownloadImage(BUCKET, image.FileName, imgFilePath);
                var pixels = Image.GetImagePixels(imgFilePath);
                repository.Add(image);
                for (int i = 0; i < pixels.Count; i++)
                {
                    image.Pixels.Add(pixels[i]);
                    if (i != 0 && i % 100 == 0)
                    {
                        repository.SaveChanges();
                    }
                }
                Console.WriteLine(string.Format("Finish processing {0} file", image.FileName));
            }
            Console.WriteLine(string.Format("There are {0} file(s) have been processed.", imageFiles.Count));
            Console.ReadLine();
        }
    }
}