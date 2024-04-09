using CommandLine;
using IpSelector.WorkWithFiles;
using System.CommandLine;

namespace EffectiveMobileTask
{
    partial class Program : FileReader
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                ProcessTheCommand();
            }
        }

        private static void ProcessTheCommand()
        {
            var words = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<Command >
        }

        public class CommandLineOptions
        {
            [Value(index: 0, Required = true, HelpText = "Путь к файлу изображения для анализа.")]
            public string Path { get; set; }

            [Option(shortName: 'c', longName: "confidence", Required = false, HelpText = "Minimum confidence.", Default = 0.9f)]
            public float Confidence { get; set; }
        }
    }
}
