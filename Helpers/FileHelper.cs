using Azure.Storage.Blobs;

namespace MusicApi.Helpers
{
    public  static class FileHelper
    {
        public  static async Task<string> UploadImage(IFormFile file)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=mitshreysg;AccountKey=U1NhvJU2Q9zD6QZbu23XAZQ0KRf/69lM0ug4USCM9xMuEw5v13Vf1+1AKg0NzXqTSApSg2X0aNFX4P2pfqm6ww==;EndpointSuffix=core.windows.net";
            string containerName = "songcover";


            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            return blobClient.Uri.AbsoluteUri;
        }
        public static async Task<string> UploadFile(IFormFile file)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=mitshreysg;AccountKey=U1NhvJU2Q9zD6QZbu23XAZQ0KRf/69lM0ug4USCM9xMuEw5v13Vf1+1AKg0NzXqTSApSg2X0aNFX4P2pfqm6ww==;EndpointSuffix=core.windows.net";
            string containerName = "audiofile";


            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
