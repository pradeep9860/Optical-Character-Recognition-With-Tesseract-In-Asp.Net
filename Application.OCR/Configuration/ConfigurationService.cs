using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.OCR.FileProcessor.Configuration
{
    public static class ConfigurationService
    {
        public static IConfigurationRoot Configure()
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            return configuration;
        }
    }
}
