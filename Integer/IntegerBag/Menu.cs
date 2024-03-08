using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integer
{
    public class Menu
    {
        private List<IntegerSet> intSetList = new List<IntegerSet>();
        public Menu() { }

        public void Run()
        {
            int n=0;
            do
            {
                PrintMenu();
                try
                {
                    n = int.Parse(Console.ReadLine());
                }
                catch(System.FormatException) { n = -1; }
                switch (n)
                {
                    case 1:
                        Console.WriteLine("sexo");
                        break;
                    case 2:
                        Console.WriteLine("poop");
                        break;
                    default:
                        Console.WriteLine("Please Enter a valid number");
                        break;
                }
            } while (n != 0);
        }

        static private void PrintMenu()
        {
            Console.WriteLine("\n\n 0. - Quit");
            Console.WriteLine(" 1. - Get an element");
            Console.WriteLine(" 2. - Overwrite an element");
            Console.WriteLine(" 3. - Print a matrix");
            Console.WriteLine(" 4. - Set a matrix");
            Console.WriteLine(" 5. - Add matrices");
            Console.WriteLine(" 6. - Multiply matrices");
            Console.Write(" Choose: ");
        }

    }
}
