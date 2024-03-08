using System;

namespace PriorityQueue
{
    class Menu
    {
        private readonly PrQueue priorityQueue = new PrQueue();
        
        public void Run()
        {
            int value;
            do
            {
                value = GetMenuPoint();
                switch (value)
                {
                    case 1:
                        PutIn();
                        Write();
                        break;
                    case 2:
                        RemoveMax();
                        Write();
                        break;
                    case 3:
                        GetMax();
                        Write();
                        break;
                    case 4:
                        CheckEmpty();
                        Write();
                        break;
                    case 5:
                        Write();
                        break;
                    default:
                        Console.WriteLine("\nBye!");
                        break;

                }
            } while (value < 0 && value > 5);
        }

        private static int GetMenuPoint()
        {
            int value;
            Console.WriteLine("\n********************************");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add element");
            Console.WriteLine("2. RemMax");
            Console.WriteLine("3. GetMax");
            Console.WriteLine("4. IsEmpty");
            Console.WriteLine("5. Print");
            Console.WriteLine("****************************************");

            string? input = Console.ReadLine();
            if (input != null)
            {
                value = int.Parse(input);
            }
            else
            {
                value = -1;
            }
    
            return value;
        }

        private void PutIn()
        {
            Item element = new ();
            Console.WriteLine("What shall I add?");
            element.Read();
            priorityQueue.Add(element);
        }

        private void RemoveMax()
        {
            Item element;
            try
            {
                element = priorityQueue.RemMax();
                Console.WriteLine("Taken element:\n ({0}, {1})", element.priorityValue, element.data);
            }
            catch (PrQueue.PrQueueEmpty)
            {
                Console.WriteLine("Error: The queue is empty!\n");
            }
        }

        private void GetMax()
        {
            Item element;
            try
            {
                element = priorityQueue.GetMax();
                Console.WriteLine("Maximal element:\n ({0}, {1})", element.priorityValue, element.data);
            }
            catch (PrQueue.PrQueueEmpty)
            {
                Console.WriteLine("Error: The queue is empty!\n");
            }
        }

        private void CheckEmpty()
        {
            if (priorityQueue.IsEmpty())
            {
                Console.WriteLine("The queue IS empty!\n");
            }
            else
            {
                Console.WriteLine("The queue is NOT empty!\n");
            }
        }

        private void Write()
        {
            priorityQueue.Write();
        }
    }
}
