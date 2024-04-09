using IpSelector.WorkWithFiles;
using System.CommandLine;
using System.Net;

namespace EffectiveMobileTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var commandHandler = new CommandHandler();
            await commandHandler.Handle(args);
        }
    }

    public class CommandHandler
    {
        public async Task Handle(params string[] args)
        {
            var logFilePathOption = new Option<FileInfo>(
                name: "--file-log",
                description: "the path to the log file")
            { IsRequired = true };

            var fileOutputOption = new Option<FileInfo>(
                name: "--file-output",
                description: "the path to the file with the result")
            { IsRequired = true };

            var addressStartOption = new Option<IPAddress>(
                name: "--address-start",
                description: "the lower limit of the address range, optional parameter, " +
                "all addresses are processed by default");

            var addressMaskOption = new Option<IPAddress>(
                name: "--address-mask",
                description: "the subnet mask that sets the upper limit of the range to a decimal number. " +
                "An optional parameter. The parameter cannot be used if address-start is not specified");

            var timeStartOption = new Option<DateOnly>(
                name: "--time-start",
                description: "the lower limit of the time interval")
            { IsRequired = true };

            var timeEndOption = new Option<DateOnly>(
                name: "--time-end",
                description: "the upper limit of the time interval")
            { IsRequired = true };

            var rootCommand = new RootCommand()
            {
                logFilePathOption,
                fileOutputOption,
                addressStartOption,
                addressMaskOption,
                timeStartOption,
                timeEndOption,
            };

            rootCommand.SetHandler(async (logPath, outputPath, options) =>
            {                
                var logs = await FileReader.ReadFromFileAsync(logPath.FullName);
                var requests = LogAnalyzer.GetCountRequestsFromIpAddresses(logs, options);
                await FileWriter.WriteToFileAsync(outputPath.FullName, requests);
            },
            logFilePathOption, fileOutputOption, new OptionsBinder(
                timeStartOption,
                timeEndOption,
                addressStartOption,
                addressMaskOption));

            await rootCommand.InvokeAsync(args);
        }
    }
}