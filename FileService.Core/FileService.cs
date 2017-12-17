using System;
using System.IO;

namespace FileService.Core
{
    public class FileService
    {
        public const string InputDirectory = ".\\Input";
        public const string LogoDirectory = ".\\Logo";
        public const string OutputDirectory = ".\\Output";
        private const string InputImagePattern = "input";
        private const string OutputImagePattern = "output";

        public static void CreateIfNotExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static string GetOutputPath(string outputDirectory, string inputImagePath)
        {
            var originalFilename = Path.GetFileName(inputImagePath);

            if (originalFilename != null)
            {
                return Path.Combine(outputDirectory, originalFilename.Replace(InputImagePattern, OutputImagePattern));
            }

            throw new ArgumentNullException();
        }
    }
}