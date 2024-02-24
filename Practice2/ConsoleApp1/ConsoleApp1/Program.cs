using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace CircleExists
{
    class Program
    {
        static void Main(string[] args) 
        {
            try
            {
                double a;
                double b;
                double c;
                TextFileReader tf = new TextFileReader("input.txt");
                tf.ReadDouble(out a);
                tf.ReadDouble(out b);
                tf.ReadDouble(out c);
                Circle ourCircle = new Circle(new Point(a, b), c);
                int n;
                tf.ReadInt(out n);
                Point[] x = new Point[n];

                for (int i = 0; i < n; i++)
                {
                    double tmp1;
                    double tmp2;
                    tf.ReadDouble(out tmp1);
                    tf.ReadDouble(out tmp2);
                    x[i] = new Point(tmp1, tmp2);
                }
                bool l = false;
                for (int i = 0; i < x.Length; i++)
                {
                    l = ourCircle.Contains(x[i]);

                }
                if (l)
                {
                    Console.WriteLine("Yes, there's a point inside the circle");
                }
                else
                {
                    Console.WriteLine("No point was found inside the circle");
                }

            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("No file was found");

            }
            catch (NegativeRadius)
            {
                Console.WriteLine("Radius wrong");

            }
        }
    }
}
