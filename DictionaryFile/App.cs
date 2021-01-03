using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryFile
{
    public class App
    {
        private readonly IConfigurationRoot _config;

        public App(IConfigurationRoot config)
        {
            _config = config;
        }

        public async Task Run()
        {
        }
    }
}
