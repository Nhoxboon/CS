using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class FileMain
    {
        static void Main(string[] args) 
        {
            int a = 5; int b = 6;
            short c = 10;
            Buoi5 test = new Buoi5();
            //test.HoanVi(out a, out b);
            Console.WriteLine(a + " " + b);
            test.PTin(c);
            test.PTin(a);
            test.PTin(15);
            Console.ReadKey();
        }
    }
}
