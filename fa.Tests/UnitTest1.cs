using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using fans;
namespace NET
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            String s = "0111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            String s = "01011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod3()
        {
            String s = "110101011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod4()
        {
            String s = "1110111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod5()
        {
            String s = "10";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod6()
        {
            String s = "0101";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod7()
        {
            String s = "00110011";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod8()
        {
            String s = "0001";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod9()
        {
            String s = "111000";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod10()
        {
            String s = "00110011";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod11()
        {
            String s = "0101";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod12()
        {
            string s = "";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsFalse(result == true);
        }
        [TestMethod]
        public void TestMethod13()
        {
            string s = "0";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsFalse(result == true);
        }
        [TestMethod]
        public void TestMethod14()
        {
            string s = "10";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod15()
        {
            string s = "01";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod16()
        {
            string s = "000111";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod17()
        {
            string s = "010101";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod18()
        {
            string s = "11";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod19()
        {
            string s = "1011";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod20()
        {
            string s = "0";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsFalse(result == true);
        }
        [TestMethod]
        public void TestMethod21()
        {
            string s = "10101";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsFalse(result == true);
        }
    }
}
