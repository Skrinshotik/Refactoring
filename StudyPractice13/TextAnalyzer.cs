using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP13;
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
