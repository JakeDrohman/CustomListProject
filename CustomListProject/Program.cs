using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> customlist = new CustomList<int>();
            
            customlist.Add(9);
            customlist.Add(2);
            customlist.Add(2);
            customlist.Add(2);
            customlist.Add(17);
            customlist.Add(10);
            foreach (int item in customlist)
            {
                Console.WriteLine(item);

            }
            customlist.Remove(9);
            foreach (int item in customlist)
            {
                Console.WriteLine(item);

            }
            //Console.WriteLine(customlist.ToString());
            CustomList<int> secondlist = new CustomList<int>();
            secondlist.Add(1);
            secondlist.Add(1);
            secondlist.Add(2);
            secondlist.Add(1);
            customlist.Zipper(secondlist);
            Console.WriteLine(customlist);
            //CustomList<int> thirdlist = new CustomList<int>();
            //thirdlist = customlist - secondlist;
            //Console.WriteLine(thirdlist);
            Console.ReadKey();
        }
    }
}
