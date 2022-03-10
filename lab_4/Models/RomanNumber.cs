using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab_4.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        private ushort value;
        private string romanVal;
        private string EROR = "Число вышло за границы (0 - 3,999)";

        public string Conversion_to_Roman(ushort n)
        {
            if (n < 0 || n > 3999)
                return EROR;

            if (n == 0) return "N";

            ushort[] values = new ushort[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] num = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };


            StringBuilder result = new StringBuilder();


            for (int i = 0; i < 13; i++)
            {
                while (n >= values[i])
                {
                    n -= values[i];
                    result.Append(num[i]);
                }
            }

            return result.ToString();
        }

        public RomanNumber(ushort n)
        {
            if (!(n > 0))
                throw new RomanNumberException();
            value = n;
            romanVal = Conversion_to_Roman(n);
        }

        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new ArgumentNullException();
            return new RomanNumber((ushort)(n1.value + n2.value));
        }

        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new ArgumentNullException();
            if (n1.value <= n2.value)
                throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.value - n2.value));
        }

        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new ArgumentNullException();
            return new RomanNumber((ushort)(n1.value * n2.value));
        }

        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new ArgumentNullException();
            if (n2.value == 0 || ((ushort)(n1.value / n2.value)) == 0)
                throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.value / n2.value));
        }

        public override string ToString()
        {
            return romanVal;
        }

        public object Clone()
        {
            return new RomanNumber(value);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;
            RomanNumber another = obj as RomanNumber;
            if (another == null)
                throw new ArgumentException("Объект не является римским числом");
            return value.CompareTo(another.value);
        }
    }

}