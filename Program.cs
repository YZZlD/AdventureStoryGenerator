using System.Data.SqlTypes;

namespace AdventureStoryGenerator
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Dictionary<string, string> templateMappingDictionary = new Dictionary<string, string>();
            string template = "";

            StoryGenerator sg = new StoryGenerator();
            template = sg.ReadTemplate();
            sg.GetUserInputs(template, ref templateMappingDictionary);

            foreach(KeyValuePair<string, string> mappingPair in templateMappingDictionary)
            {
                Console.WriteLine(mappingPair.Key + ": " + mappingPair.Value);
            }
        }
    }
}