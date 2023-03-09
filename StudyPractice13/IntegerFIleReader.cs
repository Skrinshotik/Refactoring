using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP13;
class IntegerFileReader
{
    private string _fileName;

    public IntegerFileReader(string fileName)
    {
        _fileName = fileName;
    }

    public void PrintOddNumbers()
    {
        int[] numbers = File.ReadAllLines(_fileName).Select(int.Parse).ToArray();
        foreach (int number in numbers)
        {
            if (number % 2 == 1)
            {
                Console.WriteLine(number);
            }
        }
    }
}