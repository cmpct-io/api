using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace Compact.Infrastructure
{
    public interface IAzureStorageManager
    {
        Task<string> StoreObject(string containerName, string fileName, object obj);

        Task<T> ReadObject<T>(string containerName, string fileName);
    }

    public class AzureStorageManager : IAzureStorageManager
    {
        private readonly IConfigurationValueProvider _configurationValueProvider;

        public AzureStorageManager(IConfigurationValueProvider configurationValueProvider)
        {
            _configurationValueProvider = configurationValueProvider;
        }

        public async Task<string> StoreObject(string containerName, string fileName, object obj)
        {
            var storageAccount = ConnectStorageAccount();
            var cloudBlobContainer = FetchBlobContainer(storageAccount, containerName);
            await cloudBlobContainer.CreateIfNotExistsAsync();

            BlobContainerPermissions permissions = new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob,
            };

            await cloudBlobContainer.SetPermissionsAsync(permissions);

            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);

            var jsonFileContent = JsonConvert.SerializeObject(obj);

            await cloudBlockBlob.UploadTextAsync(jsonFileContent);

            return cloudBlobContainer.Uri.AbsoluteUri + "/" + fileName;
        }

        public async Task<T> ReadObject<T>(string containerName, string fileName)
        {
            var storageAccount = ConnectStorageAccount();
            var cloudBlobContainer = FetchBlobContainer(storageAccount, containerName);
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);

            var content = await cloudBlockBlob.ExistsAsync()
                ? await cloudBlockBlob.DownloadTextAsync()
                : string.Empty;

            var result = JsonConvert.DeserializeObject<T>(content);

            return result;
        }

        private CloudStorageAccount ConnectStorageAccount()
        {
            string storageConnectionString = _configurationValueProvider.GetValue("StorageConnectionString");

            if (CloudStorageAccount.TryParse(storageConnectionString, out CloudStorageAccount storageAccount))
            {
                return storageAccount;
            }
            else
            {
                throw new WebException("Unable to connect to storage account");
            }
        }

        private static CloudBlobContainer FetchBlobContainer(CloudStorageAccount storageAccount, string containerName)
        {
            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
            return cloudBlobClient.GetContainerReference(containerName);
        }
    }
}