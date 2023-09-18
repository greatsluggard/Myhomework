using Task1;

namespace Task1UnitTest
{
    public class Tests
    {
        private AssociativeArray<string> _associativeArray;

        [SetUp]
        public void Setup()
        {
            _associativeArray = new AssociativeArray<string>();
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
    }
}