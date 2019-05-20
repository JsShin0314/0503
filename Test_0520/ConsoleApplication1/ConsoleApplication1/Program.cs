using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMethod mymethod = new MyMethod();
            Console.WriteLine("숫자를 입력하세요");
            int nNumber = mymethod.GetNumber();
            Console.WriteLine("변환할 진수를 입력하세요");
            int nJinsu = mymethod.GetNumber();
            //mymethod.Converter(nNumber, nJinsu);
            mymethod.ConverterFor(nNumber, nJinsu);
            mymethod.ConverterWhile(nNumber, nJinsu);
            mymethod.ConverterDoWhile(nNumber, nJinsu);
        }
    }
}
