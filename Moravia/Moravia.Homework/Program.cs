using Moravia.Homework.Contracts.Models;
using Moravia.Homework.Converter;
using Moravia.Homework.Converter.FormatConverters;
using Moravia.Homework.Converter.StorageProviders;

namespace Moravia.Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = "https://gist.githubusercontent.com/chrpk/91c44434080ebf5b439c96bba874a2e1" +
                "/raw/53973ddaeab872ac6f34f66e44328048f1f6096e/gistfile1.txt";
            var target = Path.Combine(Environment.CurrentDirectory, "Examples", "document.xml");

            var xmlToJsonFileConveter = new FilesConverter(
                new JsonConverter(),
                new XmlConverter(),
                new HttpStorageProvider(),
                new FileStorageProvider()
                );

            xmlToJsonFileConveter.ConvertAndSaveAsync<Document>(source, target)
                .GetAwaiter()
                .GetResult();
        }
    }
}