using DictionaryFile.Domain.Requests;
using DictionaryFile.Domain.Services;
using DictionaryFile.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DictionaryFile
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static int Main(string[] args)
        {
            try
            {
                MainAsync(args).Wait();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        static async Task MainAsync(string[] args)
        {
            // Create service collection
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            await serviceProvider.GetService<App>().Run();

            IDictionaryFileService _dictionaryService = serviceProvider.GetService<IDictionaryFileService>();
            IFileService _fileService = serviceProvider.GetService<IFileService>();

            if (args == null)
                throw new ArgumentNullException("Program must have arguments.");

            if (args.Length != 4)
                throw new ArgumentException("There must be 4 arguments in the list.");

            if (!_dictionaryService.CheckWordLength(args[1],4))
                throw new ArgumentException("Start word must have 4 chars.");

            if (!_dictionaryService.CheckWordLength(args[1], 4))
                throw new ArgumentException("End word must have 4 chars.");

            if (!_fileService.CheckFileExists(configuration.GetSection("FileBasePath").Value + args[0]))
                throw new FileNotFoundException("File provided not found");

            DictionaryFileRequest inputs = new DictionaryFileRequest
            {
                FileName = configuration.GetSection("FileBasePath").Value + args[0],
                EndWord = args[2],
                ResultFileName = configuration.GetSection("FileBasePath").Value + args[3],
                StartWord = args[1],
                WordLength = 4
            };

            _dictionaryService.ProcessWords(inputs);
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            serviceCollection.AddTransient<IDictionaryFileService, DictionaryFileService>();
            serviceCollection.AddTransient<IFileService, FileService>();

            // Add app
            serviceCollection.AddTransient<App>();
        }
    }
}
