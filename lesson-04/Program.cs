using System;
using System.Linq;
using Amazon;
using Amazon.EC2;
using Amazon.Runtime.CredentialManagement;

namespace lesson_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var chain = new CredentialProfileStoreChain("C:\\Users\\joshua.richardson\\.aws\\credentials");
            chain.TryGetAWSCredentials("associate-developer", out var credentials);

            var ec2 = new AmazonEC2Client(credentials, RegionEndpoint.EUWest2);

            var instanceDescription = ec2.DescribeInstancesAsync().Result;

            if (!instanceDescription.Reservations.Any())
            {
                Console.WriteLine("No reservations");
                return;
            }

            foreach (var reservation in instanceDescription.Reservations)
            {
                var instances = reservation.Instances;

                if (!instances.Any())
                    continue;

                foreach (var instance in instances)
                {
                    var name = instance.Tags.FirstOrDefault(x => x.Key == "Name")?.Value;
                    Console.WriteLine($"Name: {name}, AZ: {instance.Placement.AvailabilityZone}, State: {instance.State}");
                }
            }
        }
    }
}
