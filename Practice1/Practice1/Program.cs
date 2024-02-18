using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using TextFile;


namespace Practice1
{
    internal class Program
    {
        private static bool fileRead (out List<int> vec, in String fileName)
        {
            vec = new List<int> ();
            try
            {
                TextFileReader reader = new TextFileReader (fileName);
                while(reader.ReadInt (out int e))
                {
                    vec.Add (e);
                }
                return true;
            }catch (Exception ex) 
            {
                return false;
            }

        }
        private static bool condMaxSearch(in List<int> vec, out int max, out int ind)
        {
            bool l =false;
            int n = 1;
            max = 0;
            ind = 0;
            for(int i= 1; i < vec.Count-1; i++) 
            {
                if(l && vec[i] <= vec[i-1] && vec[i] <= vec[i+1])
                {
                    max = vec[i];
                    ind = i;
                }
                else if(!l && vec[i] <= vec[i-1] && vec[i] <= vec[i+1])
                {
                    l = true;
                    max = vec[i];
                    ind = i;
                }
            }
            return l;
        }
        private static bool condMaxSearchFromFile(in String fileName, out int max)
        {
            max =0;
            try
            {
                TextFileReader f = new TextFileReader(fileName);
                bool l = false;
                int n = 1;
                int before;
                int current;
                int after;
                f.ReadInt(out before);
                f.ReadInt(out current);
                f.ReadInt(out after);

                while (f.ReadInt(out after))
                {
                    if(l && current <= before && current <= after)
                    {
                        if(max < current) 
                        {
                            max = current;
                        }
                        else if(!l && current <= before && current <= after)
                        {
                            l =true;
                            max = current;
                        }
                        before = current;
                        current = after;
                    }
                }
                return l;
            }
            catch (Exception ex) 
            {
                return false;

            }
        }
        public static void Main(string[] args) 
        {
            Console.WriteLine("Filename: ");
            string FileName = Console.ReadLine();
            List<int> vec = new List<int>();
            
            if(fileRead(out vec, in FileName))
            {
                int max, ind;
                if(condMaxSearch(vec,out max, out ind))
                {
                    Console.WriteLine($"Higuest valley is  {max} high!");
                }
                else
                {
                    Console.WriteLine("There's no valley!");
                }

                if(condMaxSearchFromFile(in FileName, out max))
                {
                    Console.WriteLine($"Higuest valeey is {max} high!");

                }
                else
                {
                    Console.WriteLine($"There's no valley!");
                }
            }
            else
            {
                Console.WriteLine("Wrong file name");
            }
        }
    }
}
