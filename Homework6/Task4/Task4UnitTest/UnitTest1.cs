namespace Task4UnitTest
{
    public class Tests
    {
        private string nameForNamesList;

        [SetUp]
        public void Setup()
        {
            nameForNamesList = "Ivan";
        }

        [Test]
        public void IsMoreThanOneLetter()
        {
            Assert.IsFalse(nameForNamesList.Length == 1);
        }
    }
}