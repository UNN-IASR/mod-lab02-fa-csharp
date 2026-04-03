using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using fans;

namespace NET
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1_FA1_0111_True()
        {
            string s = "0111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void TestMethod2_FA1_01011_False()
        {
            string s = "01011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod3_FA1_110101011_False()
        {
            string s = "110101011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod4_FA1_1110111_True()
        {
            string s = "1110111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void TestMethod5_FA1_10_True()
        {
            string s = "10";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void TestMethod6_FA1_Empty_False()
        {
            string s = "";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod7_FA1_0_False()
        {
            string s = "0";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod8_FA1_1_False()
        {
            string s = "1";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod9_FA1_001_False()
        {
            string s = "001";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod10_FA1_101_True()
        {
            string s = "101";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void TestMethod11_FA2_0101_False()
        {
            string s = "0101";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod12_FA2_00110011_False()
        {
            string s = "00110011";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod13_FA2_0001_True()
        {
            string s = "0001";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void TestMethod14_FA2_111000_True()
        {
            string s = "111000";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void TestMethod15_FA2_Empty_False()
        {
            string s = "";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod16_FA2_0_False()
        {
            string s = "0";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod17_FA2_1_False()
        {
            string s = "1";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod18_FA2_01_True()
        {
            string s = "01";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void TestMethod19_FA2_10_True()
        {
            string s = "10";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void TestMethod20_FA3_00110011_True()
        {
            string s = "00110011";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void TestMethod21_FA3_0101_False()
        {
            string s = "0101";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod22_FA3_Empty_False()
        {
            string s = "";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod23_FA3_1_False()
        {
            string s = "1";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod24_FA3_11_True()
        {
            string s = "11";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void TestMethod25_FA3_101_False()
        {
            string s = "101";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethod26_FA3_110_True()
        {
            string s = "110";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void TestMethod27_FA3_011_True()
        {
            string s = "011";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
    }
}
