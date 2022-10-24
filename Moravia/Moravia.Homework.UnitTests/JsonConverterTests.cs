using Moravia.Homework.Contracts.Models;
using Moravia.Homework.Converter.FormatConverters;
using System.Text;

namespace Moravia.Homework.UnitTests
{
    public class JsonConverterTests
    {
        private string _testJson { get; set; }
        private JsonConverter _jsonConverter { get; set; }

        [SetUp]
        public void SetUp()
        {
            _testJson = "{\"Title\":\"TestTitle\",\"Text\":\"TestText\"}";
            _jsonConverter = new JsonConverter();
        }

        [Test]
        public async Task JsonConverter_DeserializeAsyncTest()
        {
            // Arrange
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(_testJson));

            // Act
            var result = await _jsonConverter.DeserializeAsync<Document>(inputStream);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("TestTitle", result.Title);
            Assert.AreEqual("TestText", result.Text);
        }

        [Test]
        public async Task JsonConverter_SerializeAsyncTest()
        {
            // Arrange
            var model = new Document
            {
                Title = "TestTitle",
                Text = "TestText"
            };
            using var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(_testJson));

            // Act
            using var resultStream = await _jsonConverter.SerializeAsync(model);
            resultStream.Seek(0, SeekOrigin.Begin);

            using (var stream = new StreamReader(resultStream))
            {
                var result = await stream.ReadToEndAsync();
                // Assert
                Assert.IsNotNull(resultStream);
                Assert.AreEqual(_testJson, result);
            }
        }
    }
}