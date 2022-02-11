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
                Key = "s3://adventures-of-wilbur-images/Wilbur_2020_8_15_16_37_23_29.jpg",
                BucketName = "adventures-of-wilbur-images"
            }).Result;

            Console.WriteLine($"Status: {myObject.HttpStatusCode}");
        }
    }
}
