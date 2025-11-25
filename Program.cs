
//TODO: ADD COMMENTS ADD VALIDATION

namespace AdventureStoryGenerator
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Dictionary<string, string> templateMappingDictionary = new Dictionary<string, string>();
            string template = "";
            string story = "";

            StoryGenerator sg = new StoryGenerator();
            template = sg.ReadTemplate("story_template.txt");
            sg.GetUserInputs(template, ref templateMappingDictionary);
            story = sg.GenerateStory(template, templateMappingDictionary);
            sg.SaveStory(story);
        }
    }
}