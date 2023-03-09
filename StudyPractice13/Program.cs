using UP13;
public class Program
{
    static void Main(string[] args)
    {
        FirstTaskTests();
        SecondTaskTests();
        ThirdTaskTests();
    }
    public static void FirstTaskTests()
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
    public static void SecondTaskTests()
    {
        FileCreator.CreateFilesAndDirectories("second.txt");
    }
    public static void ThirdTaskTests()
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


