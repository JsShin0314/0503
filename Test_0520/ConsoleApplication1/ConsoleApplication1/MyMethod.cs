using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum ConvertType
    {
        For,
        DoWhile,
        While
    };
    class MyMethod
    {
        public int GetNumber()
        {
            return int.Parse(Console.ReadLine());
        }

        public void WriteLine(string Type, string Result)
        {
            Console.WriteLine(string.Format("{0} : {1}", Type, Result));
        }

        public string Converter(int nNumber, int j)
        {
            string str = string.Empty;
            str = Convert.ToString(nNumber, j);

            return str;
        }

        public string ConverterFor(int nNumber, int j)
        {
            string str = string.Empty;
            int mok = nNumber;
            string na = string.Empty;
            for (mok = nNumber; mok > 0; )
            {
                na = (mok % j) + na;
                mok = mok / j;
            }

            WriteLine(ConvertType.For.ToString(), na);
            return str;
        }

        public string ConverterDoWhile(int nNumber, int j)
        {
            string str = string.Empty;
            int mok = nNumber;
            string na = string.Empty;
            do
            {
                if (mok > 0)
                {
                    na = (mok % j).ToString() + na;
                    mok = mok / j;
                }
                else
                    break;
            } while (true);
            WriteLine(ConvertType.DoWhile.ToString(), na);
            return str;
        }

        public string ConverterWhile(int nNumber, int j)
        {
            string str = string.Empty;
            int mok = nNumber;
            string na = string.Empty;
            while (true)
            {
                if (mok > 0)
                {
                    na = (mok % j) + na;
                    mok = mok / j;
                }
                else break;
            }
            WriteLine(ConvertType.While.ToString(), na);
            return str;
        }
    }
}
