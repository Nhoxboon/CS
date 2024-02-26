using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH2
{
    internal class B3
    {
        public static void Bai3()
        {
            Console.Write("Nhap so nguyen duong < 100000: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("a) In ra màn hình tất cả các số chính phương nhỏ hơn số vừa nhập");
            for (int i = 1; i < n; i++)
            {
                if (Math.Sqrt(i) == (int)Math.Sqrt(i))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine("\nb) In ra màn hình tất cả các số nguyên tố nhỏ hơn số vừa nhập");
            for (int i = 2; i < n; i++)
            {
                bool check = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine("\nc) Tìm và in ra màn hình tất cả các số đối xứng nhỏ hơn số vừa nhập(số đối xứng là số có dạng abcba)");
            for (int i = 1; i < n; i++)
            {
                if (i < 10)
                {
                    Console.Write(i + " ");
                }
                else if (i < 100)
                {
                    if (i % 10 == i / 10)
                    {
                        Console.Write(i + " ");
                    }
                }
                else if (i < 1000)
                {
                    if (i % 10 == i / 100)
                    {
                        Console.Write(i + " ");
                    }
                }
                else if (i < 10000)
                {
                    if (i % 10 == i / 1000 && (i / 10) % 10 == (i / 100) % 10)
                    {
                        Console.Write(i + " ");
                    }
                }
                else if (i < 100000)
                {
                    if (i % 10 == i / 10000 && (i / 10) % 10 == (i / 1000) % 10)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            Console.WriteLine("\nd) Tìm và in ra màn hình tất cả các số Amstrong nhỏ hơn số vừa nhập(Một số nguyên dương N có k chữ số được gọi là số amstrong, nếu nó bằng tổng các lũy thừa bậc k của nó.VD: abc = a3 + b3 + c3)");
            for (int i = 1; i < n; i++)
            {
                int sum = 0;
                int temp = i;
                int count = 0;
                while (temp > 0)
                {
                    temp /= 10;
                    count++;
                }
                temp = i;
                while (temp > 0)
                {
                    sum += (int)Math.Pow(temp % 10, count);
                    temp /= 10;
                }
                if (sum == i)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine("\ne) In ra màn hình tất cả các số hoàn chỉnh nhỏ hơn số vừa nhập(số hoàn chỉnh là số có tổng các ước nguyên dương của nó bằng chính nó)");
            for (int i = 1; i < n; i++)
            {
                int sum = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        sum += j;
                    }
                }
                if (sum == i)
                {
                    Console.Write(i + " ");
                }
            }

        }
    }
}
