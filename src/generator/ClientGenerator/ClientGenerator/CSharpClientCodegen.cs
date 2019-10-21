using System;
using System.IO;
using System.Linq;
using ClientGenerator.Core;

namespace ClientGenerator
{
    public static class CSharpClientCodegen
    {
        public static void Execute(string inputFolder)
        {
            var apiNames = CSharpApiClassesRetriever.GetNames(inputFolder).ToList();
            Console.WriteLine($"Retrieved {string.Join(", ", apiNames)}");
            var generatedClass = CSharpClientGenerator.GenerateClientClass(apiNames);
            CSharpApiClassWriter.Write(Path.Combine(inputFolder, "Client.cs"), generatedClass);
            Console.WriteLine("Generated Client class");
        }
    }
}