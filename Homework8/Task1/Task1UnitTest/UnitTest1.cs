using Task1;
using NUnit.Framework;

namespace Task1UnitTest
{
    public class Tests
    {
        private AssociativeArray<string, string> _associativeArray;

        [SetUp]
        public void Setup()
        {
            _associativeArray = new AssociativeArray<string, string>();
        }

        [Test]
        public void CorrectReplaceValue()
        {
            string cat = "cat";
            string voice1 = "meow";
            string voice2 = "pow!";

            _associativeArray.Add(cat, voice1);
            _associativeArray.Add(cat, voice2);

            Assert.AreEqual(_associativeArray.GetValue(cat), voice2);
        }

        [Test]
        public void KeyCheck()
        {
            string cow = "cow";
            string voice = "moo";

            _associativeArray.Add(cow, voice);

            bool result = _associativeArray.Check(cow);
            bool expected = true;

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void CorrectDelete()
        {
            string name = "Ivan";
            string secondName = "Ivanov";

            _associativeArray.Add(name, secondName);
            _associativeArray.Delete(name);

            bool result = _associativeArray.Check(name);
            bool expected = false;

            Assert.AreEqual(result, expected);
        }
    }
}