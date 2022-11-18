using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using SumMaxElement;
using System.IO;
using System.Reflection;
using static SumMaxElement.LinesArrayClass;

namespace MaxSumTests
{
    [TestClass]
    public class MaxSumTest
    {
        [DataRow(@"input.txt")]
        [DataTestMethod]

        public void TestGetWrongElementsNumber(string fileName)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\")) + fileName;
            LinesArrayClass result = new LinesArrayClass(path);
            List<int> expected = new List<int>() { 0, 1, 6 };
            
            Assert.AreEqual(expected.Count, result.GetWrongElementsNumber().Count);
            CollectionAssert.AreEqual(expected, result.GetWrongElementsNumber());
        }

        [DataRow(@"input.txt", 255)]
        [DataRow(@"input1.txt", -4)]
        [DataRow(@"input2.txt", null)]

        [DataTestMethod]
        public void TestGetMaxSum(string fileName, int? expected)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\")) + fileName;
            LinesArrayClass temp = new LinesArrayClass(path);
            if (expected != null)
            Assert.AreEqual(Convert.ToDecimal(expected), temp.GetMaxSum());
            if (expected == null)
            Assert.AreEqual(expected, temp.GetMaxSum());
        }

        [DataRow(@"asdasdasd")]
        [DataRow(@"input.txd123")]

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException),
         "A incorrect path to file was inappropriately allowed.")]
        public void TestLinesArrayClassIncorectPath(string path)
        {
            LinesArrayClass temp = new LinesArrayClass(path);
        }
    }
}