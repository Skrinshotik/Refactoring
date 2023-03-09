using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP13;
class TextFileReader
{
    private string _fileName;

    public TextFileReader(string fileName)
    {
        _fileName = fileName;
    }

    public void PrintAsLine()
    {
        string[] text = File.ReadAllLines(_fileName);
        foreach (var i in text)
            Console.Write(i + " ");
        Console.WriteLine();
    }

    public void PrintAsColumn()
    {
        string[] lines = File.ReadAllLines(_fileName);
        foreach (string line in lines)
        {
            string[] buf = line.Split();
            foreach (string word in buf)
                Console.WriteLine(word);
        }
    }
}