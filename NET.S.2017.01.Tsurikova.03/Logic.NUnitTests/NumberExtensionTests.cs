using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logic.NUnitTests
{
    public class NumberExtensionTests
    {
        #region Insertion

        public static IEnumerable<TestCaseData> TestDataForInsertion
        {
            get
            {
                yield return new TestCaseData(8, 15, 0, 0).Returns(9);
                yield return new TestCaseData(0, 15, 30, 30).Returns(1073741824);
                yield return new TestCaseData(0, 15, 0, 30).Returns(15);
                yield return new TestCaseData(int.MaxValue, int.MaxValue, 3, 5).Returns(int.MaxValue);
                yield return new TestCaseData(15, int.MaxValue, 3, 5).Returns(63);
                yield return new TestCaseData(15, 15, 1, 3).Returns(15);
                yield return new TestCaseData(15, 15, 1, 4).Returns(31);
                yield return new TestCaseData(15, -15, 0, 4).Returns(17); //31
                yield return new TestCaseData(15, -15, 1, 4).Returns(3); //15
                yield return new TestCaseData(-8, -15, 1, 4).Returns(-30); //-6

            }
        }

        [Test, TestCaseSource(nameof(TestDataForInsertion))]
        public int Insertion_Data_Number(int num1, int num2, int i, int j)
        {
            return NumberExtension.Insertion(num1, num2, i, j);
        }

        [TestCase(8, 15, -1, 5)]
        [TestCase(8, 15, 5, -1)]
        [TestCase(8, 15, 32, 5)]
        [TestCase(8, 15, 5, 32)]
        public void Insertion_Data_ThrowsArgumentOutOfRangeException(int num1, int num2, int i, int j)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumberExtension.Insertion(num1, num2, i, j));
        }

        [TestCase(8, 15, 7, 5)]
        [TestCase(8, 15, 1, 0)]
        public void Insertion_Data_ArgumentException(int num1, int num2, int i, int j)
        {
            Assert.Throws<ArgumentException>(() => NumberExtension.Insertion(num1, num2, i, j));
        }

        #endregion

        #region NextBiggerNumber

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1204321, ExpectedResult = 1210234)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public static int NextBiggerNumber_Number_Result(int number)
        {
            return NumberExtension.NextBiggerNumber(number);
        }

        #endregion
    }
}
