using Moravia.Homework.Contracts.Models;
using Moravia.Homework.Converter;
using Moravia.Homework.Converter.FormatConverters;

namespace Moravia.Homework.UnitTests
{
    internal class FilesConverterTest
    {
        private string _testJson { get; set; }
        private string _testXml { get; set; }

        private InMemoryStorageProvider _storageProvider { get; set; }

        [SetUp]
        public void SetUp()
        {
            _testJson = "{\"Title\":\"TestTitle\",\"Text\":\"TestText\"}";
            _testXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Title>TestTitle</Title><Text>TestText</Text></Document>";
            _storageProvider = new InMemoryStorageProvider();

            _storageProvider.Files.Add("document.json", _testJson);
            _storageProvider.Files.Add("document.xml", _testXml);
        }

        [Test]
        public async Task XmlToJson_FileConverterTest()
        {
            // Arrange
            var jsonToXmlConverter = new FilesConverter(
                new JsonConverter(),
                new XmlConverter(),
                _storageProvider,
                _storageProvider
            );

            // Act
            await jsonToXmlConverter.ConvertAndSaveAsync<Document>("document.json", "document_1.xml");

            // Assert
            var xmlFileContent = _storageProvider.Files["document_1.xml"];
            Assert.AreEqual(_testXml, xmlFileContent);
        }

        [Test]
        public async Task JsonToXml_FileConverterTest()
        {
            // Arrange
            var xmlToJsonConverter = new FilesConverter(
                new XmlConverter(),
                new JsonConverter(),
                _storageProvider,
                _storageProvider
            );

            // Act
            await xmlToJsonConverter.ConvertAndSaveAsync<Document>("document.xml", "document_2.json");

            // Assert
            var xmlFileContent = _storageProvider.Files["document_2.json"];
            Assert.AreEqual(_testJson, xmlFileContent);
        }
    }
}
