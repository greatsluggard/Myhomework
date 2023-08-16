using NUnit.Framework;

namespace Task4UnitTest

{
    public class Tests
    {
        [Test]
        public void IsNameMoreThanOneLetter()
        {
            string nameForNamesList;
            nameForNamesList = "Ivan";

            Assert.IsTrue(nameForNamesList.Length > 1);
        }
    }
}