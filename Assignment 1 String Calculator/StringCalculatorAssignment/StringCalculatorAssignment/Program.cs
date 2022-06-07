using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StringCalculatorAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int c;
            //string str = "53653";
            //Console.WriteLine(str.Length);
            StringCalculator sc = new StringCalculator();
            sc.Add_EmptyString_ReturnsZero();
            sc.Add_OneNumber_ReturnsNumber();
            sc.Add_TwoNumbersSeperatedbyComa_ReturnsSum();
            sc.Add_TwoNumbersSeperatedbyNewLineandComa_ReturnsSum();
            sc.Add_TwoNumbersSeperatedbyDifferentDelimiters_ReturnsSum();
            sc.Add_LessThanZeroSingleNumber_ThrowsException();
            sc.Add_LessThanZeroMultipleNumbers_Delimiters_ThrowsException();
            //// String math = "100 * 5 - 2";
            //string math; //= "100 * 5 - 2";
            //math = Console.ReadLine();
            //string value = new DataTable().Compute(math, null).ToString();
            //Console.WriteLine(value);

        }
    }

    public class StringCalculator
    {
        public void Add_EmptyString_ReturnsZero()
        {
            var result = Calculator.Add1("");
            if (result == 0)
            {
                Console.WriteLine("The String passed is Empty.");
            }
        }

        public void Add_OneNumber_ReturnsNumber()
        {
            var result = Calculator.Add2("1");
            Console.WriteLine("The String passed is a single number string with value : {0}", result);
        }

        public void Add_TwoNumbersSeperatedbyComa_ReturnsSum()
        {
            var result = Calculator.Add2("1,2");
            Console.WriteLine("The Sum of two or more integers in the string seperated by ',' is : {0}", result);
        }

        public void Add_TwoNumbersSeperatedbyNewLineandComa_ReturnsSum()
        {
            var result = Calculator.Add2("1\n2");
            Console.WriteLine("The Sum of all the integers in a string seperated by NewLine delimiter is : {0}", result);
        }

        public void Add_TwoNumbersSeperatedbyDifferentDelimiters_ReturnsSum()
        {
            var result = Calculator.Add2("//;:1;1|2");
            Console.WriteLine("The Sum of all the integers in a string seperated by Different Delimiter is : {0}", result);
        }

        public void Add_LessThanZeroSingleNumber_ThrowsException()
        {
            string s = "-1";
            var result = Calculator.Add3(s);
            if (result == 0)
            {
                Console.WriteLine("The Number entered is negative : {0}", int.Parse(s));
            }
        }

        public void Add_LessThanZeroMultipleNumbers_Delimiters_ThrowsException()
        {
            string s = "1,2,9";
            var result = Calculator.Add4(s);
            if (result == 0)
            {
                Console.WriteLine("There are Number entered is in the string that are negative");
            }
        }
    }

    public static class Calculator
    {
        public static int Add1(string value)
        {
            if (value == "")
            {
                return 0;
            }
            return int.Parse(value);
        }
        //public static int Add2(string value)
        //{
        //    return int.Parse(value);
        //}

        public static int Add2(string value)
        {
            var sum = 0;
            var delimiter = new List<char> { ',', '/', '\n', '|', ';', ' ', ':' };
            if (value.StartsWith("//"))
            {
                delimiter.Add(value[2]);
                value = value.Substring(4);
            }
            Array.ForEach(value.Split(delimiter.ToArray()), s => sum += int.Parse(s));
            return sum;
        }

        public static int Add3(string value)
        {
            int a = int.Parse(value);
            if(a < 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static int Add4(string value)
        {
            int j = -1;
            var delimiter = new List<char> { ',', '/', '\n', '|', ';', ' ', ':' };
            int[] ar = new int[10];
            Array.ForEach(value.Split(delimiter.ToArray()), s => ar[j = j + 1] = int.Parse(s));
            for (int i = 0; i < ar.Length; i++)
            {
                if(ar[i] < 0)
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
