using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace UP12
{
    public class Program
    {
        static void Main(string[] args)
        {
            //  FIRST
            {
                Phonebook phonebook = new Phonebook("names.txt", "phones.txt");
                Console.WriteLine(phonebook.FindNameByPhone("+79001234567"));

                TextFileReader textReader = new TextFileReader("text.txt");
                textReader.PrintAsLine();
                textReader.PrintAsColumn();

                IntegerFileReader intReader = new IntegerFileReader("numbers.txt");
                intReader.PrintOddNumbers();

                TextAnalyzer analyzer = new TextAnalyzer("text2.txt", "text1.txt");
                analyzer.CountWordOccurrences();
            }
            // SECOND
            {
                FileCreator.CreateFilesAndDirectories("second.txt");
            }

            // THIRD
            {
                EmployeeCollection collection = new EmployeeCollection();

                Employee employee1 = new Employee { LastName = "Иванов", FirstName = "Иван", MiddleName = "Иванович", Position = Position.Manager, BirthYear = 1980, Salary = 50000 };
                Employee employee2 = new Employee { LastName = "Петров", FirstName = "Петр", MiddleName = "Петрович", Position = Position.Developer, BirthYear = 1990, Salary = 30000 };
                collection.Add(employee1);
                collection.Add(employee2);

                Employee employee3 = new Employee { LastName = "Сидоров", FirstName = "Сидор", MiddleName = "Сидорович", Position = Position.HR, BirthYear = 1985, Salary = 40000 };
                collection.Update(employee2, employee3);
                collection.Remove(employee1);

                collection.SaveToFile();
                collection.LoadFromFile();
            }


        }

    }

    class Phonebook
    {
        private Dictionary<string, string> _phonebook;

        public Phonebook(string namesFile, string phonesFile)
        {
            _phonebook = new Dictionary<string, string>();

            string[] names = File.ReadAllLines(namesFile);
            string[] phones = File.ReadAllLines(phonesFile);

            for (int i = 0; i < names.Length; i++)
            {
                _phonebook.Add(phones[i], names[i]);
            }
        }

        public string FindNameByPhone(string phone)
        {
            if (_phonebook.ContainsKey(phone))
            {
                return _phonebook[phone];
            }
            else
            {
                return "Фамилия не найдена";
            }
        }
    }
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
    class TextAnalyzer
    {
        private string _textFileName;
        private string _sentenceFileName;

        public TextAnalyzer(string textFileName, string sentenceFileName)
        {
            _textFileName = textFileName;
            _sentenceFileName = sentenceFileName;
        }

        public void CountWordOccurrences()
        {
            string text = File.ReadAllText(_textFileName);
            string sentence = File.ReadAllText(_sentenceFileName);

            string[] words = sentence.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string[] text_words = text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                int count = text_words.Where(n => n == word).Count();
                wordCounts[word] = count;
            }

            foreach (KeyValuePair<string, int> pair in wordCounts)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
    }
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
    public enum Position { Manager, Developer, HR, Sales }
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Position Position { get; set; }
        public int BirthYear { get; set; }
        public double Salary { get; set; }

        public Employee() { }

        public Employee(string firstName, string lastName, string middleName, Position position, int birthYear, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Position = position;
            BirthYear = birthYear;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}, {Position}, {BirthYear}, {Salary}";
        }
    }
    public class EmployeeCollection
    {
        private List<Employee> employees = new List<Employee>();
        private string fileName = "D:\\files\\УП\\UP13\\bin\\Debug\\net6.0\\employees.xml";

        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        public void Remove(Employee employee)
        {
            employees.Remove(employee);
        }

        public void Update(Employee oldEmployee, Employee newEmployee)
        {
            int index = employees.IndexOf(oldEmployee);
            if (index != -1)
            {
                employees[index] = newEmployee;
            }
        }

        public void Print()
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        public void SaveToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, employees);
            }
        }

        public void LoadFromFile()
        {
            if (File.Exists(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                using (StreamReader reader = new StreamReader(fileName))
                {
                    employees = (List<Employee>)serializer.Deserialize(reader);
                }
            }
        }
    }
}
