using System;
using Amazon.S3;
using Amazon.S3.Model;

namespace lesson_05
{
    class Program
    {
        static void Main(string[] args)
        {
            var s3 = new AmazonS3Client();
            var myObject = s3.GetObjectAsync(new GetObjectRequest
            {
                Key = "darkflame-universe-backup/data/backup.sql",
                BucketName = "joshua-game-backup"
            }).Result;

            Console.WriteLine($"Status: {myObject.HttpStatusCode}");
        }
    }
}
