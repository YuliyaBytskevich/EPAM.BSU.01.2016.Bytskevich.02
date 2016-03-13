using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CalculatingGCD
{
    public static class GCDCalculator
    {
        public static int GetGCD(int firstNumber, int secondNumber, out string elapsedTime)
        {
            int result;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            result = GetGCDOfTwoNumbers(firstNumber, secondNumber);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            return result;
        }

        public static int GetGCD(int firstNumber, int secondNumber, int thirdNumber, out string elapsedTime)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int intermediateGCD = GetGCDOfTwoNumbers(firstNumber, secondNumber);
            int result = GetGCDOfTwoNumbers(intermediateGCD, thirdNumber);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            return result;
        }

        public static int GetGCD(out string elapsedTime, params int[] numbers)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int intermediateGCD = numbers[0];
            for (int i = 1; i< numbers.Length; i++)
            {
                intermediateGCD = GetGCDOfTwoNumbers(intermediateGCD, numbers[i]);
            }
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            return intermediateGCD;
        }

        public static int GetGCDWithBinaryAlgorithm(int firstNumber, int secondNumber, out string elapsedTime)
        {
            int result;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            result = GetBinaryGCDOfTwoNumbers(firstNumber, secondNumber);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            return result;
        }

        public static int GetGCDWithBinaryAlgorithm(int firstNumber, int secondNumber, int thirdNumber, out string elapsedTime)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int intermediateGCD = GetBinaryGCDOfTwoNumbers(firstNumber, secondNumber);
            int result = GetBinaryGCDOfTwoNumbers(intermediateGCD, thirdNumber);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            return result;
        }

        public static int GetGCDWithBinaryAlgorithm(out string elapsedTime, params int[] numbers)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int intermediateGCD = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                intermediateGCD = GetBinaryGCDOfTwoNumbers(intermediateGCD, numbers[i]);
            }
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            return intermediateGCD;
        }

        private static int GetGCDOfTwoNumbers(int firstNumber, int secondNumber)
        {
            while (firstNumber != secondNumber)
            {
                if (firstNumber > secondNumber)
                    firstNumber = firstNumber - secondNumber;
                else
                    secondNumber = secondNumber - firstNumber;
            }
            return firstNumber;
        }

        private static int GetBinaryGCDOfTwoNumbers(int firstNumber, int secondNumber)
        {
            int shift;
            if (firstNumber == 0)
                return secondNumber;
            else if (secondNumber == 0)
                return firstNumber;
            else
            {
                for (shift = 0; ((firstNumber | secondNumber) & 1) == 0; ++shift)
                {
                    firstNumber >>= 1;
                    secondNumber >>= 1;
                }
                while ((firstNumber & 1) == 0)
                    firstNumber >>= 1;
                do
                {
                    while ((secondNumber & 1) == 0) 
                        secondNumber >>= 1;
                    if (firstNumber > secondNumber)
                    {
                        int temp = firstNumber;
                        secondNumber = firstNumber;
                        firstNumber = temp;
                    }
                    secondNumber = secondNumber - firstNumber; 
                } while (secondNumber != 0);
                return firstNumber << shift;
            }           
        }

    }
}
