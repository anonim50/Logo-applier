using System;
using System.Drawing;
using System.IO;
using ImageManipulator.Core;
using static FileService.Core.FileService;

namespace ImageManipulator.UI.Console
{
    class Program
    {
        static void Main()
        {
            ExitIfNotExists(InputDirectory);
            ExitIfNotExists(LogoDirectory);
            CreateIfNotExists(OutputDirectory);

            var logo = GetLogo();
            var inputFiles = Directory.GetFiles(InputDirectory,"*.bmp");

            for (int i = 0; i < inputFiles.Length; i++)
            {
                try
                {
                    Apply(logo, inputFiles[i]);
                }
                catch (Exception exception)
                {
                    System.Console.WriteLine(exception);
                }
            }
        }

        private static void ExitIfNotExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                System.Console.WriteLine($"[INFO] Directory not found: {directory}.\nPress enter to exit...");
                System.Console.Read();
                Environment.Exit(1);
            }
        }

        private static Logo GetLogo()
        {
            string logoPath = Directory.GetFiles(LogoDirectory)[0];
            return new Logo(new Bitmap(logoPath));
        }

        private static void Apply(Logo logo, string imagePath)
        {
            using (var inputImage = new Bitmap(imagePath))
            using (var outputImage = logo.ApplyTo(inputImage))
            {
                var outputPath = GetOutputPath(OutputDirectory, Path.GetFileName(imagePath));
                outputImage.Save(outputPath);
            }
        }
    }
}