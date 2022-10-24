using Moravia.Homework.Contracts.Abstracts;
using System.Text;

namespace Moravia.Homework.UnitTests
{
    /// <summary>
    /// InMemory storage provider for unit testing
    /// </summary>
    internal class InMemoryStorageProvider : IFileReader, IFileWriter
    {
        /// <summary>
        /// Dictionary of files
        /// </summary>
        public Dictionary<string, string> Files { get; set; }
            = new Dictionary<string, string>();

        /// <inheritdoc />
        public Task<Stream> ReadAsync(string path)
        {
            if (Files.TryGetValue(path, out var value))
            {
                var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(value));
                return Task.FromResult((Stream)memoryStream);
            }

            throw new FileNotFoundException();
        }

        /// <inheritdoc />
        public Task WriteAsync(string path, Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            using (var streamReader = new StreamReader(stream))
            {
                Files.Add(path, streamReader.ReadToEnd());
            }

            return Task.CompletedTask;
        }
    }
}
