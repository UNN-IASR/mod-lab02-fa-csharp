using Microsoft.VisualStudio.TestTools.UnitTesting;
using fans;

namespace fa.Tests
{
    [TestClass]
    public class UnitTest1
    {
        // --------------------- Тесты для FA1 (ровно один '0' и хотя бы одна '1') ---------------------
        [TestMethod]
        public void FA1_Accept_Valid1()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("01").Value);     // один 0, одна 1
        }

        [TestMethod]
        public void FA1_Accept_Valid2()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("10").Value);     // один 0, одна 1
        }

        [TestMethod]
        public void FA1_Accept_Valid3()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("0111").Value);   // один 0, несколько 1
        }

        [TestMethod]
        public void FA1_Accept_Valid4()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("1110").Value);   // один 0, несколько 1
        }

        [TestMethod]
        public void FA1_Reject_NoZero()
        {
            var fa = new FA1();
            Assert.IsFalse(fa.Run("111").Value);   // нет нулей
        }

        [TestMethod]
        public void FA1_Reject_TwoZeros()
        {
            var fa = new FA1();
            Assert.IsFalse(fa.Run("010").Value);   // два нуля
        }

        [TestMethod]
        public void FA1_Reject_NoOne()
        {
            var fa = new FA1();
            Assert.IsFalse(fa.Run("0").Value);     // есть 0, но нет 1
        }

        [TestMethod]
        public void FA1_Reject_Empty()
        {
            var fa = new FA1();
            Assert.IsFalse(fa.Run("").Value);      // пустая строка
        }

        // --------------------- Тесты для FA2 (нечётное количество '0' и нечётное количество '1') ---------------------
        [TestMethod]
        public void FA2_Accept_OneZeroOneOne()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("01").Value);     // 0:1(неч), 1:1(неч)
        }

        [TestMethod]
        public void FA2_Accept_ThreeZerosThreeOnes()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("000111").Value); // 0:3(неч), 1:3(неч)
        }

        [TestMethod]
        public void FA2_Accept_Mixed()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("001011").Value); // 0:3(неч), 1:3(неч)
        }

        [TestMethod]
        public void FA2_Reject_EvenZerosEvenOnes()
        {
            var fa = new FA2();
            Assert.IsFalse(fa.Run("0011").Value);  // 0:2(чет), 1:2(чет)
        }

        [TestMethod]
        public void FA2_Reject_EvenZerosOddOnes()
        {
            var fa = new FA2();
            Assert.IsFalse(fa.Run("001").Value);   // 0:2(чет), 1:1(неч)
        }

        [TestMethod]
        public void FA2_Reject_OddZerosEvenOnes()
        {
            var fa = new FA2();
            Assert.IsFalse(fa.Run("00011").Value); // 0:3(неч), 1:2(чет)
        }

        [TestMethod]
        public void FA2_Reject_Empty()
        {
            var fa = new FA2();
            Assert.IsFalse(fa.Run("").Value);      // 0:0(чет), 1:0(чет)
        }

        // --------------------- Тесты для FA3 (содержит "11") ---------------------
        [TestMethod]
        public void FA3_Accept_Simple()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("11").Value);
        }

        [TestMethod]
        public void FA3_Accept_WithPrefix()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("011").Value);
        }

        [TestMethod]
        public void FA3_Accept_WithSuffix()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("110").Value);
        }

        [TestMethod]
        public void FA3_Accept_Middle()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("10110").Value);
        }

        [TestMethod]
        public void FA3_Accept_Multiple()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("111").Value);
        }

        [TestMethod]
        public void FA3_Reject_No11()
        {
            var fa = new FA3();
            Assert.IsFalse(fa.Run("1010").Value);
        }

        [TestMethod]
        public void FA3_Reject_SingleOne()
        {
            var fa = new FA3();
            Assert.IsFalse(fa.Run("1").Value);
        }

        [TestMethod]
        public void FA3_Reject_Empty()
        {
            var fa = new FA3();
            Assert.IsFalse(fa.Run("").Value);
        }

        [TestMethod]
        public void FA3_Reject_OnlyZeros()
        {
            var fa = new FA3();
            Assert.IsFalse(fa.Run("000").Value);
        }
    }
}
