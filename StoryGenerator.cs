namespace AdventureStoryGenerator
{
    public class StoryGenerator
    {
        private Dictionary<string, string> _templateMappingDictionary;
        private List<string> _templateList;

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

        public void GetUserInputs()
        {
            
        }
    }
}