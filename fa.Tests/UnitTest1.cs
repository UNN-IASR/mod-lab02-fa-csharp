using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using fans;
namespace NET
{
    [TestClass]
    public class UnitTest1
    {
        //______________________________test_FA1
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
        public void TestMethod_fa1_1()
        {
            String s = "1111111111111111111111110";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }  
        [TestMethod]
        public void TestMethod_fa1_2()
        {
            String s = "010101010101010101010101010101";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod_fa1_3()
        {
            String s = "0000000000000000000000000000000001";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod_fa1_4()
        {
            String s = "111111101111111111111110";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod_fa1_5()
        {
            String s = "1111111111011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        } 

        //______________________________test_FA2
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
        public void TestMethod_fa2_1()
        {
            String s = "11111111111111111111111111111110";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod_fa2_2()
        {
            String s = "00000000000000000000000000000001";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod_fa2_3()
        {
            String s = "00110011001100111";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod_fa2_4()
        {
            String s = "001100110011001110";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }    
        //______________________________test_FA3
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
        public void TestMethod_fa3_1()
        {
            String s = "000000000011";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod_fa3_2()
        {
            String s = "000000000010";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod_fa3_3()
        {
            String s = "111111111111";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod_fa3_4()
        {
            String s = "110000000000";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }      
    }
}
