using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (FileStream streamRead = File.OpenRead(sourcePath))
            {
                using (FileStream streamWrite = File.OpenWrite(destinationPath))
                {
                    for (int i = 0; i < streamRead.Length; i++)
                    {
                        streamWrite.WriteByte((byte)streamRead.ReadByte());
                    }
                    return (int)streamWrite.Length;
                }
            }

        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            // TODO: step 1. Use StreamReader to read entire file in string
            byte[] data;
            using (StreamReader streamRead = new StreamReader(sourcePath))
            {            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class
                byte[] fileBytes = Encoding.UTF8.GetBytes(streamRead.ReadToEnd());
                // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)
                using (MemoryStream streamMemory = new MemoryStream(fileBytes))
                {
                    // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array
                    data = streamMemory.ToArray();
                }
            }
            using (StreamWriter streamWrite = new StreamWriter(destinationPath))
            {
                // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content
                char[] fileBytes = Encoding.UTF8.GetChars(data);
                for (int i = 0; i < fileBytes.Length; i++)
                {
                    streamWrite.Write(fileBytes[i]);
                }
                // TODO: step 6. Use StreamWriter here to write char array content in new file
                return fileBytes.Length;
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (FileStream streamRead = File.OpenRead(sourcePath))
            {
                using (FileStream streamWrite = File.OpenWrite(destinationPath))
                {
                    streamRead.CopyTo(streamWrite);
                    return (int)streamWrite.Length;
                }
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            // TODO: step 1. Use StreamReader to read entire file in string
            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class
            byte[] data;
            using (StreamReader streamRead = new StreamReader(sourcePath))
            {
                byte[] fileBytes = Encoding.UTF8.GetBytes(streamRead.ReadToEnd());
                // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)
                using (MemoryStream streamMemory = new MemoryStream(fileBytes))
                {
                    // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array
                    data = streamMemory.ToArray();
                }
            }

            using (StreamWriter streamWrite = new StreamWriter(destinationPath))
            {
                // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content
                char[] fileBytes = Encoding.UTF8.GetChars(data);
                streamWrite.Write(fileBytes);
                // TODO: step 6. Use StreamWriter here to write char array content in new file
                return fileBytes.Length;
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            byte[] data = File.ReadAllBytes(sourcePath);
            using (FileStream streamWrite = File.Open(destinationPath, FileMode.Create))
            {
                using (BufferedStream streamBuffer = new BufferedStream(streamWrite))
                {
                    streamBuffer.Write(data, 0, data.Length);
                    return (int)streamWrite.Length;
                }

            }
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            //throw new NotImplementedException();
            return 0;
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            if (sourcePath==destinationPath)
            {
                return true;
            }

            using (FileStream sourceFile = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream destinationFile = new FileStream(destinationPath, FileMode.Open, FileAccess.Read))
                {
                    if (sourceFile.Length != destinationFile.Length)
                    {
                        return false;
                    }
                    for (int i = 0; i < sourceFile.Length; i++)
                    {
                        if (sourceFile.ReadByte() != destinationFile.ReadByte())
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if(sourcePath == null)
            {
                throw new ArgumentNullException(nameof(sourcePath));
            }

            if(destinationPath == null)
            {
                throw new ArgumentNullException(nameof(destinationPath));
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException(nameof(sourcePath));
            }

            if (!File.Exists(destinationPath))
            {
                throw new FileNotFoundException(nameof(destinationPath));
            }
        }

        #endregion

        #endregion

    }
}
