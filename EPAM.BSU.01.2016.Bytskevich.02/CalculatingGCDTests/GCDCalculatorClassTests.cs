using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using CalculatingGCD;

namespace CalculatingGCDTests
{
    [TestClass]
    public class GCDCalculatorClassTests
    {
        #region Tests for Euclidean algorithm methods
        [TestMethod]
        public void GetGCD_TwoPositiveNumbers_NotNullGCD()
        {
            int arrangeGCD = 21;
            string elapsedTime; 
            int actGCD = GCDCalculator.GetGCD(252, 105, out elapsedTime);
            Debug.WriteLine("GCD(252, 105) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetGCD_TwoSameNegativeandPositiveNumbers_TheSamePositiveNumber()
        {
            int arrangeGCD = 12345;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(-12345, 12345, out elapsedTime);
            Debug.WriteLine("GCD(12345, -12345) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetGCD_OneOfTwoNumbersIsNull_GCDIsNull()
        {
            int arrangeGCD = 252;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(252, 0, out elapsedTime);
            Debug.WriteLine("GCD(252, 0) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetGCD_BothNumbersAreNull_ArgumentException()
        {
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(0, 0, out elapsedTime);
        }

        [TestMethod]
        public void GetGCD_OneOfTwoNumbersIsNegative_NotNullPositiveGCD()
        {
            int arrangeGCD = 21;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(252, -105, out elapsedTime);
            Debug.WriteLine("GCD(252, -105) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetGCD_ThreePositiveNumbers_NotNullGCD()
        {
            int arrangeGCD = 256;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(1024, 512, 256, out elapsedTime);
            Debug.WriteLine("GCD(1024, 512, 256) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetGCD_TwoOfThreeNumbersAreNegative_NotNullGCD()
        {
            int arrangeGCD = 256;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(1024, -512, -256, out elapsedTime);
            Debug.WriteLine("GCD(1024, -512, -256) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetGCD_TwoOfThreeNumbersAreNull_NotNullGCD()
        {
            int arrangeGCD = 256;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(0, 0, -256, out elapsedTime);
            Debug.WriteLine("GCD(0, 0, -256) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetGCD_ThreeOfThreeNumbersAreNull_ArgumentException()
        {
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(0, 0, 0, out elapsedTime);
        }

        [TestMethod]
        public void GetGCD_SevenPositiveNumbers_NotNullGCD()
        {
            int arrangeGCD = 2;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(out elapsedTime, 2, 4, 8, 16, 32, 64, 128) ;
            Debug.WriteLine("GCD(2, 4, 8, 16, 32, 64, 128) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetGCD_FiveOfTenNumbersAreNegative_NotNullGCD()
        {
            int arrangeGCD = 2;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(out elapsedTime, 2, -4, 8, -16, 32, -64, 128, -256, 512, -1024);
            Debug.WriteLine("GCD( 2, -4, 8, -16, 32, -64, 128, -256, 512, -1024) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetGCD_TenSameNegativeNumbers_NotNullGCD()
        {
            int arrangeGCD = 13;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(out elapsedTime, -13, -13, -13, -13, -13, -13, -13, -13, -13, -13);
            Debug.WriteLine("GCD(-13, -13, -13, -13, -13, -13, -13, -13, -13, -13) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetGCD_FiveNullNumbers_ArgumentException()
        {
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(out elapsedTime, 0, 0, 0, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetGCD_NoNumbersGiven_ArgumentException()
        {
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(out elapsedTime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetGCD_OnlyOneNumberGiven_ArgumentException()
        {
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCD(out elapsedTime, -5);
        }
#endregion

        #region Tests for Stein's (binary) algorithm methods
        [TestMethod]
        public void GetBinaryGCD_TwoPositiveNumbers_NotNullGCD()
        {
            int arrangeGCD = 13;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(169, 1326, out elapsedTime);
            Debug.WriteLine("binary GCD(169, 1326) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetBinaryGCD_TwoSameNegativeandPositiveNumbers_TheSamePositiveNumber()
        {
            int arrangeGCD = 12345;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(-12345, 12345, out elapsedTime);
            Debug.WriteLine("GCD(12345, -12345) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetBinaryGCD_OneOfTwoNumbersIsNull_GCDIsNull()
        {
            int arrangeGCD = 252;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(252, 0, out elapsedTime);
            Debug.WriteLine("binary GCD(252, 0) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBinaryGCD_BothNumbersAreNull_ArgumentException()
        {
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(0, 0, out elapsedTime);
        }
        
        [TestMethod]
        public void GetBinaryGCD_OneOfTwoNumbersIsNegative_NotNullPositiveGCD()
        {
            int arrangeGCD = 202;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(116150, -232704, out elapsedTime);
            Debug.WriteLine("binary GCD(116150, -232704) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }
        
        [TestMethod]
        public void GetBinaryGCD_ThreePositiveNumbers_NotNullGCD()
        {
            int arrangeGCD = 2560;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(10240, 5120, 2560, out elapsedTime);
            Debug.WriteLine("binary GCD(10240, 5120, 2560) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetBinaryGCD_TwoOfThreeNumbersAreNegative_NotNullGCD()
        {
            int arrangeGCD = 256;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(1024, -512, -256, out elapsedTime);
            Debug.WriteLine("binary GCD(1024, -512, -256) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetBinaryGCD_TwoOfThreeNumbersAreNull_NotNullGCD()
        {
            int arrangeGCD = 256;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(0, 0, -256, out elapsedTime);
            Debug.WriteLine("binary GCD(0, 0, -256) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBinaryGCD_ThreeOfThreeNumbersAreNull_ArgumentException()
        {
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(0, 0, 0, out elapsedTime);
        }

        [TestMethod]
        public void GetBinaryGCD_SevenPositiveNumbers_NotNullGCD()
        {
            int arrangeGCD = 2;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(out elapsedTime, 2, 4, 8, 16, 32, 64, 128);
            Debug.WriteLine("binary GCD(2, 4, 8, 16, 32, 64, 128) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetBinaryGCD_FiveOfTenNumbersAreNegative_NotNullGCD()
        {
            int arrangeGCD = 2;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(out elapsedTime, 2, -4, 8, -16, 32, -64, 128, -256, 512, -1024);
            Debug.WriteLine("binary GCD( 2, -4, 8, -16, 32, -64, 128, -256, 512, -1024) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        public void GetBinaryGCD_TenSameNegativeNumbers_NotNullGCD()
        {
            int arrangeGCD = 13;
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(out elapsedTime, -13, -13, -13, -13, -13, -13, -13, -13, -13, -13);
            Debug.WriteLine("binary GCD(-13, -13, -13, -13, -13, -13, -13, -13, -13, -13) = {0}, algorithm took {1}", actGCD, elapsedTime);
            Assert.AreEqual(arrangeGCD, actGCD);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBinaryGCD_FiveNullNumbers_ArgumentException()
        {
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(out elapsedTime, 0, 0, 0, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBinaryGCD_NoNumbersGiven_ArgumentException()
        {
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(out elapsedTime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBinaryGCD_OnlyOneNumberGiven_ArgumentException()
        {
            string elapsedTime;
            int actGCD = GCDCalculator.GetGCDWithBinaryAlgorithm(out elapsedTime, -5);
        }
        #endregion
    }
}
