using System.IO;
using ClientGenerator.Core;
using NUnit.Framework;

namespace ClientGenerator.IntegrationTests
{
    [TestFixture]
    public class CSharpApiClassWriterShould
    {
        [Test]
        public void WriteFileToDisk()
        {
            string apiFilePath = Path.Combine(Path.GetTempPath(), "FooApi.cs");
            string updatedContent = "foo foo";
            CSharpApiClassWriter.Write(apiFilePath, updatedContent);

            Assert.That(File.ReadAllText(apiFilePath), Is.EqualTo(updatedContent));
        }
    }
}