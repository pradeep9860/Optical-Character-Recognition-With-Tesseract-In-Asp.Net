﻿using Application.OCR.FileProcessor.Configuration;
using Application.OCR.FileProcessor.Registrar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Application.OCR
{
    internal class Program
    {
        public static ServiceProvider serviceProvider { get; set; }
        public static IConfigurationRoot configurationRoot { get; set; }
        public static void Main()
        {
            StartConfigure();
        }

        public static void StartConfigure()
        {
            configurationRoot = ConfigurationService.Configure(); 
            serviceProvider = RegistrarService.Register(configurationRoot);

            var watcherDirectory = configurationRoot.GetValue<string>("Directory:WatcherDirectory");
            Run(watcherDirectory);
            Console.ReadKey();
        }

        //PermissionSet(SecurityAction.Demand, Name="FullTrust")]
        public static void Run(string watcherDirectory)
        {
            string[] args = System.Environment.GetCommandLineArgs();

            // If a directory is not specified, exit program.
            if (args.Length != 1)
            {
                // Display the proper way to call the program.
                Console.WriteLine("Usage: Watcher.exe (directory)");
                return;
            }

            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = watcherDirectory; //args[1];
                                                                                      /* Watch for changes in LastAccess and LastWrite times, and
                                                                                         the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            //watcher.Filter = "*.png";
            watcher.Filter = "*.*"; //don't watch for folder

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.IncludeSubdirectories = true;

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Console.WriteLine("Application is waiting for the file to be change in :" + watcherDirectory);
            Console.WriteLine("Press \'q\' to quit the application.");
            while (Console.Read() != 'q') ;
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType); 

            if (e.ChangeType == WatcherChangeTypes.Created)  
            {
                System.Threading.Thread.Sleep(2000); //wait for 2 sec
                new Application.OCR.processer.FileProcessor().Process(e.FullPath, configurationRoot, serviceProvider).Wait(); 
            } 
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        { 
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}
