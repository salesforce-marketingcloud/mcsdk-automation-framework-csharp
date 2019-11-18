using System.IO;
using System.Linq;
using System.Text;
using ClientGenerator.Core;
using NUnit.Framework;

namespace ClientGenerator.IntegrationTests
{
    [TestFixture]
    public class CSharpApiClassesRetrieverShould
    {
        [Test]
        public void RetrieveOnlyApiClassNamesOrderedAscending()
        {
            CreateApiFile("BaseApi.cs", "base api class");
            CreateApiFile("FooApi.cs", "foo");
            CreateApiFile("BarApi.cs", "bar");
            CreateApiFile("BazApi.cs", "baz");
            CreateApiFile("Qux.cs", "qux");

            string apiFilesDirectory = Path.GetTempPath();
            var apiClassNames = CSharpApiClassesRetriever.GetNames(apiFilesDirectory);

            var classNames = apiClassNames.ToList();
            Assert.That(3, Is.EqualTo(classNames.Count));
            Assert.That("BarApi", Is.EqualTo(classNames[0]));
            Assert.That("BazApi", Is.EqualTo(classNames[1]));
            Assert.That("FooApi", Is.EqualTo(classNames[2]));
        }

        private void CreateApiFile(string apiFileName, string content)
        {
            string apiFilePath = Path.Combine(Path.GetTempPath(), apiFileName);
            using (var fileStream = File.Create(apiFilePath))
            {
                fileStream.Write(Encoding.UTF8.GetBytes(content));
            }
        }
    }
}