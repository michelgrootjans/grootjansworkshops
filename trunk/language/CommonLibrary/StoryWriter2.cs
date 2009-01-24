/*
 * Created by: 
 * Created: zaterdag 24 januari 2009
 */

using System;

namespace CommonLibrary
{
    public class StoryWriter2
    {
        private delegate string PrintOneLine(string input);

        private readonly Person hero;
        private readonly PrintOneLine heroSays;
        private readonly PrintOneLine backgroundNoise;

        public StoryWriter2(Person hero)
        {
            this.hero = hero;
            heroSays =
                delegate(string message) { return string.Format("{0} says: {1}", this.hero.Name, message); };
            backgroundNoise =
                delegate(string message) { return string.Format("({0})", message); };
        }

        public string PrintShortStory()
        {
            var story = new[]
                            {
                                heroSays("Hello!"),
                                backgroundNoise("A plane flies by"),
                                heroSays("How do you do?")
                            };

            return string.Join(Environment.NewLine, story);
        }

        public string PrintLongStory()
        {
            var story = new[]
                            {
                                heroSays("Hello!"),
                                backgroundNoise("A plane flies by"),
                                heroSays("How do you do?"),
                                backgroundNoise("He starts to run"),
                                heroSays("Try to follow me"),
                                backgroundNoise("He disappears in the night")
                            };

            return string.Join(Environment.NewLine, story);
        }
    }
    }