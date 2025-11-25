//TODO: ADD COMMENTS AND VALIDATION

using System.Data;
using System.Text.RegularExpressions;

namespace AdventureStoryGenerator
{
    public class StoryGenerator
    {
        public string ReadTemplate(string fileName)
        {
            string template = "";
            try
            {
                using(StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), $"templates\\{fileName}")))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        template += line;
                    }
                }
            }catch(FileNotFoundException fnfe)
            {
                Console.WriteLine($"File could not be found at " + Path.Combine(Directory.GetCurrentDirectory(), $"templates\\{fileName}"));
                Environment.Exit(-1);
            }
            catch(IOException ioe)
            {
                Console.WriteLine($"File at {Path.Combine(Directory.GetCurrentDirectory(), $"templates\\{fileName}")} was busy.");
                Environment.Exit(-1);
            }
            
            Console.WriteLine(template);
            return template;
        }

        public string GenerateStory(string template, Dictionary<string, string> templateMappingDict)
        {
            string story = template;

            foreach(KeyValuePair<string, string> mappingPair in templateMappingDict)
            {
                story = story.Replace(mappingPair.Key, mappingPair.Value);
            }

            return story;
        }

        public void SaveStory(string story)
        {
            Console.Write("Enter a filename to save your story: ");
            string filename = Console.ReadLine();
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), $"output/{filename}"), story);
            Console.WriteLine($"The story is successfully saved to {Path.Combine(Directory.GetCurrentDirectory(),$"output/{filename}" )}");
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

                    while(true)
                    {
                        if ("aeiouy".Contains(formattedWord[0]))
                        {
                            Console.Write($"Enter an {formattedWord}: ");
                        } else
                        {
                            Console.Write($"Enter a {formattedWord}: ");
                        }

                        try
                        {
                            value = Console.ReadLine();

                            if(value == null) throw new NoNullAllowedException();
                            if(value.Trim().Length == 0) throw new Exception("Input cannot be blank.");

                            break;
                        }catch(NoNullAllowedException nnae)
                        {
                            Console.WriteLine("Input cannot be null.");
                        }catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
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