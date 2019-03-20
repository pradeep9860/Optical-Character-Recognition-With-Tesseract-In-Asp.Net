
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using Application.OCR;

namespace Application.OCR.FileProcessor.Registrar
{
    public static class RegistrarService
    {
        public static ServiceProvider Register(IConfigurationRoot configurationRoot)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
            //    .AddSingleton<IMongoDbContext, MongoDbContext>()
            //    .AddSingleton(typeof(IMongoRepository<,>), typeof(MongoRepository<,>))
            //    .AddSingleton<IHostingEnvironment, HostingEnvironment>() 
            //    .AddSingleton<IPdfHandlerService, PdfHandlerService>() 
            //    .AddSingleton<IOrderService, OrderService>() 
            //    .AddSingleton<IFileProcessedLogService, FileProcessedLogService>()
            //    .Configure<Settings>(options =>
            //    {
            //        options.UseFromDBConfig = Convert.ToBoolean(configurationRoot.GetSection("PDF:UseFromDBConfig").Value);
            //        options.DefaultDirectoryPath = configurationRoot.GetSection("PDF:DefaultDirectoryPath").Value;
            //        options.DirectoryPath = configurationRoot.GetSection("PDF:DirectoryPath").Value;
            //        options.ArchiveDirectoryPath = configurationRoot.GetSection("PDF:ArchiveDirectoryPath").Value;
            //    })
            //     .Configure<TokenAuthConfiguration>(options =>
            //     {
            //         options.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configurationRoot["Authentication:JwtBearer:SecurityKey"]));
            //         options.Issuer = configurationRoot["Authentication:JwtBearer:Issuer"];
            //         options.Audience = configurationRoot["Authentication:JwtBearer:Audience"];
            //         options.SigningCredentials = new SigningCredentials(options.SecurityKey, SecurityAlgorithms.HmacSha256);
            //         options.Expiration = TimeSpan.FromDays(1);
            //     }) 
            //    .Configure<MongoDbSettings>(options =>
            //    {
            //        options.ConnectionString
            //            = configurationRoot["MongoSettings:ConnectionString"];
            //        options.Database
            //            = configurationRoot["MongoSettings:Database"];
            //    })
             .BuildServiceProvider();

            ////configure console logging
            //serviceProvider
            //    .GetService<ILoggerFactory>()
            //    .AddConsole(LogLevel.Debug);

            //var logger = serviceProvider.GetService<ILoggerFactory>()
            //    .CreateLogger<Program>();
            //logger.LogDebug("Starting application");

            //do the actual work here
            return serviceProvider;
        }
    }
}
