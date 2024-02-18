using System;
using TextFile;

namespace Bagclass
{
    class program
    {
        public static void Main()
        {
            try
            {
                //readfile
                TextFileReader reader = new TextFileReader("in.txt");
                reader.ReadInt(out int m);

                Bag b = new Bag(m);

                while (reader.ReadInt(out int e))
                {
                    try
                    {
                        b.PutIn(e);

                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine(e + " is an invalid element");
                    }
                }
                Console.WriteLine($"most frequent element: {b.MostFrequent()}");
            }
            catch (Bag.NegativeSizeException)
            {
                Console.WriteLine("invalid size for the Bag");
            }
            catch (Bag.EmptyBagException)
            {
                Console.WriteLine("the Bag is empty");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("no file was found");
            }
        }
    }
}