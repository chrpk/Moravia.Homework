using Moravia.Homework.Contracts.Abstracts;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Moravia.Homework.Converter.FormatConverters
{
    /// <summary>
    /// JSON convertner
    /// </summary>
    public class JsonConverter : ISerializer, IDeserializer
    {
        /// <inheritdoc />
        public async Task<Stream> SerializeAsync(object input)
        {
            var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, input, input.GetType());

            return stream;
        }

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(Stream inputStream)
            => JsonSerializer.DeserializeAsync<T>(inputStream).AsTask();
    }
}
