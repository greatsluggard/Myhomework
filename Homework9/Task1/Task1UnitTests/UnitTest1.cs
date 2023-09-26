using NUnit.Framework;
using Task1;

namespace Task1UnitTests
{
    public class Tests
    {
        private HashTable _table;
        [SetUp]
        public void Setup()
        {
            _table = new HashTable(10);
        }

        [Test]
        public void CorrectValueByKey()
        {
            string key = "Students passed test";
            _table.Add(key, 5);

            int expected = 5;
            int actual = _table.Print(key);

            Assert.AreEqual(expected, actual);
        }

        /*[Test] Хз насколько корректно делать методы из основного кода публичными, лишь ради того, чтобы протестить их...
                 ...в общем GetIndex и GetHash закрыты в основном коде, но я на всякий их тоже протестил.
        public void CorrectHashing()
        {
            string key1 = "Hollywood";
            string key2 = "Japan";
            string key3 = "food";

            int index1 = _table.GetIndex(key1);
            int index2 = _table.GetIndex(key2);
            int index3 = _table.GetIndex(key3);

            bool equal = false;

            if ((index1 == index2) || (index1 == index3)) 
            {
                equal = true;
            }

            Assert.AreEqual(false, equal);
        }*/
    }
}