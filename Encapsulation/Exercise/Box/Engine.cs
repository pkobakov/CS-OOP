using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    public static class Engine
    {
        public static void Run() 
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);


                Console.WriteLine(box.ToString());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
    }
}
