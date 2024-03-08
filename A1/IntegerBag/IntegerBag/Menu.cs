using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IntegerBag
{
    public class Menu
    {
        #region  Attributes
        private IntegerBag bag = new IntegerBag();
        #endregion

        #region Constructors
        public Menu() { }
        #endregion

        #region Methods
        public void Run()
        {
            int n = 0;
            do
            {
                PrintMenu();
                try
                {
                    n = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.Clear();
                    n = -1;
                    Console.WriteLine("Please enter a valid input!!");
                    enterToContinue();
                }
                switch (n)
                {
                    case 0:
                        break;
                    case 1:
                        addElement();
                        break;
                    case 2:
                        removeElement();
                        break;
                    case 3:
                        getFrequency();
                        break;
                    case 4:
                        mostFrequent();
                        break;
                    case 5:
                        printBag();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a number between 1 and 5:");
                        enterToContinue();
                        break;
                }
            } while (n != 0);
            Console.Clear();
            Console.WriteLine("Thanks for using IntegerBag");
            
        }

        static private void PrintMenu()
        {
            Console.WriteLine("Welcome to IntegerBag");
            Console.WriteLine("Please feel free to use these operations with your bag");
            Console.WriteLine("\n\n 0. - Quit the Program");
            Console.WriteLine(" 1. - Add an element to the Bag");
            Console.WriteLine(" 2. - Remove an element from the Bag");
            Console.WriteLine(" 3. - Get the frequency of an element");
            Console.WriteLine(" 4. - Get the most frequent element of the Bag");
            Console.WriteLine(" 5. - Print your current Bag");
            Console.Write("\nPlease write a number to Start: ");
        }
        private void addElement()
        {
            Console.Clear();
            int element = 0;
            bool success;
            do
            {
                success = false;
                Console.WriteLine("Please write an Integer: ");
                try
                {
                    element = int.Parse(Console.ReadLine());
                    bag.insertInt(element);
                    success = true;
                }
                catch (System.FormatException)
                {
                    Console.Clear();
                    success = false;
                    Console.WriteLine("Please enter a valid Integer!!");
                }

            } while (!success);
            Console.WriteLine("Element {0} was added to the Bag", element);
            enterToContinue();
        }
        private void removeElement()
        {
            Console.Clear();
            if (bag.isEmpty())
            {
                Console.WriteLine("This Bag has no elements yet");
                enterToContinue();
                return;
            }
            int element = 0;
            bool success;
            do
            {
                success = false;
                Console.WriteLine("Please write an element you would like to remove from the Bag");
                try
                {
                    element = int.Parse(Console.ReadLine());
                    bag.removeInt(element);
                    success = true;
                }
                catch (System.FormatException)
                {
                    Console.Clear();
                    success = false;
                    Console.WriteLine("Please enter a valid Integer!!");
                    enterToContinue();
                }
                catch (IntegerBag.NonExistingElementException)
                {
                    Console.Clear();
                    success = false;
                    Console.WriteLine("This element does not exist in this Bag");
                    enterToContinue();
                }
            } while (!success);
            if (success)
            {
                Console.WriteLine("Element {0} was removed to the Bag", element);
            }
            enterToContinue();
        }
        private void getFrequency() 
        {
            Console.Clear();
            if (bag.isEmpty())
            {
                Console.WriteLine("This Bag has no elements yet");
                enterToContinue();
                return;
            }
            int element = 0;
            int frequency = 0;
            bool success;
            do
            {
                success = false;
                Console.WriteLine("Please write an element to get its frequency");
                try
                {
                    element = int.Parse(Console.ReadLine());
                    frequency = bag.frequencyOf(element);
                    success = true;
                }
                catch (System.FormatException)
                {
                    Console.Clear();
                    success = false;
                    Console.WriteLine("Please enter a valid Integer!!");
                    enterToContinue();
                }
                catch (IntegerBag.NonExistingElementException)
                {
                    Console.Clear();
                    success = false;
                    Console.WriteLine("This element does not exist in this Bag");
                    enterToContinue();
                }
            } while (!success);
            if (success)
            {
                Console.WriteLine("Element {0} frequency is {1}", element, frequency);
            }
            enterToContinue();
        }
        private void mostFrequent()
        {
            Console.Clear();
            int maxIndex = 0;
            int element = 0;
            int frequency = 0;
            bool success;
            do
            {
                try
                {
                    maxIndex = bag.mostFrequent(out element, out frequency);
                    success = true;
                }
                catch (System.FormatException)
                {
                    Console.Clear();
                    success = false;
                    Console.WriteLine("Please enter a valid Integer!!");
                    enterToContinue();
                }
                catch (IntegerBag.NonExistingElementException)
                {
                    Console.Clear();
                    success = false;
                    Console.WriteLine("This element does not exist in this Bag");
                    enterToContinue();
                }
                catch (IntegerBag.EmptyBagException)
                {
                    Console.Clear();
                    success = false;
                    Console.WriteLine("This Bag has no elements yet");
                    break;
                }

            } while (!success);
            if (success)
            {
                Console.WriteLine("Element {0} is the most frequent element, its frequency is {1}", element, frequency);
            }
            enterToContinue();
        }
        private void printBag()
        {
            Console.Clear();
            Console.WriteLine("The bag structure is: [ (element, frequency)]");
            Console.WriteLine("This is your Bag: ");
            Console.WriteLine(bag.ToString());
            enterToContinue();
        }
        #endregion

        #region Complementary Methods
        static private void enterToContinue()
        {
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        #endregion
    }
}
