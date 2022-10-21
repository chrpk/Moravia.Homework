// 1. Using directives are unnecessary: 3
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Moravia.Homework
{
    /// 2. The class must be placed in a separate file.
    public class Document
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 3. Variable names do not match.
            // These variables store the full paths to the files.
            // var sourceFilePath = ...
            // var targetFilePath = ...
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\SourceFiles\\Document1.xml");
           
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\TargetFiles\\Document1.json");
            try
            {
                FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
                var reader = new StreamReader(sourceStream);
                string input = reader.ReadToEnd();

                // 4. StreamReader 'reader' is not disposed.
                // using(var sw = new StreamReader(...)) { ... }
            }
            // 5. One catch for all excetion types,
            // but code can throw 9 different exceptions.
            catch (Exception ex)
            {
                // 6. Throws a less informative
                // IOException or OutOfMemoryException is more informative.
                throw new Exception(ex.Message);
            }
            
            // 7. The variable 'input' is not available here. 
            var xdoc = XDocument.Parse(input);

            // 8.Loss of data due to strict binding to a specific xml structure.
            var doc = new Document
            {
                // 9.NullRef
                Title = xdoc.Root.Element("title").Value,
                // NullRef
                Text = xdoc.Root.Element("text").Value
            };
            var serializedDoc = JsonConvert.SerializeObject(doc);

            // 10. Exceptions not handled for File.Open()
            var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(targetStream);
            sw.Write(serializedDoc);

            // 11. StreamWriter 'sw' is not disposed.
            // using(var sw = new StreamWriter(...)) { ... }
        }
    }
}