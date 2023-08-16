using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackForHomework;

namespace Task1.Test
{
    [TestClass]
    public class Task1Test
    {
        [TestMethod]
        public void PushToStack()
        {
            //arrange
            int number = 10;

            //act 
            MyStack stack = new MyStack();  
            stack.Push(number);

            //assert
            Assert.IsTrue((int) stack.Top() == 10);
        }

        [TestMethod]
        public void ShowSize()
        {
            //arrange
            int number1 = 10;
            int number2 = 20;
            int number3 = 30;

            //act 
            MyStack stack = new MyStack();
            stack.Push(number1);
            stack.Push(number2);
            stack.Push(number3);

            //assert
            Assert.IsTrue(stack.Size() == 3);
        }
    }
}
