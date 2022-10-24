using Moravia.Homework.Contracts.Abstracts;
using System.IO;
using System.Threading.Tasks;

namespace Moravia.Homework.Converter.StorageProviders
{
    /// <summary>
    /// File storage provider
    /// </summary>
    public class FileStorageProvider : IFileReader, IFileWriter
    {
        /// <inheritdoc />
        public Task<Stream> ReadAsync(string path) =>
            Task.FromResult<Stream>(File.OpenRead(path));

        /// <inheritdoc />
        public async Task WriteAsync(string targetPath, Stream outputStream)
        {
            using (var fileStream = File.Create(targetPath))
            {
                outputStream.Seek(0, SeekOrigin.Begin);
                await outputStream.CopyToAsync(fileStream);
            }
        }
    }
}
