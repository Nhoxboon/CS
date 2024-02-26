using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH2
{
    internal class B1
    {
        public static void Bai1()
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine("**Troi choi tinh nhanh**");
                Console.WriteLine("**  +: tinh phep cong**");
                Console.WriteLine("**  -: tinh phep tru**");
                Console.WriteLine("**  *: tinh phep nhan**");
                Console.WriteLine("**  /: tinh phep chia**");
                Console.WriteLine("***********************");
                Console.WriteLine("Nhap 2 so va toan tu: ");

                Console.Write("a = ");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.Write("b = ");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Toan tu: ");
                char c = Convert.ToChar(Console.ReadLine());
                switch(c)
                {
                    case '+':
                        Console.WriteLine("a + b = " + (a + b));
                        break;
                    case '-':
                        Console.WriteLine("a - b = " + (a - b));
                        break;
                    case '*':
                        Console.WriteLine("a * b = " + (a * b));
                        break;
                    case '/':
                        if (b == 0)
                        {
                            Console.WriteLine("Khong the chia cho 0");
                        }
                        else
                        {
                            Console.WriteLine("a / b = " + (a / b));
                        }
                        break;
                    default:
                        Console.WriteLine("Toan tu khong hop le");
                        break;
                }
                Console.WriteLine("Ban co muon lam nua khong? (y/n)");
                char f = Convert.ToChar(Console.ReadLine());
                if (f == 'n' || f == 'N')
                {
                    check = false;
                    Console.WriteLine("Cam on ban da su dung chuong trinh");
                }
               
            }
            /*Console.ReadKey();*/
        }   
    }
}
