using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using ImageManagement.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ImageManagement.Service
{
    public class Connection : IDisposable
    {
        private AmazonS3Client client;

        public Connection(string accessKeyId, string secretAccessKey, string url)
        {
            AmazonS3Config config = new AmazonS3Config()
            {
                ServiceURL = url,
                RegionEndpoint = RegionEndpoint.APSoutheast2
            };
            client = new AmazonS3Client(accessKeyId, secretAccessKey, config);
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public List<ImageFile> GetItems(string bucket)
        {
            List<ImageFile> imageFiles = new List<ImageFile>();
            ListObjectsRequest request = new ListObjectsRequest();
            request.BucketName = bucket;
            ListObjectsResponse response = client.ListObjects(request);
            foreach (S3Object o in response.S3Objects.Where(m => m.Key.EndsWith(".jpg")))
            {
                ImageFile imageFile = new ImageFile();
                imageFile.Pixels = new Collection<Pixel>();
                imageFile.FileName = o.Key;
                imageFile.FileSize = o.Size;
                imageFiles.Add(imageFile);
            }
            return imageFiles;
        }

        public void DownloadImage(string bucket, string key, string filePath)
        {
            var objResponse = client.GetObject(bucket, key);
            FileStream fs = File.Create(filePath);
            byte[] buffer = new byte[objResponse.ResponseStream.Length];
            objResponse.ResponseStream.Read(buffer, 0, buffer.Length);
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();
            objResponse.Dispose();
        }
    }
}
