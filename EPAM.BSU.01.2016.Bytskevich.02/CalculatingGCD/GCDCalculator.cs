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
            return RunCalculationWithChecks(firstNumber, secondNumber, out elapsedTime, GetGCDOfTwoNumbers);
        }

        public static int GetGCD(int firstNumber, int secondNumber, int thirdNumber, out string elapsedTime)
        {
            return RunCalculationWithChecks(firstNumber, secondNumber, thirdNumber, out elapsedTime, GetGCDOfTwoNumbers);
        }

        public static int GetGCD(out string elapsedTime, params int[] numbers)
        {
            return RunCalculationWithChecks(out elapsedTime, numbers, GetGCDOfTwoNumbers);
        }

        public static int GetGCDWithBinaryAlgorithm(int firstNumber, int secondNumber, out string elapsedTime)
        {
            return RunCalculationWithChecks(firstNumber, secondNumber, out elapsedTime, GetBinaryGCDOfTwoNumbers);
        }

        public static int GetGCDWithBinaryAlgorithm(int firstNumber, int secondNumber, int thirdNumber, out string elapsedTime)
        {
            return RunCalculationWithChecks(firstNumber, secondNumber, thirdNumber, out elapsedTime, GetBinaryGCDOfTwoNumbers);
        }

        public static int GetGCDWithBinaryAlgorithm(out string elapsedTime, params int[] numbers)
        {
            return RunCalculationWithChecks(out elapsedTime, numbers, GetBinaryGCDOfTwoNumbers);
        }

        private static int RunCalculationWithChecks(int firstNumber, int secondNumber, out string elapsedTime, Func<int, int, int> algorithm)
        {
            int result;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            result = algorithm(firstNumber, secondNumber);
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            return result;
        }

        private static int RunCalculationWithChecks(int firstNumber, int secondNumber, int thirdNumber, out string elapsedTime, Func<int, int, int> algorithm)
        {
            int result;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            if (!(firstNumber == 0 && secondNumber == 0 && thirdNumber == 0))
            {
                if (!(firstNumber == 0 && secondNumber == 0))
                {
                    int intermediateGCD = algorithm(firstNumber, secondNumber);
                    result = algorithm(intermediateGCD, thirdNumber);
                }
                else
                {
                    result = Math.Abs(thirdNumber);
                }
            }
            else
                throw new ArgumentException("At least one argument must be not null.");
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            return result;
        }

        private static int RunCalculationWithChecks(out string elapsedTime,  int[] numbers, Func<int, int, int> algorithm)
        {
            elapsedTime = "00:00:00:00";
            int numOfNullArguments = 0;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            if (numbers.Length < 2)
                throw new ArgumentException("It is necessary to give a method at least two numbers.");
            foreach (int num in numbers)
                if (num == 0)
                    numOfNullArguments++;
            if (numOfNullArguments == numbers.Length)
                throw new ArgumentException("At least one argument must be not null.");

            if (numOfNullArguments == numbers.Length - 1)
                return Math.Abs(numbers.Sum());
            int i = 1;
            int intermediateGCD;
            if (numbers[0] == 0 && numbers[1] == 0)
            {
                intermediateGCD = numbers[1];
                i = 2;
            }
            else
                intermediateGCD = numbers[0];
            for (; i < numbers.Length; i++)
            {
                intermediateGCD = algorithm(intermediateGCD, numbers[i]);
            }
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            return intermediateGCD;
        }

        private static int GetGCDOfTwoNumbers(int firstNumber, int secondNumber)
        {
            if (firstNumber == 0 && secondNumber == 0)
                throw new ArgumentException("At least one argument must be not null.");
            if (firstNumber == 0 )
                return Math.Abs(secondNumber);
            if (secondNumber == 0)
                return Math.Abs(firstNumber);
            if (firstNumber < 0)
                firstNumber = Math.Abs(firstNumber);
            if (secondNumber < 0)
                secondNumber = Math.Abs(secondNumber);
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
            if (firstNumber == 0 && secondNumber == 0)
                throw new ArgumentException("At least one argument must be not null.");
            if (firstNumber == 0)
                return secondNumber;
            else if (secondNumber == 0)
                return firstNumber;
            if (firstNumber < 0)
                firstNumber = Math.Abs(firstNumber);
            if (secondNumber < 0)
                secondNumber = Math.Abs(secondNumber);
            bool firstNumberIsEven = (firstNumber & 1u) == 0;
            bool seondNumberIsEven = (secondNumber & 1u) == 0;
            if (firstNumberIsEven && seondNumberIsEven)
                return GetBinaryGCDOfTwoNumbers(firstNumber >> 1, secondNumber >> 1) << 1;
            else if (firstNumberIsEven && !seondNumberIsEven)
                return GetBinaryGCDOfTwoNumbers(firstNumber >> 1, secondNumber);
            else if (seondNumberIsEven)
                return GetBinaryGCDOfTwoNumbers(firstNumber, secondNumber >> 1);
            else if (firstNumber > secondNumber)
                return GetBinaryGCDOfTwoNumbers((firstNumber - secondNumber) >> 1, secondNumber);
            else
                return GetBinaryGCDOfTwoNumbers(firstNumber, (secondNumber - firstNumber) >> 1);

        }

    }
}
