using System;
using System.IO;

namespace Task_2
{
    public class RandomBytesFileGenerator : RandomFileGenerator
    {
        public override string WorkingDirectory
        {
            get
            {
                return "Files with random bytes";
            }
        }

        public override string FileExtension
        {
            get
            {
                return ".bytes";
            }
        }

        protected override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }

        private byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}