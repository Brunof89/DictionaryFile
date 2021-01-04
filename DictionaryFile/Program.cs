using DictionaryFile.Domain.Requests;
using DictionaryFile.Domain.Services;
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

            try
            {
                await serviceProvider.GetService<App>().Run();

                var _dictionaryService = serviceProvider.GetService<IDictionaryFileService>();

                var fileExists = false;
                var correctWordLength = false;
                string startWord = string.Empty;
                string endWord = string.Empty;
                string dictionaryFilePath = string.Empty;

                while (!fileExists)
                {
                    Console.WriteLine("DictionaryFile:");
                    dictionaryFilePath = Console.ReadLine();
                    //CheckFileExists
                    fileExists = _dictionaryService.CheckFileExists(configuration.GetSection("FileBasePath").Value + dictionaryFilePath);
                }

                while (!correctWordLength)
                {
                    Console.WriteLine("StartWord:");
                    startWord = Console.ReadLine();
                    //Validate length of word
                    correctWordLength = _dictionaryService.CheckWordLength(startWord, 4);
                }

                correctWordLength = false;

                while (!correctWordLength)
                {
                    Console.WriteLine("EndWord:");
                    endWord = Console.ReadLine();
                    //Validate length of word
                    correctWordLength = _dictionaryService.CheckWordLength(endWord, 4);
                }

                Console.WriteLine("ResultFile:");
                string resultFile = Console.ReadLine();

                var inputs = new DictionaryFileRequest
                {
                    FileName = configuration.GetSection("FileBasePath").Value + dictionaryFilePath,
                    EndWord = endWord,
                    ResultFileName = configuration.GetSection("FileBasePath").Value + resultFile,
                    StartWord = startWord
                };

                _dictionaryService.ProcessWords(inputs);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
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

            // Add app
            serviceCollection.AddTransient<App>();
        }
    }
}
