using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: WordCounter.exe <file_path> <search_word>");
            return;
        }

        string filePath = args[0];
        string searchWord = args[1];

        try
        {
            string content = File.ReadAllText(filePath);
            int count = CountWordOccurrences(content, searchWord);
            Console.WriteLine($"The word '{searchWord}' appears {count} times in the file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static int CountWordOccurrences(string text, string word)
    {
        return Regex.Matches(text, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase).Count;
    }
}