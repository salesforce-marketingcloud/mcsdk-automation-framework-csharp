using System.IO;

namespace ClientGenerator.Core
{
    public static class CSharpApiClassWriter
    {
        public static void Write(string apiFilePath, string content)
        {
            File.WriteAllText(apiFilePath, content);
        }
    }
}