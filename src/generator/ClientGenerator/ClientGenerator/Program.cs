using System;
using System.IO;
using Microsoft.Extensions.CommandLineUtils;

namespace ClientGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication();
            app.Name = "client-generator";
            app.HelpOption("-?|-h|--help");

            app.OnExecute(() =>
            {
                Console.WriteLine();
                Console.WriteLine(@"Usage: client-generator [options] [command]

Options:
  -?|-h|--help  Show help information

Commands:
  generate  Generate the client class containing all the APIs

Use ""client-generator [command] --help"" for more information about a command.");

                return 0;
            });

            app.Command("generate", (command) =>
            {
                command.Description = "Generate the client class containing all the APIs";
                command.HelpOption("-?|-h|--help");

                var languageOption = command.Option(
                    "-l|--language",
                    "The language to generate the client for",
                    CommandOptionType.SingleValue
                );

                var inputFolderOption = command.Option(
                    "-i|--input-folder",
                    "The input folder with the Api classes files",
                    CommandOptionType.SingleValue
                );

                command.OnExecute(() =>
                {
                    var inputFolder = inputFolderOption.Value();
                    if (!Directory.Exists(inputFolder))
                    {
                        Console.WriteLine($"Folder {inputFolder} does not exists.");
                        return 0;
                    }

                    var language = languageOption.Value();
                    switch (language)
                    {
                        case "csharp":
                            CSharpClientCodegen.Execute(inputFolder);
                            break;
                        default:
                            Console.WriteLine("Language not supported");
                            break;
                    }

                    Console.WriteLine();

                    return 0;

                });
            });

            app.Execute(args);
        }
    }
}
