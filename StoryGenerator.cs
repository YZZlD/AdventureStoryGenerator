using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventureStoryGenerator
{
    public class StoryGenerator
    {
        public string ReadTemplate()
        {
            string template = "";
            using(StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "templates/story_template.txt")))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    template += line;
                }
            }
            Console.WriteLine(template);
            return template;
        }

        public string GenerateStory()
        {
            return "";
        }

        public void SaveStory()
        {
            
        }

        public void GetUserInputs(string template, ref Dictionary<string, string> templateMappingDict)
        {
            List<string> words = template.Split(' ').ToList<string>();
            List<string> placeholders = new List<string>();

            foreach(string word in words)
            {
                if(word[0] == '{' && !placeholders.Contains(formatPlaceholder(word)))
                {
                    string formattedWord = formatPlaceholder(word);
                    formattedWord = formattedWord.Replace("_", " ");
                    formattedWord = formattedWord.Replace("{", "");
                    formattedWord = formattedWord.Replace("}", "");
                    placeholders.Add(formatPlaceholder(word));
                    string value = "";

                    if ("aeiouy".Contains(formattedWord[0]))
                    {
                        Console.Write($"Enter an {formattedWord}: ");
                        value = Console.ReadLine();
                    } else
                    {
                        Console.Write($"Enter a {formattedWord}: ");
                        value = Console.ReadLine();
                    }
                    templateMappingDict.Add(formatPlaceholder(word), value);
                }
            }
        }

        private static string formatPlaceholder(string word)
        {
            Regex pattern = new Regex("[,.!;'?)(]");
            string formattedWord = pattern.Replace(word, "");
            return formattedWord;
        }
    }
}