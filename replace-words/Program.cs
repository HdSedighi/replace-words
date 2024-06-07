using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> dictionary = new List<string> { "cat", "bat", "rat" };
        string sentence = "the cattle was rattled by the battery";
        string result = ReplaceWords(dictionary, sentence);
        Console.WriteLine(result); // Output: "the cat was rat by the bat"
        
        dictionary = new List<string> { "a", "b", "c" };
        sentence = "aadsfasf absbs bbab cadsfafs";
        result = ReplaceWords(dictionary, sentence);
        Console.WriteLine(result); // Output: "a a b c"
    }
    
    static string ReplaceWords(IList<string> dictionary, string sentence)
    {
        // Convert dictionary to List<string> and sort by the length of the roots
        List<string> sortedDictionary = dictionary.OrderBy(root => root.Length).ToList();
        
        // Split the sentence into words
        string[] words = sentence.Split(' ');
        
        // Iterate over each word in the sentence
        for (int i = 0; i < words.Length; i++)
        {
            foreach (string root in sortedDictionary)
            {
                // If the word starts with the root, replace it
                if (words[i].StartsWith(root))
                {
                    words[i] = root;
                    break; // Move to the next word
                }
            }
        }
        
        // Join the words back into a sentence
        return string.Join(" ", words);
    }
}
