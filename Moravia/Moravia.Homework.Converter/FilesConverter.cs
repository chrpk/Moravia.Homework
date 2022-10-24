using System.Threading.Tasks;
using Moravia.Homework.Contracts.Abstracts;

namespace Moravia.Homework.Converter
{
    /// <summary>
    /// Files converter
    /// </summary>
    public class FilesConverter
    {
        /// <summary>
        /// Serializer for source document.
        /// </summary>
        public ISerializer _serializer { get; set; }

        /// <summary>
        /// Serializer for result document.
        /// </summary>
        public IDeserializer _deserializer { get; set; }

        /// <summary>
        /// Reader for source file.
        /// </summary>
        private IFileReader _reader { get; set; }

        /// <summary>
        /// Writer for target file
        /// </summary>
        private IFileWriter _writer { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="deserializer">Deserializer: source</param>
        /// <param name="serializer">Serializer: target</param>
        /// <param name="reader">Reader: source</param>
        /// <param name="writer">Reader: target</param>
        public FilesConverter(
            IDeserializer deserializer,
            ISerializer serializer,
            IFileReader reader,
            IFileWriter writer
            )
        {
            _deserializer = deserializer;
            _serializer = serializer;
            _reader = reader;
            _writer = writer;
        }

        /// <summary>
        /// Converts source file and save a new file
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="sourcePath">Source file path</param>
        /// <param name="targetPath">Target file path</param>
        /// <returns></returns>
        public async Task ConvertAndSaveAsync<T>(string sourcePath, string targetPath)
        {
            using var inputStream = await _reader.ReadAsync(sourcePath);
            var @object = await _deserializer.DeserializeAsync<T>(inputStream);

            using var outputStream = await _serializer.SerializeAsync(@object);
            await _writer.WriteAsync(targetPath, outputStream);
        }
    }
}
