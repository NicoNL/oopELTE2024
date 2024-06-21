namespace HobbyAnimals;
using System;
using TextFile;

//Using  the Primary constructor feature from C#,for making the code cleaner and let child classes use it
public abstract class Animal(string name, int exhilaration, char type)
{
    //This exception are useful for keeping track of the state of the animal, these exception are handled in Steve class
    public class DeadAnimalException : Exception { }
    public class LimitexhilarationException : Exception { }
    protected string name { get; } = name;
    protected int exhilaration { set; get; } = exhilaration;
    protected char type { get; } = type;

    //Changing the exhilartion will change depending on Steve's mood and the type of animal, that's why all of the animals must have this method but implemented it differently
    public abstract void changeEx(HobbyAnimals.Mood mood);
    public string getName()
    {
        return this.name;
    }
    public char getType()
    {
        return type;
    }
    public int getEx()
    {
        return exhilaration;
    }
    //These two methods are the same in all of the child classess that's why is fully implemented
    protected void decreaseEx(int x)
    {
        if (exhilaration == 0)
        {
            throw new DeadAnimalException();
        }
        if (exhilaration - x < 0)
        {
            exhilaration = 0;
        }
        else
        {
            exhilaration -= x;
        }
    }
    protected void increaseEx(int x)
    {
        if (exhilaration == 70)
        {

            throw new LimitexhilarationException();
        }
        if (exhilaration == 0)
        {
            throw new DeadAnimalException();
        }
        if (exhilaration + x > 70)
        {
            exhilaration = 70;
        }
        else
        {
            exhilaration += x;
        }
    }

    public override string ToString()
    {
        return type + " " + name + " " + exhilaration;
    }
}
