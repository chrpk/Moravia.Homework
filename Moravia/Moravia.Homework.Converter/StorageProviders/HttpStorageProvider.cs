using Moravia.Homework.Contracts.Abstracts;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Moravia.Homework.Converter.StorageProviders
{
    /// <summary>
    /// Simple HTTP storage provider
    /// </summary>
    public class HttpStorageProvider : IFileReader
    {
        /// <summary>
        /// HttpClient
        /// </summary>
        private static HttpClient _httpClient = new HttpClient();

        /// <inheritdoc />
        public async Task<Stream> ReadAsync(string path)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, path);
            var response = await _httpClient.SendAsync(request);

            return await response.Content.ReadAsStreamAsync();
        }
    }
}
