using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class Bag
{
    public class NegativeSizeException : Exception { }
    public class EmptyBagException : Exception { }
    public class IllegalElementException : Exception { }

    private int[] vec;
    private int max;

    public Bag(int m)
    {
        if (m < 0) throw new NegativeSizeException();
        vec = new int[m + 1];
        foreach (int i in vec) vec[i] = 0;
        max = 0;
    }
    public void Erase()
    {
        foreach (int i in vec) vec[i] = 0;
        max = 0;

    }
    public void PutIn(int e)
    {
        if (e < 0 || e >= vec.Length) throw new IllegalElementException();
        if (++vec[e] > vec[max]) max = e;

    }
    public int MostFrequent()
    {
        if (0 == vec[max]) throw new EmptyBagException();
        return max;

    }
}
