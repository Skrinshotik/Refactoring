using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UP13;
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