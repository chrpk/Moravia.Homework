using System.IO;
using System.Threading.Tasks;

namespace Moravia.Homework.Contracts.Abstracts
{
    /// <summary>
    /// Serializer interface
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serialize object method
        /// </summary>
        /// <param name="input">Object to serialize</param>
        /// <returns>Stream</returns>
        Task<Stream> SerializeAsync(object input);
    }
}
