using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH2._1
{
    internal class B1
    {
        class Pho
        {
            double thit;
            double banhPho;
            double hanh;
            static int count = 0;

            public Pho(int count, double thit, double banhPho, double hanh)
            {
                this.thit = thit;
                this.banhPho = banhPho;
                this.hanh = hanh;
            }
            public Pho() { }

            public void Input()
            {
                Console.Write("Luong thit = ");
                thit = Convert.ToDouble(Console.ReadLine());
                Console.Write("Luong banh pho = ");
                banhPho = Convert.ToDouble(Console.ReadLine());
                Console.Write("Luong hanh = ");
                hanh = Convert.ToDouble(Console.ReadLine());
                
            }

            public void Output() 
            {
                Console.WriteLine((count++) + "     " + thit + "    " + banhPho + "     " + hanh + "    " + tinhTien());
            }

            public double tinhTien()
            {
                return thit * 15000 + banhPho * 10000 + hanh * 2000;
            }
        }

        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.WriteLine("So bat pho: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n <= 0 || n > 10);
            
            Pho[] pho = new Pho[n];
            for(int i = 0; i < n; i++) 
            {
                pho[i] = new Pho();
                Console.WriteLine("Nhap du lieu cho bat pho thu " + (i+1));
                pho[i].Input();
            }
            Console.WriteLine("Thong tin " + n + " bat pho vua nhap la:");
            Console.WriteLine("STT      Thit    BanhPho     Hanh    ThanhTien");
            for(int i = 0; i < n; i++)
            {
                pho[i].Output();
            }
            Pho phoMax = new Pho();
            int flag = 0;
            int flag1 = 0;
            for(int i = 1; i < n;i++) 
            {
                if (pho[i - 1].tinhTien() < pho[i].tinhTien()) 
                {
                    phoMax = pho[i];
                    flag = i + 1;
                }
            }
            Console.WriteLine("Bat pho thu " + flag + " co gia cao nhat la " + phoMax.tinhTien());
            Pho phoMin = new Pho();
            for(int i = 1; i < n; i++)
            {
                if (pho[i - 1].tinhTien() < pho[i].tinhTien())
                {
                    phoMin = pho[i - 1];
                    flag1 = i;
                }
            }
            Console.WriteLine("Bat pho thu " + flag1 + " co gia thap nhat la " + phoMin.tinhTien());
        }
    }
}
