using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH2
{
    internal class TH2Main
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Bai 1");
            Console.WriteLine("2. Bai 2");
            Console.WriteLine("3. Bai 3");
            Console.Write("Chon bai: ");
            int n = Convert.ToInt32(Console.ReadLine());
            switch(n)
            {
                case 1:
                    B1.Bai1();
                    break;
                case 2:
                    B2.Bai2();
                    break;
                case 3:
                    B3.Bai3();
                    break;
                default:
                    Console.WriteLine("Khong co bai nay");
                    break;
            }
        }
    }
}
