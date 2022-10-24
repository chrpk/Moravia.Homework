using Moravia.Homework.Contracts.Abstracts;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Moravia.Homework.Converter.FormatConverters
{
    /// <summary>
    /// XML converter
    /// </summary>
    public class XmlConverter : ISerializer, IDeserializer
    {
        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(Stream inputStream)
        {
            var serializer = new XmlSerializer(typeof(T));
            var result = (T)serializer.Deserialize(inputStream);

            return Task.FromResult(result);
        }

        /// <inheritdoc />
        public Task<Stream> SerializeAsync(object input)
        {
            var serializer = new XmlSerializer(input.GetType());
            var stream = new MemoryStream();
            serializer.Serialize(stream, input);

            return Task.FromResult((Stream)stream);
        }
    }
}
