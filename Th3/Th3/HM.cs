using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Th3
{
    internal class HM
    {
        static void Main(string[] args)
        {
            int choice;
            List<CD> cdList = new List<CD>();
            do
            {
                Console.WriteLine("1. Add CD");
                Console.WriteLine("2. Search CD");
                Console.WriteLine("3. Display CD");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CD cd = new CD();
                        cd.AddCD();
                        cdList.Add(cd);
                        break;
                    case 2:
                        Console.WriteLine("Nhap ten CD: ");
                        string name = Console.ReadLine();
                        for(int i = 0; i < cdList.Count; i++)
                        {
                            cdList[i].SearchCD(name);
                        }                        
                        break;
                    case 3:
                        Console.WriteLine("CD No. \t CD Name \t CD Type \t CD Price");
                        for(int i = 0; i < cdList.Count; i++)
                        {
                            cdList[i].DisplayCatalog();
                        }
                        
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Lua chon sai");
                        break;
                }
               
            }while(choice != 4);

        }
    }
}
