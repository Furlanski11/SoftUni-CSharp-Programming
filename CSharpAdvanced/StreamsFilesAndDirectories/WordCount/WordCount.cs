namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";


            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            StreamReader lookedWords = new StreamReader(wordsFilePath);
            string[] words = lookedWords.ReadToEnd().Split(" ");
            lookedWords.Close();
            StreamReader givenText = new StreamReader(textFilePath);
            string text = givenText.ReadToEnd().ToLower();
            givenText.Close();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                dict.Add(word, 0);
            }
            foreach (string word in text.Split(' ', '.', '-', ',', '?', '!'))
            {
                if (dict.ContainsKey(word))
                {
                    dict[word] += 1;
                }
            }
            
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var item in dict.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
            
        }
    }
}
