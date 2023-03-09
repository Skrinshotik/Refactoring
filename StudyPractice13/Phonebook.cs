using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP13;
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
