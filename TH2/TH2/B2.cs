using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH2
{
    internal class B2
    {
        public static void Bai2()
        {
            Console.WriteLine("Nhap 3 so nguyen: ");
            Console.Write("Ngay: ");
            int ngay = Convert.ToInt32(Console.ReadLine());
            Console.Write("Thang: ");
            int thang = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nam: ");
            int nam = Convert.ToInt32(Console.ReadLine());
            if(nam > 0)
            {
                if((thang == 1 || thang == 3 || thang == 5 || thang == 7 || thang == 8 || thang == 10 || thang == 12) && (ngay >= 1 && ngay <= 31))
                {
                    Console.WriteLine("Ngay " + ngay + " / " + thang + " / " + nam + " la ngay hop le");
                    if(ngay == 31)
                    {
                        if(thang == 12)
                        {
                            Console.WriteLine("Ngay tiep theo la: 1 / 1 / " + (nam + 1));
                        }
                        else
                        {
                            Console.WriteLine("Ngay tiep theo la: 1 / " + (thang + 1) + " / " + nam);
                        }
                        
                    }
                }
                else if((thang == 4 || thang == 6 || thang == 9 || thang == 11) && (ngay >= 1 && ngay <= 30))
                {
                    Console.WriteLine("Ngay " + ngay + " / " + thang + " / " + nam + " la ngay hop le");
                    if(ngay == 30)
                    {
                        Console.WriteLine("Ngay tiep theo la: 1 / " + (thang + 1) + " / " + nam);
                    }
                }
                else if(thang == 2)
                {
                    if((nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0)
                    {
                        if(ngay >= 1 && ngay <= 29)
                        {
                            Console.WriteLine("Ngay " + ngay + " / " + thang + " / " + nam + " la ngay hop le");
                            if(ngay == 29)
                            {
                                Console.WriteLine("Ngay tiep theo la: 1 / " + (thang + 1) + " / " + nam);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ngay " + ngay + " / " + thang + " / " + nam + " la ngay khong hop le");
                        }
                    }
                    else
                    {
                        if(ngay >= 1 && ngay <= 28)
                        {
                            Console.WriteLine("Ngay " + ngay + " / " + thang + " / " + nam + " la ngay hop le");
                            if(ngay == 28)
                            {
                                Console.WriteLine("Ngay tiep theo la: 1 / " + (thang + 1) + " / " + nam);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ngay " + ngay + " / " + thang + " / " + nam + " la ngay khong hop le");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ngay " + ngay + " / " + thang + " / " + nam + " la ngay thang khong hop le");
                }
            }
            else
            {
                Console.WriteLine("Nam khong hop le");
            }
        }
    }
}
