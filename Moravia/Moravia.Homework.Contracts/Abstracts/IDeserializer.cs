using System.IO;
using System.Threading.Tasks;

namespace Moravia.Homework.Contracts.Abstracts
{
    /// <summary>
    /// Deserializer interface
    /// </summary>
    public interface IDeserializer
    {
        /// <summary>
        /// Deserialize from stream to object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="inputStream">Input stream</param>
        /// <returns>Deserialized object</returns>
        Task<T> DeserializeAsync<T>(Stream inputStream);
    }
}
