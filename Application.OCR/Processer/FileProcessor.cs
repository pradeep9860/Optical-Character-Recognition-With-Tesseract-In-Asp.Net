using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Application.OCR.processer
{
    public class FileProcessor
    {
        public async Task Process(string filepath, IConfigurationRoot configurationRoot, ServiceProvider serviceProvider)
        {
            var archiveDirectory = configurationRoot.GetValue<string>("Directory:ArchiveDirectory");
            var testDataDirectory = configurationRoot.GetValue<string>("Directory:TestDataDirectory"); 
            var testImagePath = filepath;//"E:\\MyProj\\OCR\\tesseract-samples\\src\\Tesseract.ConsoleDemo\\workfolder\\phototest.tif";

            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                // var solutionDirectory = @"E:\Application Null Printer\Core\Application.NULLPrinter\Console\Application.OCR"; //Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

                var tesseractPath = testDataDirectory; 
                var imageFile = File.ReadAllBytes(filepath);
                var text = ParseText(tesseractPath, imageFile, "eng", "fra");
                Console.WriteLine("File:" + filepath + "\n" + text + "\n");
                await Parse(text, serviceProvider, filepath);
                //var testFiles = Directory.EnumerateFiles(solutionDirectory + @"\watcherDirecotory");

                //var maxDegreeOfParallelism = Environment.ProcessorCount;
                //Parallel.ForEach(testFiles, new ParallelOptions { MaxDegreeOfParallelism = maxDegreeOfParallelism }, (fileName) =>
                //{
                //    var imageFile = File.ReadAllBytes(fileName);
                //    var text = ParseText(tesseractPath, imageFile, "eng", "fra");
                //    Console.WriteLine("File:" + fileName + "\n" + text + "\n");
                //});

                stopwatch.Stop();
                Console.WriteLine("Duration: " + stopwatch.Elapsed);
                Console.WriteLine("File Parsing Completed \nNow looking for other file...");
                // Console.ReadLine();
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Console.WriteLine("Unexpected Error: " + e.Message);
                Console.WriteLine("Details: ");
                Console.WriteLine(e.ToString());
            }
            finally
            {
                await ArchiveFile(filepath, archiveDirectory, serviceProvider);
            }
            Console.Write("Now ready to process other files . . . ");
            //Console.ReadKey(true);
        }

        private static string ParseText(string tesseractPath, byte[] imageFile, params string[] lang)
        {
            string output = string.Empty;
            var tempOutputFile = Path.GetTempPath() + Guid.NewGuid();
            var tempImageFile = Path.GetTempFileName();

            try
            {
                File.WriteAllBytes(tempImageFile, imageFile);

                ProcessStartInfo info = new ProcessStartInfo();
                info.WorkingDirectory = tesseractPath;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                info.UseShellExecute = false;
                info.FileName = "cmd.exe";
                info.Arguments =
                    "/c tesseract.exe " +
                    // Image file.
                    tempImageFile + " " +
                    // Output file (tesseract add '.txt' at the end)
                    tempOutputFile +
                    // Languages.
                    " -l " + string.Join("+", lang);

                // Start tesseract.
                Process process = System.Diagnostics.Process.Start(info);
                process.WaitForExit();
                if (process.ExitCode == 0)
                {
                    // Exit code: success.
                    output = File.ReadAllText(tempOutputFile + ".txt");
                }
                else
                {
                    throw new Exception("Error. Tesseract stopped with an error code = " + process.ExitCode);
                }
            }
            finally
            {
                File.Delete(tempImageFile);
                File.Delete(tempOutputFile + ".txt");
            }
            return output;
        }

        public async Task ArchiveFile(string soucePath, string destinationPath, ServiceProvider serviceProvider)
        {
            
            var fileName = Path.GetFileName(soucePath).Split('.');

            destinationPath = destinationPath + "\\" + fileName[0]+"_"+DateTimeOffset.Now.ToUnixTimeMilliseconds() + "." + fileName[1];
            File.Move(soucePath, destinationPath); 
        }

        private async Task Parse(string text, ServiceProvider serviceProvider, string soucePath)
        {
            Console.Write(text);
            //add your parse logic here
        }
    }
}
