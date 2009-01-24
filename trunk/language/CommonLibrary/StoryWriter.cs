/*
 * Created by: 
 * Created: zaterdag 24 januari 2009
 */

using System;

namespace CommonLibrary
{
    public class StoryWriter
    {
        private readonly Person person;

        public StoryWriter(Person person)
        {
            this.person = person;
        }

        public string PrintShortStory()
        {
            var story = string.Format("{0} says: Hello!", person.Name);

            story += Environment.NewLine;
            story += "(A plane flies by)";
            story += Environment.NewLine;
            story += string.Format("{0} says: How do you do?", person.Name);

            return story;
        }

        public string PrintLongStory()
        {
            var story = string.Format("{0} says: Hello!", person.Name);

            story += Environment.NewLine;
            story += "(A plane flies by)";
            story += Environment.NewLine;
            story += string.Format("{0} says: How do you do?", person.Name);
            story += Environment.NewLine;
            story += "(He starts to run)";
            story += Environment.NewLine;
            story += string.Format("{0} says: Try to follow me", person.Name);
            story += Environment.NewLine;
            story += "(He disappears in the night)";

            return story;
        }
    }
}