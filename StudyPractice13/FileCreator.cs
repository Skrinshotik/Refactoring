using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP13;
class FileCreator
{
    static public void CreateFilesAndDirectories(string inputFilePath)
    {
        string[] lines = File.ReadAllLines(inputFilePath);

        foreach (string line in lines)
        {
            string[] elements = line.Split(' ');
            foreach (string element in elements)
            {
                if (element.StartsWith("A"))
                {
                    string directoryName = element.Substring(2, element.Length - 3);
                    Directory.CreateDirectory(directoryName);
                    Directory.SetCurrentDirectory(directoryName);
                }
                else if (element.StartsWith("X"))
                {
                    int fileCount = int.Parse(element.Substring(2, element.Length - 3));

                    for (int i = 1; i <= fileCount; i++)
                    {
                        File.Create(Directory.GetCurrentDirectory() + "\\" + i + ".txt");
                    }
                }
            }
        }
    }
}
