using System.IO;
using System.Threading.Tasks;

namespace Moravia.Homework.Contracts.Abstracts
{
    /// <summary>
    /// FileReader interface
    /// </summary>
    public interface IFileReader
    {
        /// <summary>
        /// Read file 
        /// </summary>
        /// <param name="path">File full path</param>
        /// <returns></returns>
        Task<Stream> ReadAsync(string path);
    }
}
