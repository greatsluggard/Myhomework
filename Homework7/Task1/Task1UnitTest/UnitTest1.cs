using Task1;

namespace Task1UnitTest
{
    public class Tests
    {
        [Test]
        public void ReplaceRoot()
        {
            //Assert
            Tree<int> tree = new Tree<int>();
            int expected = 25;

            //Act
            tree.Add(20);
            tree.Add(10);
            tree.Add(30);
            tree.Add(5);
            tree.Add(15);
            tree.Add(25);
            tree.Add(35);

            tree.Delete(20);

            int result = tree.ReturnRootData();

            //Assert 
            Assert.AreEqual(expected, result);
        }
    }
}