using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleExists
{
    class NegativeRadius : Exception { 
    }
   

public class Circle
    {
        double radius;
        Point thePoint;
        public Circle(Point p, double r)
        {
            thePoint = p;
            if(r < 0) 
            {
                throw new NegativeRadius();
            }
            radius = r;
        }

        public bool Contains(Point p) 
        {
            double d = thePoint.distance(p);
            if(d >= Math.Pow(radius, 2)) 
            {
                return false;
            }
            return true;
        }

    }
}
