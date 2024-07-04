import IntegerBag
import os


class menu:
    def __init__(self):
        self.__bag = IntegerBag.IntegerBag()

    def printMenu(self):
        print(
            """
Hello Welcome to the Integer Bag Program, please enter an option:

1) Add an element to the Bag
2) Remove an element from the Bag
3) Get frequency of an element from the Bag 
4) Get the most frequent element from the bag
5) Print the elements of the Bag

Enter 'exit' to leave the program""") 

    def pressContinue(self):
        input("Press Enter to continue:\n")
        os.system('clear')

    def Run(self):
        option = None
        while True:
            self.printMenu()
            option = input("Please enter a number:\n")
            try:
                option = int(option)
            except ValueError:
                if option == "exit":
                    os.system('clear')
                    print("See you next time!")
                    break
                else:
                    os.system('clear')
                    print("Please enter a number")
                    option = -1
                    self.pressContinue()
            os.system('clear')
            match option:
                case 1:
                    self.__Add() 
                case 2:
                    self.__Remove()
                case 3:
                    self.__Frequency()
                case 4:
                    self.__MostFrequent()
                case 5:
                    self.__Print()  
                case _:
                    if option != -1:
                        print("Please enter a valid number")
                        self.pressContinue()

    def __Add(self):
        while True:
            try:
                sucess = True
                element =int(input("Please enter a number to add to the Bag:\n"))
                self.__bag.Insert(element)
            except ValueError:
                os.system('clear')
                print("Please enter a number")
                sucess = False
                self.pressContinue()
            except Exception as e:
                os.system('clear')
                print(str(e))
                sucess = False
                self.pressContinue()
            if sucess:
                print(f"The number {element} was added to the bag successfully")
                self.pressContinue()
                break

    def __Remove(self):
            if self.__bag.Length() == 0:
                print(f"The bag is empty, please enter a number to the bag first!")
                self.pressContinue()
            else:
                while True:
                    try:
                        sucess = True
                        print(f"This is the bag {self.__bag}")
                        element = int(input("Please enter a number to add to the Bag:\n"))
                        self.__bag.Remove(element)
                    except ValueError:
                        os.system('clear')
                        print("Please enter a number")
                        sucess = False
                        self.pressContinue()
                    except IntegerBag.ElementNotInBagException:
                        os.system('clear')
                        print("This number is not in the bag, please enter a number from the bag")
                        sucess = False
                        self.pressContinue()
                    except Exception as e:
                        os.system('clear')
                        print(str(e))
                        sucess = False
                        self.pressContinue()
                    if sucess:
                        print(f"The number {element} was removed to the bag successfully")
                        self.pressContinue()
                        break
                    
    def __Frequency(self):
        if self.__bag.Length() == 0:
            print("The bag is empty, please enter a number to the bag first!")
            self.pressContinue()
        else:
            while True:
                try:
                    sucess = True
                    print(f"This is the bag {self.__bag}")
                    element =  int(input("Please enter a number to obtain the frequency:\n"))
                    freq = self.__bag.GetFrequency(element)
                except ValueError:
                    os.system('clear')
                    print("Please enter a number")
                    sucess = False
                    self.pressContinue()
                except IntegerBag.ElementNotInBagException:
                    os.system('clear')
                    print("This number is not in the bag, please enter a number from the bag")
                    sucess = False
                    self.pressContinue()
                except Exception as e:
                    os.system('clear')
                    print(str(e))
                    sucess = False
                    self.pressContinue()
                if sucess:
                    print(f"The number {element} has a frequency of {freq}")
                    self.pressContinue()
                    break

    def __MostFrequent(self):
        if self.__bag.Length() == 0:
            print("The bag is empty, please enter a number to the bag first!")
            self.pressContinue()
        else:
            return self.__bag.GetMax()

    def __Print(self):
            print(f"This is your bag:\n{self.__bag}")
