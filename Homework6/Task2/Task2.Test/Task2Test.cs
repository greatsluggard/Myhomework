using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackForHomework;
using System;

namespace Task2.Test
{
    [TestClass]
    public class Task2Test
    {
        [TestMethod]
        public void CheckFirstBracket() //проверка того, что первая скобка не может быть закрывающейся
        {
            //arrange
            string lineBrackets1;

            //act 
            lineBrackets1 = "(){}[[]]";

            //assert
            Assert.IsTrue(lineBrackets1[0] == '(' || lineBrackets1[0] == '[' || lineBrackets1[0] == '{');
        }

        [TestMethod]
        public void BracketsOnly () //то, что в строке могут быть только скобки
        {
            //arrange
            string lineBrackets2 = "([{}])";

            //act & assert
            for (int i = 0; i < lineBrackets2.Length; i++)
            {
                Assert.IsTrue(lineBrackets2[i] == '(' || lineBrackets2[i] == '[' || lineBrackets2[i] == '{' || lineBrackets2[i] == ')' || lineBrackets2[i] == '}' || lineBrackets2[i] == ']');
            }
        }
    }
}
