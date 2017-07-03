using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Tests
{
    [TestClass]
    public class NumberExtensionTests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\DataForInsertion.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("Logic.Tests\\DataForInsertion.xml")]

        [TestMethod]
        public void MSUnitTest_Insert_CorrectInputValues_PositiveTest()
        {
            int firstNumber = Convert.ToInt32(TestContext.DataRow["FirstNumber"]);
            int secondNumber = Convert.ToInt32(TestContext.DataRow["SecondNumber"]);
            int startIndex = Convert.ToInt32(TestContext.DataRow["StartIndex"]);
            int endIndex = Convert.ToInt32(TestContext.DataRow["EndIndex"]);
            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            var actual = NumberExtension.Insertion(firstNumber, secondNumber, startIndex, endIndex);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod] 
        public void NextBiggerNumber_12_Returned21()
        {
            //Arrange Act Assert (AAA)

            //Arrange
            int number = 12;
            int next = 21;

            //Act
            int actual = NumberExtension.NextBiggerNumber(number);

            //Assert
            Assert.AreEqual(next, actual);
        }
    }
}
