using System;
using TextFile;

namespace HobbyAnimals;

class Program
{
    public static void Main(string[] args)
    {
        bool fileError = true;
        do
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Please enter a file name: ");
                string fileName = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("The animals are print in the following notation: Type Name Exhilaration (e.g T Spidy 42)");
                Console.WriteLine("The existing types are : T = Tarantula, H = Hamster,  C = cat");
                Console.WriteLine("-------------------------------------------------------------------------------------------\n");
                Reader r = new(fileName);
                int i = 1;
                for (r.First(); !r.End(); r.Next())
                {
                    if (r.Current().Contains(','))
                    {
                        Console.WriteLine("The animals with the biggest exhilaration in the day " + i + " were: " + r.Current());
                    }
                    else
                    {
                        Console.WriteLine("The animal with the biggest exhilaration in the day " + i + " was: " + r.Current());
                    }
                    i++;
                }
                fileError = false;

            }
            catch (System.IO.FileNotFoundException)
            {
                Console.Clear();
                Console.WriteLine("The given file was not found, please press any key to continue: ");
                Console.ReadKey();
            }
            //If the file contains an invalid char for the animal type
            catch (Reader.FileFormatException)
            {
                Console.Clear();
                Console.WriteLine("One of the given animals in the file contains not valid information");
                Console.WriteLine("Press any key to continue: ");
                Console.ReadKey();
            }
        } while (fileError);

    }
}