using System.IO;
using System.Threading.Tasks;

namespace Moravia.Homework.Contracts.Abstracts
{
    /// <summary>
    /// FileWriter interface
    /// </summary>
    public interface IFileWriter
    {
        /// <summary>
        /// Write stream
        /// </summary>
        /// <param name="path">File full path</param>
        /// <param name="stream">File stream</param>
        /// <returns></returns>
        Task WriteAsync(string path, Stream stream);
    }
}
