using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using fans;

namespace NET
{
    [TestClass]
    public class UnitTest1
    {
        // FA1 tests

        [TestMethod]
        public void FA1_Test1()
        {
            string s = "0111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void FA1_Test2()
        {
            string s = "01011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void FA1_Test3()
        {
            string s = "110101011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void FA1_Test4()
        {
            string s = "1110111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void FA1_Test5()
        {
            string s = "10";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void FA1_Test6()
        {
            string s = "0";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void FA1_Test7()
        {
            string s = "1111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.AreEqual(false, result);
        }

        // FA2 tests

        [TestMethod]
        public void FA2_Test1()
        {
            string s = "0101";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void FA2_Test2()
        {
            string s = "00110011";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void FA2_Test3()
        {
            string s = "0001";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void FA2_Test4()
        {
            string s = "111000";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void FA2_Test5()
        {
            string s = "01";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void FA2_Test6()
        {
            string s = "000";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void FA2_Test7()
        {
            string s = "111";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.AreEqual(false, result);
        }

        // FA3 tests

        [TestMethod]
        public void FA3_Test1()
        {
            string s = "00110011";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void FA3_Test2()
        {
            string s = "0101";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void FA3_Test3()
        {
            string s = "11";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void FA3_Test4()
        {
            string s = "101010";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void FA3_Test5()
        {
            string s = "0110";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void FA3_Test6()
        {
            string s = "0000";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.AreEqual(false, result);
        }
    }
}
