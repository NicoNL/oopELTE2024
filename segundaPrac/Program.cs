using System;
using TextFile;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static bool readFile(out List<int> lst, in String fileName)
        {
            lst = new List<int>();
            TextFileReader f = new TextFileReader(fileName);
            try{
                while(f.ReadInt(out int n)){
                    lst.Add(n);
                }

            } catch(FileNotFoundException e)
            {
                return false;

            }
            return true;

        }
        static bool condMaxSearch(in List<int> lst, out int max,out int indx)
        {
            bool l = false;
            max = 0;
            indx = 0;
            for(int i = 1; i < lst.Count()-1;i++)
            {
                if(l && lst[i-1] >= lst[i] && lst[i] <= lst[i+1])
                {
                    if(max < lst[i]){
                        max = lst[i];
                        indx = i;
                    }
                    
                }
                else if(!l && lst[i-1] >= lst[i]&& lst[i] <= lst[i+1])
                {
                    max = lst[i];
                    indx = i;
                    l = true;
                }
                
            }
            return l;
        }
        static bool condMaxSearchFromFile(in String fileName, out int max) {
            max = 0;
            try {
                TextFileReader f = new TextFileReader(fileName);
                bool l = false;
                int before;
                int current;
                int after;
                f.ReadInt(out before);
                f.ReadInt(out current);
                f.ReadInt(out after);
                while (f.ReadInt(out after)) {
                    if (l && current <= before && current <= after) {
                        if (max < current) {
                            max = current;
                        }
                    }
                    else if (!l && current <= before && current <= after) {
                        l = true;
                        max = current;
                    }
                    before = current;
                    current = after;
                }
                return l;
            } catch {
                return false;
            }
        }
        public static void Main(String[] args)
        {
            List <int> lst = new List<int>();
            String fileName = "C:/Users/huipe/Documents/ELTE_SEMESTER/3/OOP/Practice/segundaPrac/in.txt";
            if(readFile(out lst,fileName))
            {
                int max;
                int indx;
                if(condMaxSearch(in lst, out max, out indx))
                {
                    Console.Write("The highest Valley is at index: " + indx + " and is: " + max);
                }
                else{
                    Console.Write("File Empty!");
                }
            }
            else{
                Console.WriteLine("Something went wrong while reading the file");
            }
        }
    }
}