using System;

namespace PriorityQueue
{
    public class Item
    {
        public int priorityValue;
        public string? data;

        public Item() { }
        public Item(int pr, string str)
        {
            priorityValue = pr;
            data = str;
        }

        public override string ToString()
        {
            return "("+priorityValue.ToString()+", "+data+")";
        }

        public void Read()
        {
            Console.WriteLine("Data: ");
            data = Console.ReadLine();
            Console.WriteLine("Priority: ");
            string? input = Console.ReadLine();
            if (input != null)
            {
                priorityValue = int.Parse(input);
            }
            else
            {
                priorityValue = -1;
            }
        }
    }

    public class PrQueue
    {
        // private readonly List<Item> sequence;  
        private readonly List<Item> sequence = new List<Item>();
        public class PrQueueEmpty : Exception{}

        // public PrQueue() { sequence = new List<Item>(); }
        public PrQueue() { }
        

        public void Add(Item a)
        {
            sequence.Add(a);
        }

        public Item RemMax() 
        {
            if (sequence.Count == 0) throw new PrQueueEmpty();
            int ind = MaxIndex();
            Item best = sequence[ind];
            sequence.RemoveAt(ind); // List Function
            return best;
        }

        public Item GetMax()   
        {
            if (sequence.Count == 0) throw new PrQueueEmpty();
            int ind = MaxIndex();
            return sequence[ind];
        }

        public bool IsEmpty()  
        { 
            return sequence.Count == 0; 
        }

        public int GetLength() { return sequence.Count;}

        public void Write()
        {
            foreach(Item e in sequence)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private int MaxIndex() 
        {
            int ind = 0;
            int maxkey = sequence[0].priorityValue;
            for ( int i = 1; i < sequence.Count; ++i)
            {
                if (sequence[i].priorityValue > maxkey)
                {
                    ind = i;
                    maxkey = sequence[i].priorityValue;
                }
            }
            return ind;
        }
    }
}
