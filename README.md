# Moravia.Homework
### How to use?
```csharp
var xmlToJsonFileConveter = new FilesConverter(
    new JsonConverter(),
    new XmlConverter(),
    new HttpStorageProvider(),
    new FileStorageProvider()
    );
xmlToJsonFileConveter.ConvertAndSaveAsync<Document>(source, target)
```

### How to add a new storage provider?
1. Create new class in Moravia.Homework.Converter project, StorageProviders folder;
2. Implement interfaces: IFileReader and/or IFileWriter.

### How to add a new format?
1. Create new class in  Moravia.Homework.Converter, FormatConverters;
2. Implement interfaces: ISerializer and/or IDeserializer;
3. In the project Moravia.Homework.UnitTests add new tests for a new format converter.