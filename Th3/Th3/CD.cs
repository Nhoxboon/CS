using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Th3
{
    internal class CD
    {
        string CDName;
        string CDType;
        double CDPrice;
        static int count = 0;
        int check;

        public CD() { }

        public CD(string CDName, string CDType, double CDPrice)
        {
            this.CDName = CDName;
            this.CDType = CDType;
            this.CDPrice = CDPrice;
        }

        public string GetSetCDName
        {
            get { return CDName; }
            set { CDName = value; }
        }

        public string GetSetCDType
        {
            get { return CDType; }
            set { CDType = value; }
        }
        public double GetCDPrice
        {
            get { return CDPrice; }
            set { CDPrice = value; }
        }

        public void AddCD()
        {
            if (count <= 1000)
            {
                Console.WriteLine("Enter CD Name: ");
                CDName = Console.ReadLine();
                Console.WriteLine("Enter CD Type: ");
                CDType = Console.ReadLine();
                Console.WriteLine("Enter CD Price: ");
                CDPrice = Convert.ToDouble(Console.ReadLine());
                count++;
                check = count;
            }
            else
            {
                Console.WriteLine("Da qua 1000 CD");
            }
        }

        public void SearchCD(string CDName)
        {
            if (this.CDName == CDName)
            {
                Console.WriteLine("CD Name: " + CDName);
                Console.WriteLine("CD Type: " + CDType);
                Console.WriteLine("CD Price: " + CDPrice);
            }
            else
            {
                Console.WriteLine("CD not found");
            }
        }

        public void DisplayCatalog()
        {
            Console.WriteLine(count + "\t" + CDName + "\t" + CDType + "\t" + (CDPrice / 1000) + "K(VND)");
        }
    }
}
