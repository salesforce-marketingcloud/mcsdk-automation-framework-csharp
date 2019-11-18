using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClientGenerator.Core
{
    public static class CSharpApiClassesRetriever
    {
        public static IEnumerable<string> GetNames(string apiFilesDirectory)
        {
            var apiFiles = Directory.GetFiles(apiFilesDirectory, "*Api.cs", SearchOption.TopDirectoryOnly);
            var apiFilesOrderedByName = apiFiles.Where(file => !file.EndsWith("BaseApi.cs")).OrderBy(file => file);
            foreach (var apiFile in apiFilesOrderedByName)
            {
                yield return Path.GetFileNameWithoutExtension(apiFile);
            }
        }
    }
}