using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class BigNumber
    {
        private int[] number;

        private const int Base = 1000;

        public int ArrayLength
        {
            get { return number.Length; }
        }

        public BigNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Пустая строка");

            string digits = number.Trim();

            if (digits.Any(c => c < '0' || c > '9'))
                throw new FormatException("Допустимы только цифры");

            int[] blocks = new int[(digits.Length + 2) / 3];

            for (int i = 0; i < blocks.Length; i++)
            {
                int end = digits.Length - i * 3;
                int start = Math.Max(0, end - 3);
                blocks[i] = int.Parse(digits.Substring(start, end - start));
            }

            this.number = TrimLeadingZeros(blocks);
        }
        private BigNumber(int[] blocks)
        {
            number = TrimLeadingZeros(blocks);
        }

        public BigNumber Clone()
        {
            return new BigNumber(number);   // TrimLeadingZeros делает копию массива
        }

        //переопределение ToString() 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (i == number.Length - 1)
                    sb.Append(number[i].ToString());
                else
                    sb.Append(number[i].ToString("D3"));
            }
            sb.ToString().TrimStart('0');
            return sb.ToString();
        }

        //убираем нули
        private int[] TrimLeadingZeros(int[] arr)
        {
            int length = arr.Length;
            while (length > 1 && arr[length - 1] == 0)
                length--;

            int[] trimmed = new int[length];
            Array.Copy(arr, trimmed, length);
            return trimmed;
        }

        public int CompareTo(BigNumber other)
        {
            if (number.Length != other.number.Length)
                return number.Length.CompareTo(other.number.Length);

            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (number[i] != other.number[i])
                    return number[i].CompareTo(other.number[i]);
            }
            return 0;
        }
        
        private BigNumber Plus(BigNumber other)
        {
            int maxLength = Math.Max(number.Length, other.number.Length);

            int[] result = new int[maxLength + 1];

            int carry = 0;

            for (int i = 0; i < maxLength; i++)
            {
                int firstBlock = 0;
                int secondBlock = 0;

                if (i < number.Length)
                    firstBlock = number[i];

                if (i < other.number.Length)
                    secondBlock = other.number[i];

                int sum = firstBlock + secondBlock + carry;

                result[i] = sum % Base;

                carry = sum / Base;
            }

            if (carry > 0)
                result[maxLength] = carry;

            return new BigNumber(result.ToArray());

        }

        private BigNumber Minus(BigNumber other)
        {
            int maxLength = Math.Max(number.Length, other.number.Length);

            int[] result = new int[maxLength];

            int borrow = 0;

            for (int i = 0; i < maxLength; i++)
            {
                int firstBlock = 0;
                int secondBlock = 0;

                if (i < number.Length)
                    firstBlock = number[i];

                if (i < other.number.Length)
                    secondBlock = other.number[i];

                int diff = firstBlock - secondBlock - borrow;

                if (diff < 0)
                {
                    diff += Base;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }

                result[i] = diff;
            }
            return new BigNumber(result);
        }

        private BigNumber Division(BigNumber other)
        {
            if (other.CompareTo(new BigNumber("0")) == 0)
                throw new DivideByZeroException();

            int[] result = new int[number.Length];

            BigNumber remainder = new BigNumber("0");

            for (int i = number.Length - 1; i >= 0; i--)
            {
                string remainderString = remainder.ToString();

                string currentBlock = number[i].ToString("D3");

                remainder = new BigNumber(remainderString + currentBlock);

                int quotient = 0;

                while (remainder.CompareTo(other) >= 0)
                {
                    remainder = remainder - other;
                    quotient++;
                }

                result[i] = quotient;
            }

            return new BigNumber(result);
        }
        private BigNumber Multiplication(BigNumber other)
        {
            int[] result = new int[number.Length + other.number.Length];

            for (int i = 0; i < number.Length; i++)
            {
                int carry = 0;

                for (int j = 0; j < other.number.Length; j++)
                {
                    int current = result[i + j]+ number[i] * other.number[j]
                                 + carry;

                    result[i + j] = current % Base;
                    carry = current / Base;
                }

                if (carry > 0)
                    result[i + other.number.Length] += carry;
            }

            return new BigNumber(result);
        }
        public BigNumber Multiply(double modifier)
        {
            const int precision = 1000;
            int numerator = (int)Math.Round(modifier * precision);
            return (this * new BigNumber(numerator.ToString())
                    + new BigNumber((precision - 1).ToString()))   // округление вверх
                   / new BigNumber(precision.ToString());
        }
        //переопредление операторов
        public static BigNumber operator +(BigNumber a, BigNumber b) => a.Plus(b);
        public static BigNumber operator -(BigNumber a, BigNumber b) => a.Minus(b);
        public static BigNumber operator *(BigNumber a, BigNumber b) => a.Multiplication(b);
        public static BigNumber operator /(BigNumber a, BigNumber b) => a.Division(b);
        public static bool operator >(BigNumber a, BigNumber b) => a.CompareTo(b) > 0;
        public static bool operator <(BigNumber a, BigNumber b) => a.CompareTo(b) < 0;
    }
   
}
