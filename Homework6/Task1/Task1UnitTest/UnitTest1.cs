using StackForHomework;
using NUnit.Framework;

namespace Task1UnitTest
{
    public class Tests
    {

        [Test]
        public void PushToStack()
        {
            //arrange
            int number = 10;

            //act 
            MyStack<int> stack = new MyStack<int>();
            stack.Push(number);

            //assert
            Assert.IsTrue((int)stack.Top() == 10);
        }

        [Test]
        public void ShowSize()
        {
            //arrange
            int number1 = 10;
            int number2 = 20;
            int number3 = 30;

            //act 
            MyStack<int> stack = new MyStack<int>();
            stack.Push(number1);
            stack.Push(number2);
            stack.Push(number3);

            //assert
            Assert.IsTrue(stack.LenghtStack == 3);
        }
    }
}