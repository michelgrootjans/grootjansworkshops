using System;
using CommonLibrary;
using NUnit.Framework;

namespace dotnet2.Delegates
{
    [TestFixture]
    public class StringProcessorTest
    {
        [Test]
        public void test_story()
        {
            var michel = new Person("Michel");
            var story = new StoryWriter(michel);
            var phrases = new[] {"Michel says: Hello!", "(A plane flies by)", "Michel says: How do you do?"};
            var expectedResult = string.Join(Environment.NewLine, phrases);

            Assert.AreEqual(expectedResult, story.PrintShortStory());
        }

        [Test]
        public void test_long_story()
        {
            var michel = new Person("Michel");
            var story = new StoryWriter(michel);
            var phrases = new[] { "Michel says: Hello!", "(A plane flies by)", "Michel says: How do you do?", "(He starts to run)", "Michel says: Try to follow me", "(He disappears in the night)" };
            var expectedResult = string.Join(Environment.NewLine, phrases);

            Assert.AreEqual(expectedResult, story.PrintLongStory());
        }

        [Test]
        public void test_story2()
        {
            var michel = new Person("Michel");
            var story = new StoryWriter2(michel);
            var phrases = new[] {"Michel says: Hello!", "(A plane flies by)", "Michel says: How do you do?"};
            var expectedResult = string.Join(Environment.NewLine, phrases);

            Assert.AreEqual(expectedResult, story.PrintShortStory());
        }


        [Test]
        public void test_long_story2()
        {
            var michel = new Person("Michel");
            var story = new StoryWriter2(michel);
            var phrases = new[] { "Michel says: Hello!", "(A plane flies by)", "Michel says: How do you do?", "(He starts to run)", "Michel says: Try to follow me", "(He disappears in the night)" };
            var expectedResult = string.Join(Environment.NewLine, phrases);

            Assert.AreEqual(expectedResult, story.PrintLongStory());
        }
    }
}