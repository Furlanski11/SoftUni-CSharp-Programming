using System;
using System.IO;

namespace FolderSize
{
    internal class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            Console.WriteLine(GetFolderSize(folderPath,0));
        }
        public static long GetFolderSize(string path, int level)
        {
            Console.WriteLine($"{new string(' ', level *3)}{new DirectoryInfo(path).Name}");
            string[] filePaths = Directory.GetFiles(path);
            long size = 0;
            foreach (var filePath in filePaths)
            {
                FileInfo info = new FileInfo(filePath);
                size += info.Length;
                Console.WriteLine($"{new string(' ', (level + 1) * 3)}{info.Name}");
            }
            foreach (var dirPaths in Directory.GetDirectories(path))
            {
                size += GetFolderSize(dirPaths, level+1);
            }
            return size;
        }
    }
}

