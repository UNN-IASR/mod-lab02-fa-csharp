using Microsoft.VisualStudio.TestTools.UnitTesting;
using fans;

// 22 теста: 7 для FA1, 7 для FA2, 8 для FA3
namespace fa.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FA1_OneZeroOneOne_Accept()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("011") == true);
        }

        [TestMethod]
        public void FA1_OneZeroManyOnes_Accept()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("1110111") == true);
        }

        [TestMethod]
        public void FA1_ZeroThenOne_Accept()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("01") == true);
        }

        [TestMethod]
        public void FA1_OnlyZero_Reject()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("0") == false);
        }

        [TestMethod]
        public void FA1_NoZero_Reject()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("111") == false);
        }

        [TestMethod]
        public void FA1_TwoZeros_Reject()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("0110") == false);
        }

        [TestMethod]
        public void FA1_Empty_Reject()
        {
            var fa = new FA1();
            Assert.IsTrue(fa.Run("") == false);
        }

        [TestMethod]
        public void FA2_OddZerosOddOnes_Accept()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("01") == true);
        }

        [TestMethod]
        public void FA2_OddZerosOddOnes_Long_Accept()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("000111") == true);
        }

        [TestMethod]
        public void FA2_Alternating_Accept()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("010101") == true);
        }

        [TestMethod]
        public void FA2_EvenZerosEvenOnes_Reject()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("0011") == false);
        }

        [TestMethod]
        public void FA2_OnlyOnes_Reject()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("111") == false);
        }

        [TestMethod]
        public void FA2_OnlyZeros_Reject()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("000") == false);
        }

        [TestMethod]
        public void FA2_Empty_Reject()
        {
            var fa = new FA2();
            Assert.IsTrue(fa.Run("") == false);
        }

        [TestMethod]
        public void FA3_ContainsEleven_Accept()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("0011") == true);
        }

        [TestMethod]
        public void FA3_OnlyEleven_Accept()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("11") == true);
        }

        [TestMethod]
        public void FA3_ElevenAtStart_Accept()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("11000") == true);
        }

        [TestMethod]
        public void FA3_ElevenAtEnd_Accept()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("00011") == true);
        }

        [TestMethod]
        public void FA3_NoEleven_Reject()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("010") == false);
        }

        [TestMethod]
        public void FA3_SingleOne_Reject()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("1") == false);
        }

        [TestMethod]
        public void FA3_OnlyZeros_Reject()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("000") == false);
        }

        [TestMethod]
        public void FA3_Empty_Reject()
        {
            var fa = new FA3();
            Assert.IsTrue(fa.Run("") == false);
        }
    }
}