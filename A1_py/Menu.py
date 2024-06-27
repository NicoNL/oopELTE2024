import IntegerBag
import pair
import os

class menu:

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
                    print ("See you next time!")
                    break
                else:
                    os.system('clear')
                    print("Please enter a number")
                    option = -1
                    self.pressContinue()
            match option:
                case 1:
                    print("Option 1")   
                case 2:
                    print("Option 2") 
                case 3:
                    print("Option 3") 
                case 4:
                    print("Option 4")
                case 5:
                    print("Option 5")
                case _:
                    if option != -1:
                        os.system('clear')
                        print("Please enter a valid number")
                        self.pressContinue()



               



