using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Azure.Storage.Blobs;
using Ruralreformers.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ruralreformers.Helper
{
    public class CloudIntegrationHelper
    {
        private const string ConnectionString = "";

        public CloudIntegrationHelper()
        {

        }

        public async Task<bool> SaveUserInformation(Registeration registeration)
        {
            try
            {
                // Create a BlobServiceClient object which will be used to create a container client
                BlobServiceClient blobServiceClient = new BlobServiceClient(ConnectionString);

                //Create a unique name for the container
                string containerName = registeration.Name + Guid.NewGuid().ToString();

                // Create the container and return a container client object
                BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

                // Create a local file in the ./data/ directory for uploading and downloading
                string localPath = "./data/";
                string fileName = registeration.Name + Guid.NewGuid().ToString() + ".txt";
                string localFilePath = Path.Combine(localPath, fileName);

                // Write text to the file
                await File.WriteAllTextAsync(localFilePath, Newtonsoft.Json.JsonConvert.SerializeObject(registeration));

                // Get a reference to a blob
                BlobClient blobClient = containerClient.GetBlobClient(fileName);

                // Upload data from the local file
                 await blobClient.UploadAsync(localFilePath, true);
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }     

        public async Task<bool> SaveUserInformationToS3(Registeration registeration)
        {
            string _bucketName = "";
            string _awsAccessKey = "";
            string _awsSecretKey = "";
            try
            {

                IAmazonS3 client = new AmazonS3Client(_awsAccessKey, _awsSecretKey, RegionEndpoint.APSouth1);

                // Create a local file in the ./data/ directory for uploading and downloading
                string localPath = "data/";
                string fileName = registeration.Name + Guid.NewGuid().ToString() + ".txt";
                string localFilePath = Path.Combine(localPath, fileName);

                // Write text to the file
                await File.WriteAllTextAsync(localFilePath, Newtonsoft.Json.JsonConvert.SerializeObject(registeration));
                FileInfo file = new FileInfo(localFilePath);
                PutObjectRequest request = new PutObjectRequest()
                {
                    InputStream = file.OpenRead(),
                    BucketName = _bucketName,
                    Key = localPath // <-- in S3 key represents a path  
                };

                PutObjectResponse response = client.PutObjectAsync(request).Result;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
